using PoolTournament.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PoolTournament.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        // Dictionary dùng để lưu OTP theo từng Email
        private static Dictionary<string, (string Otp, DateTime ExpireTime)> otpStore
            = new Dictionary<string, (string, DateTime)>();

        // Timer và biến đếm ngược thời gian OTP
        private System.Windows.Forms.Timer otpTimer;
        private int remainingSeconds = 300; // 5 phút = 300 giây


        public ForgotPasswordForm()
        {
            InitializeComponent();
            InitState();
            InitTimer();
        }

        // Khởi tạo trạng thái ban đầu của Form
        private void InitState()
        {

            // Tạo giao diện icon và nút bấm ẩn/hiện mật khẩu
            AddPasswordIcons();

            // Giới hạn ô OTP chỉ cho nhập tối đa 6 ký tự
            txtOTP.MaxLength = 6;

            txtOTP.Enabled = false;
            btnVerifyOTP.Enabled = false;

            txtNewPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            btnResetPassword.Enabled = false;

            if (lblTimer != null) lblTimer.Text = "";

            // Gán sự kiện phím Enter cho các TextBox
            txtEmail.KeyDown += txtEmail_KeyDown;
            txtOTP.KeyDown += txtOTP_KeyDown;
            txtNewPassword.KeyDown += txtNewPassword_KeyDown;
            txtConfirmPassword.KeyDown += txtConfirmPassword_KeyDown;
        }
        private void InitTimer()
        {
            otpTimer = new System.Windows.Forms.Timer();
            otpTimer.Interval = 1000; // 1 giây
            otpTimer.Tick += OtpTimer_Tick;
        }

        private void OtpTimer_Tick(object sender, EventArgs e)
        {
            if (remainingSeconds > 0)
            {
                remainingSeconds--;
                TimeSpan time = TimeSpan.FromSeconds(remainingSeconds);
                if (lblTimer != null)
                {
                    lblTimer.Text = string.Format("Gửi lại sau: {0:D2}:{1:D2}", time.Minutes, time.Seconds);
                }
            }
            else
            {
                otpTimer.Stop();
                btnSendOTP.Enabled = true;
                btnSendOTP.Text = "GỬI LẠI OTP";
                if (lblTimer != null) lblTimer.Text = "Mã OTP đã hết hạn!";
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void lblOTP_Click(object sender, EventArgs e)
        {
        }

        // -------------------------------------------------------------
        // BƯỚC 4.1: GỬI MÃ OTP
        // -------------------------------------------------------------
        private async void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // 1. Kiểm tra Email rỗng & Định dạng Email/Gmail
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Regex email chuẩn
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Định dạng Email không hợp lệ! Ví dụ: example@gmail.com", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            btnSendOTP.Enabled = false;
            btnSendOTP.Text = "Đang kiểm tra...";

            try
            {
                // 2. Kiểm tra Email có tồn tại trên Supabase không
                var response = await SupabaseClient.Instance
                    .From<RegisterUser>()
                    .Where(x => x.Email == email)
                    .Get();

                if (response.Models.Count == 0)
                {
                    MessageBox.Show("Email này chưa được đăng ký trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSendOTP.Enabled = true;
                    btnSendOTP.Text = "GỬI MÃ OTP";
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                    return;
                }

                // 3. Sinh mã OTP ngẫu nhiên 6 chữ số
                Random rnd = new Random();
                string otp = rnd.Next(100000, 999999).ToString();

                // 4. Lưu OTP + Hạn 5 phút
                otpStore[email] = (otp, DateTime.Now.AddMinutes(5));

                // 5. Gửi Email
                bool isSent = EmailService.SendOTP(email, otp);

                if (isSent)
                {
                    MessageBox.Show("Mã OTP đã được gửi đến Email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.ReadOnly = true;

                    txtOTP.Enabled = true;
                    btnVerifyOTP.Enabled = true;

                    // KÍCH HOẠT TIMER ĐẾM NGƯỢC 5 PHÚT (300 giây)
                    remainingSeconds = 300;
                    otpTimer.Start();

                    // FOCUS VÀO Ô OTP
                    txtOTP.Focus();
                    txtOTP.SelectAll();
                }
                else
                {
                    MessageBox.Show("Gửi Email thất bại! Vui lòng kiểm tra lại kết nối mạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSendOTP.Enabled = true;
                    btnSendOTP.Text = "GỬI MÃ OTP";
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSendOTP.Enabled = true;
                btnSendOTP.Text = "GỬI MÃ OTP";
                txtEmail.Focus();
                txtEmail.SelectAll();
            }
        }

        // -------------------------------------------------------------
        // BƯỚC 4.2: XÁC NHẬN MÃ OTP
        // -------------------------------------------------------------
        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string inputOtp = txtOTP.Text.Trim();

            // Kiểm tra rỗng và độ dài đúng 6 chữ số
            if (string.IsNullOrEmpty(inputOtp))
            {
                MessageBox.Show("Vui lòng nhập mã OTP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOTP.Focus();
                return;
            }

            if (inputOtp.Length != 6 || !long.TryParse(inputOtp, out _))
            {
                MessageBox.Show("Mã OTP phải bao gồm đúng 6 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOTP.Focus();
                return;
            }

            if (!otpStore.ContainsKey(email))
            {
                MessageBox.Show("Chưa có mã OTP nào được gửi cho Email này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var otpData = otpStore[email];

            // Kiểm tra hết hạn 5 phút
            if (DateTime.Now > otpData.ExpireTime)
            {
                MessageBox.Show("Mã OTP đã hết hạn! Vui lòng bấm gửi lại mã mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đối chiếu OTP
            if (inputOtp == otpData.Otp)
            {
                otpTimer.Stop(); // Dừng đếm ngược khi xác thực thành công
                if (lblTimer != null) lblTimer.Text = "Xác thực thành công!";

                MessageBox.Show("Xác nhận OTP thành công! Vui lòng nhập mật khẩu mới.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOTP.Enabled = false;
                btnVerifyOTP.Enabled = false;

                txtNewPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;
                btnResetPassword.Enabled = true;

                // FOCUS VÀO Ô MẬT KHẨU MỚI
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();
            }
            else
            {
                MessageBox.Show("Mã OTP không chính xác. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOTP.Focus();
                txtOTP.SelectAll();
            }
        }

        // -------------------------------------------------------------
        // BƯỚC 4.3: ĐỔI MẬT KHẨU MỚI VÀO CSDL (ĐÃ THÊM ASYNC VÀ BẰM PASS)
        // -------------------------------------------------------------
        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            // 1. KIỂM TRA MẬT KHẨU MỚI (Đồng bộ quy tắc với RegisterForm)
            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }
            if (newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();
                return;
            }
            if (newPass.Length > 100)
            {
                MessageBox.Show("Mật khẩu không được vượt quá 100 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();
                return;
            }

            bool hasLetter = false;
            bool hasNumber = false;
            foreach (char c in newPass)
            {
                if (char.IsLetter(c)) hasLetter = true;
                if (char.IsDigit(c)) hasNumber = true;
            }

            if (!hasLetter)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }
            if (!hasNumber)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            // 2. KIỂM TRA XÁC NHẬN MẬT KHẨU
            if (string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }
            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            // 3. TIẾN HÀNH CẬP NHẬT TRÊN SUPABASE
            btnResetPassword.Enabled = false;
            btnResetPassword.Text = "ĐANG XỬ LÝ...";

            try
            {
                // Băm mật khẩu theo SHA-256
                string newHashedPassword = HashPassword(newPass);

                // Tạo object model chứa dữ liệu cập nhật
                var userToUpdate = new RegisterUser
                {
                    PasswordHash = newHashedPassword
                };

                // Cập nhật vào Supabase
                await SupabaseClient.Instance
                    .From<RegisterUser>()
                    .Where(x => x.Email == email)
                    .Set(x => x.PasswordHash, newHashedPassword)
                    .Update();

                otpStore.Remove(email);

                MessageBox.Show("🎉 Đổi mật khẩu thành công! Bạn có thể đăng nhập lại.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng form Quên mật khẩu để quay về Login
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật mật khẩu mới!\n\nLỗi: " + ex.Message, "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnResetPassword.Enabled = true;
                btnResetPassword.Text = "ĐỔI MẬT KHẨU";
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius - 1, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius - 1, rect.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius - 1, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            CenterForgotPanel();
        }

        private void CenterForgotPanel()
        {
            pnlForgotPassword.Left = (this.ClientSize.Width - pnlForgotPassword.Width) / 2;
            pnlForgotPassword.Top = (this.ClientSize.Height - pnlForgotPassword.Height) / 2;
        }

        private void AddPasswordIcons()
        {
            Color gold = Color.FromArgb(255, 193, 7);
            Color inputColor = Color.FromArgb(30, 30, 30);
            Color gray = Color.FromArgb(180, 180, 180);


            Color darkBackground = Color.FromArgb(10, 10, 10);
            Color panelBackground = Color.FromArgb(20, 20, 20);
            this.BackColor = darkBackground;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            //  this.ClientSize = new Size(900, 600);

            string backgroundPath = Path.Combine(
       Application.StartupPath,
       "..",
       "..",
       "..",
       "img",
       "background.png"
   );

            backgroundPath = Path.GetFullPath(backgroundPath);

            if (File.Exists(backgroundPath))
            {
                using (Image temp = Image.FromFile(backgroundPath))
                {
                    this.BackgroundImage = new Bitmap(temp);
                }

                this.BackgroundImageLayout = ImageLayout.Stretch;
            }

            lblUsername.BackColor = panelBackground;
            lblUsername.ForeColor = gold;



            lblOTP.BackColor = panelBackground;
            lblOTP.ForeColor = gold;


            txtEmail.BackColor = Color.FromArgb(30, 30, 30);
            txtEmail.ForeColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;

            txtOTP.BackColor = Color.FromArgb(30, 30, 30);
            txtOTP.ForeColor = Color.White;
            txtOTP.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            txtOTP.BorderStyle = BorderStyle.FixedSingle;

            pnlForgotPassword.BackColor = panelBackground;
            pnllblQuenMatKhau.BackColor = panelBackground;
            lblTitle.BackColor = panelBackground;

            //   pnlForgotPassword.Size = new Size(430, 520);
            CenterForgotPanel();

            // -------------------------------------------------------------
            // 1. TẠO PANEL CHO MẬT KHẨU MỚI (txtNewPassword)
            // -------------------------------------------------------------
            Panel newPasswordPanel = new Panel
            {
                Left = txtNewPassword.Left,   // Lấy đúng vị trí (168)
                Top = txtNewPassword.Top,     // Lấy đúng vị trí (167)
                Width = txtNewPassword.Width, // Lấy đúng chiều rộng (245)
                Height = 32,
                BackColor = panelBackground,
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlForgotPassword.Controls.Add(newPasswordPanel); // Thêm trực tiếp vào pnlForgotPassword

            Label newPasswordIcon = new Label
            {
                Text = "🔒",
                Font = new Font("Segoe UI Emoji", 10),
                ForeColor = gold,
                BackColor = inputColor,
                Width = 30,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };
            newPasswordPanel.Controls.Add(newPasswordIcon);

            txtNewPassword.Parent = newPasswordPanel;
            txtNewPassword.BorderStyle = BorderStyle.None;
            txtNewPassword.BackColor = inputColor;
            txtNewPassword.ForeColor = Color.White; // Đổi chữ sang màu trắng để nổi bật trên nền tối
            txtNewPassword.Left = 30;
            txtNewPassword.Top = 5;
            txtNewPassword.Width = newPasswordPanel.Width - 62; // Rộng ~ 183px cho ô nhập
            txtNewPassword.UseSystemPasswordChar = true;

            Button btnShowNewPassword = new Button
            {
                Text = "👁",
                Font = new Font("Segoe UI Emoji", 10),
                ForeColor = gray,
                BackColor = inputColor,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Width = 30,
                Height = 30,
                Left = newPasswordPanel.Width - 31,
                Top = 0
            };
            btnShowNewPassword.FlatAppearance.BorderSize = 0;
            newPasswordPanel.Controls.Add(btnShowNewPassword);

            btnShowNewPassword.Click += (sender, e) =>
            {
                if (txtNewPassword.UseSystemPasswordChar)
                {
                    txtNewPassword.UseSystemPasswordChar = false;
                    txtNewPassword.PasswordChar = '\0';
                    btnShowNewPassword.Text = "🙈";
                }
                else
                {
                    txtNewPassword.UseSystemPasswordChar = true;
                    btnShowNewPassword.Text = "👁";
                }
                txtNewPassword.Focus();
                txtNewPassword.SelectionStart = txtNewPassword.Text.Length;
            };

            newPasswordIcon.Click += (sender, e) => { txtNewPassword.Focus(); };

            // -------------------------------------------------------------
            // 2. TẠO PANEL CHO XÁC NHẬN MẬT KHẨU (txtConfirmPassword)
            // -------------------------------------------------------------
            Panel confirmPasswordPanel = new Panel
            {
                Left = txtConfirmPassword.Left,   // Lấy đúng vị trí (168)
                Top = txtConfirmPassword.Top,     // Lấy đúng vị trí (214)
                Width = txtConfirmPassword.Width, // Lấy đúng chiều rộng (245)
                Height = 32,
                BackColor = inputColor,
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlForgotPassword.Controls.Add(confirmPasswordPanel);

            Label confirmPasswordIcon = new Label
            {
                Text = "🔒",
                Font = new Font("Segoe UI Emoji", 10),
                ForeColor = gold,
                BackColor = inputColor,
                Width = 30,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };
            confirmPasswordPanel.Controls.Add(confirmPasswordIcon);

            txtConfirmPassword.Parent = confirmPasswordPanel;
            txtConfirmPassword.BorderStyle = BorderStyle.None;
            txtConfirmPassword.BackColor = inputColor;
            txtConfirmPassword.ForeColor = Color.White;
            txtConfirmPassword.Left = 30;
            txtConfirmPassword.Top = 5;
            txtConfirmPassword.Width = confirmPasswordPanel.Width - 62;
            txtConfirmPassword.UseSystemPasswordChar = true;

            Button btnShowConfirmPassword = new Button
            {
                Text = "👁",
                Font = new Font("Segoe UI Emoji", 10),
                ForeColor = gray,
                BackColor = inputColor,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Width = 30,
                Height = 30,
                Left = confirmPasswordPanel.Width - 31,
                Top = 0
            };
            btnShowConfirmPassword.FlatAppearance.BorderSize = 0;
            confirmPasswordPanel.Controls.Add(btnShowConfirmPassword);

            btnShowConfirmPassword.Click += (sender, e) =>
            {
                if (txtConfirmPassword.UseSystemPasswordChar)
                {
                    txtConfirmPassword.UseSystemPasswordChar = false;
                    txtConfirmPassword.PasswordChar = '\0';
                    btnShowConfirmPassword.Text = "🙈";
                }
                else
                {
                    txtConfirmPassword.UseSystemPasswordChar = true;
                    btnShowConfirmPassword.Text = "👁";
                }
                txtConfirmPassword.Focus();
                txtConfirmPassword.SelectionStart = txtConfirmPassword.Text.Length;
            };

            confirmPasswordIcon.Click += (sender, e) => { txtConfirmPassword.Focus(); };
        }


        private string HashPassword(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Chặn tiếng kêu 'beep' mặc định của WinForms khi nhấn Enter
                btnSendOTP.PerformClick();  // Kích hoạt sự kiện click của nút Gửi OTP
            }
        }

        private void txtOTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnVerifyOTP.PerformClick(); // Kích hoạt sự kiện click của nút Xác nhận OTP
            }
        }

        private void txtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string newPass = txtNewPassword.Text;

                // Validate cơ bản ngay tại chỗ
                if (string.IsNullOrWhiteSpace(newPass) || newPass.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPassword.Focus();
                    txtNewPassword.SelectAll();
                    return;
                }

                bool hasLetter = newPass.Any(char.IsLetter);
                bool hasNumber = newPass.Any(char.IsDigit);

                if (!hasLetter || !hasNumber)
                {
                    MessageBox.Show("Mật khẩu phải chứa cả chữ cái và chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNewPassword.Focus();
                    txtNewPassword.SelectAll();
                    return;
                }

                // Nếu hợp lệ thì mới chuyển sang ô xác nhận
                txtConfirmPassword.Focus();
                txtConfirmPassword.SelectAll();
            }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnResetPassword.PerformClick(); // Kích hoạt sự kiện click của nút Đổi mật khẩu
            }
        }
    }
}
