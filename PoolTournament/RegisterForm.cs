using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PoolTournament
{
    public partial class RegisterForm : Form
    {
        private Panel pnlRegister;

        private Label lblTitle;
        private Label lblSubtitle;

        private Label lblFullName;
        private Label lblUsername;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblConfirmPassword;

        private TextBox txtFullName;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;

        private Button btnRegister;
        private Button btnBack;

        private Color gold = Color.FromArgb(255, 193, 7);
        private Color darkBackground = Color.FromArgb(10, 10, 10);
        private Color panelBackground = Color.FromArgb(20, 20, 20);
        private Color inputBackground = Color.FromArgb(30, 30, 30);

        public RegisterForm()
        {
            InitializeComponent();

            SetupRegisterUI();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // ==========================================
        // GIAO DIỆN
        // ==========================================

        private void SetupRegisterUI()
        {
            // FORM
            this.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.BackColor = darkBackground;
            this.ClientSize = new Size(900, 650);

            // PANEL
            pnlRegister = new Panel();

            pnlRegister.Size = new Size(450, 570);
            pnlRegister.BackColor = panelBackground;

            pnlRegister.Left =
                (this.ClientSize.Width - pnlRegister.Width) / 2;

            pnlRegister.Top =
                (this.ClientSize.Height - pnlRegister.Height) / 2;

            pnlRegister.Region = new Region(
                GetRoundedPath(
                    new Rectangle(
                        0,
                        0,
                        pnlRegister.Width,
                        pnlRegister.Height
                    ),
                    20
                )
            );

            this.Controls.Add(pnlRegister);


            // ==========================================
            // TITLE
            // ==========================================

            lblTitle = new Label();

            lblTitle.Text = "TẠO TÀI KHOẢN";
            lblTitle.ForeColor = gold;

            lblTitle.Font = new Font(
                "Segoe UI",
                21,
                FontStyle.Bold
            );

            lblTitle.AutoSize = false;
            lblTitle.Width = 390;
            lblTitle.Height = 50;

            lblTitle.Left = 30;
            lblTitle.Top = 35;

            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            pnlRegister.Controls.Add(lblTitle);


            // ==========================================
            // SUBTITLE
            // ==========================================

            lblSubtitle = new Label();

            lblSubtitle.Text =
                "Đăng ký tài khoản để sử dụng hệ thống";

            lblSubtitle.ForeColor =
                Color.FromArgb(180, 180, 180);

            lblSubtitle.Font =
                new Font("Segoe UI", 9.5f);

            lblSubtitle.AutoSize = false;

            lblSubtitle.Width = 390;
            lblSubtitle.Height = 30;

            lblSubtitle.Left = 30;
            lblSubtitle.Top = 85;

            lblSubtitle.TextAlign =
                ContentAlignment.MiddleCenter;

            pnlRegister.Controls.Add(lblSubtitle);


            // ==========================================
            // HỌ TÊN
            // ==========================================

            lblFullName = CreateLabel(
                "Họ và tên:",
                30,
                125
            );

            txtFullName = CreateTextBox(
                30,
                150,
                "Nhập họ và tên..."
            );


            // ==========================================
            // USERNAME
            // ==========================================

            lblUsername = CreateLabel(
                "Tên đăng nhập:",
                30,
                195
            );

            txtUsername = CreateTextBox(
                30,
                220,
                "Nhập tên đăng nhập..."
            );


            // ==========================================
            // EMAIL
            // ==========================================

            lblEmail = CreateLabel(
                "Email:",
                30,
                265
            );

            txtEmail = CreateTextBox(
                30,
                290,
                "Nhập email..."
            );


            // ==========================================
            // PASSWORD
            // ==========================================

            lblPassword = CreateLabel(
                "Mật khẩu:",
                30,
                335
            );

            txtPassword = CreateTextBox(
                30,
                360,
                "Nhập mật khẩu..."
            );

            txtPassword.UseSystemPasswordChar = true;


            // ==========================================
            // CONFIRM PASSWORD
            // ==========================================

            lblConfirmPassword = CreateLabel(
                "Xác nhận mật khẩu:",
                30,
                405
            );

            txtConfirmPassword = CreateTextBox(
                30,
                430,
                "Nhập lại mật khẩu..."
            );

            txtConfirmPassword.UseSystemPasswordChar = true;


            // ==========================================
            // BUTTON ĐĂNG KÝ
            // ==========================================

            btnRegister = new Button();

            btnRegister.Text = "ĐĂNG KÝ";

            btnRegister.BackColor = gold;
            btnRegister.ForeColor = Color.Black;

            btnRegister.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Bold
            );

            btnRegister.FlatStyle =
                FlatStyle.Flat;

            btnRegister.FlatAppearance.BorderSize = 0;

            btnRegister.Cursor = Cursors.Hand;

            btnRegister.Width = 390;
            btnRegister.Height = 45;

            btnRegister.Left = 30;
            btnRegister.Top = 485;

            btnRegister.Region = new Region(
                GetRoundedPath(
                    new Rectangle(
                        0,
                        0,
                        btnRegister.Width,
                        btnRegister.Height
                    ),
                    10
                )
            );

            btnRegister.Click += BtnRegister_Click;

            btnRegister.MouseEnter +=
                (s, e) =>
                {
                    btnRegister.BackColor =
                        Color.FromArgb(255, 210, 50);
                };

            btnRegister.MouseLeave +=
                (s, e) =>
                {
                    btnRegister.BackColor = gold;
                };

            pnlRegister.Controls.Add(btnRegister);


            // ==========================================
            // BUTTON QUAY LẠI
            // ==========================================

            btnBack = new Button();

            btnBack.Text = "← Quay lại đăng nhập";

            btnBack.BackColor =
                Color.Transparent;

            btnBack.ForeColor =
                Color.FromArgb(180, 180, 180);

            btnBack.Font =
                new Font("Segoe UI", 9);

            btnBack.FlatStyle =
                FlatStyle.Flat;

            btnBack.FlatAppearance.BorderSize = 0;

            btnBack.Cursor = Cursors.Hand;

            btnBack.Width = 200;
            btnBack.Height = 30;

            btnBack.Left = 125;
            btnBack.Top = 530;

            btnBack.Click += (s, e) =>
            {
                this.Close();
            };

            pnlRegister.Controls.Add(btnBack);
        }


        // ==========================================
        // TẠO LABEL
        // ==========================================

        private Label CreateLabel(
            string text,
            int left,
            int top)
        {
            Label label = new Label();

            label.Text = text;

            label.ForeColor = gold;

            label.Font = new Font(
                "Segoe UI",
                9.5f
            );

            label.AutoSize = false;

            label.Width = 390;
            label.Height = 25;

            label.Left = left;
            label.Top = top;

            pnlRegister.Controls.Add(label);

            return label;
        }


        // ==========================================
        // TẠO TEXTBOX
        // ==========================================

        private TextBox CreateTextBox(
            int left,
            int top,
            string placeholder)
        {
            TextBox textbox = new TextBox();

            textbox.BackColor = inputBackground;

            textbox.ForeColor = Color.White;

            textbox.Font = new Font(
                "Segoe UI",
                10.5f
            );

            textbox.BorderStyle =
                BorderStyle.FixedSingle;

            textbox.Width = 390;
            textbox.Height = 40;

            textbox.Left = left;
            textbox.Top = top;

            textbox.AutoSize = false;

            textbox.PlaceholderText =
                placeholder;

            textbox.Enter += (s, e) =>
            {
                textbox.BackColor =
                    Color.FromArgb(45, 45, 45);
            };

            textbox.Leave += (s, e) =>
            {
                textbox.BackColor =
                    inputBackground;
            };

            pnlRegister.Controls.Add(textbox);

            return textbox;
        }


        // ==========================================
        // BO GÓC
        // ==========================================

        private GraphicsPath GetRoundedPath(
            Rectangle rect,
            int radius)
        {
            GraphicsPath path =
                new GraphicsPath();

            path.AddArc(
                rect.X,
                rect.Y,
                radius,
                radius,
                180,
                90
            );

            path.AddArc(
                rect.Right - radius,
                rect.Y,
                radius,
                radius,
                270,
                90
            );

            path.AddArc(
                rect.Right - radius,
                rect.Bottom - radius,
                radius,
                radius,
                0,
                90
            );

            path.AddArc(
                rect.X,
                rect.Bottom - radius,
                radius,
                radius,
                90,
                90
            );

            path.CloseFigure();

            return path;
        }


        // ==========================================
        // ĐĂNG KÝ
        // ==========================================

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // ==========================================
            // 1. KIỂM TRA HỌ TÊN
            // ==========================================

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show(
                    "Vui lòng nhập họ và tên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtFullName.Focus();
                return;
            }

            if (fullName.Length < 2)
            {
                MessageBox.Show(
                    "Họ và tên phải có ít nhất 2 ký tự!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtFullName.Focus();
                return;
            }

            if (fullName.Length > 100)
            {
                MessageBox.Show(
                    "Họ và tên không được vượt quá 100 ký tự!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtFullName.Focus();
                return;
            }

            // Không cho số trong họ tên
            foreach (char c in fullName)
            {
                if (char.IsDigit(c))
                {
                    MessageBox.Show(
                        "Họ và tên không được chứa số!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtFullName.Focus();
                    return;
                }
            }


            // ==========================================
            // 2. KIỂM TRA USERNAME
            // ==========================================

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên đăng nhập!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUsername.Focus();
                return;
            }

            if (username.Length < 4)
            {
                MessageBox.Show(
                    "Tên đăng nhập phải có ít nhất 4 ký tự!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUsername.Focus();
                return;
            }

            if (username.Length > 50)
            {
                MessageBox.Show(
                    "Tên đăng nhập không được vượt quá 50 ký tự!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtUsername.Focus();
                return;
            }

            // Username chỉ cho chữ, số và _
            foreach (char c in username)
            {
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    MessageBox.Show(
                        "Tên đăng nhập chỉ được chứa chữ cái, số và dấu gạch dưới (_)!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtUsername.Focus();
                    return;
                }
            }


            // ==========================================
            // 3. KIỂM TRA EMAIL
            // ==========================================

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Vui lòng nhập email!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();
                return;
            }

            if (email.Length > 100)
            {
                MessageBox.Show(
                    "Email không được vượt quá 100 ký tự!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();
                return;
            }

            try
            {
                var mail = new System.Net.Mail.MailAddress(email);

                if (mail.Address != email)
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show(
                    "Email không đúng định dạng!\n\nVí dụ: example@gmail.com",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();
                return;
            }


            // ==========================================
            // 4. KIỂM TRA MẬT KHẨU
            // ==========================================

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Vui lòng nhập mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show(
                    "Mật khẩu phải có ít nhất 6 ký tự!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();
                return;
            }

            if (password.Length > 100)
            {
                MessageBox.Show(
                    "Mật khẩu không được vượt quá 100 ký tự!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();
                return;
            }

            // Phải có chữ
            bool hasLetter = false;

            // Phải có số
            bool hasNumber = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                    hasLetter = true;

                if (char.IsDigit(c))
                    hasNumber = true;
            }

            if (!hasLetter)
            {
                MessageBox.Show(
                    "Mật khẩu phải chứa ít nhất một chữ cái!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();
                return;
            }

            if (!hasNumber)
            {
                MessageBox.Show(
                    "Mật khẩu phải chứa ít nhất một chữ số!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Focus();
                return;
            }


            // ==========================================
            // 5. XÁC NHẬN MẬT KHẨU
            // ==========================================

            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Vui lòng xác nhận mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtConfirmPassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Mật khẩu xác nhận không khớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }


            // ==========================================
            // 6. KIỂM TRA DATABASE
            // ==========================================

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra username
                    string checkUsername = @"
                SELECT COUNT(*)
                FROM TaiKhoan
                WHERE TenDangNhap = @username
            ";

                    using (MySqlCommand cmd =
                        new MySqlCommand(checkUsername, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@username",
                            username
                        );

                        int count =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Tên đăng nhập đã tồn tại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            txtUsername.Focus();
                            return;
                        }
                    }


                    // ==========================================
                    // KIỂM TRA EMAIL
                    // ==========================================

                    string checkEmail = @"
                SELECT COUNT(*)
                FROM TaiKhoan
                WHERE Email = @email
            ";

                    using (MySqlCommand cmd =
                        new MySqlCommand(checkEmail, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@email",
                            email
                        );

                        int count =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Email này đã được sử dụng!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            txtEmail.Focus();
                            return;
                        }
                    }


                    // ==========================================
                    // 7. TẠO TÀI KHOẢN
                    // ==========================================

                    string insertSql = @"
                INSERT INTO TaiKhoan
                (
                    TenDangNhap,
                    MatKhau,
                    Email,
                    HoTen
                )
                VALUES
                (
                    @username,
                    @password,
                    @email,
                    @fullname
                )
            ";

                    using (MySqlCommand cmd =
                        new MySqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@username",
                            username
                        );

                        cmd.Parameters.AddWithValue(
                            "@password",
                            password
                        );

                        cmd.Parameters.AddWithValue(
                            "@email",
                            email
                        );

                        cmd.Parameters.AddWithValue(
                            "@fullname",
                            fullName
                        );

                        cmd.ExecuteNonQuery();
                    }


                    // ==========================================
                    // 8. THÀNH CÔNG
                    // ==========================================

                    MessageBox.Show(
                        "🎉 Đăng ký tài khoản thành công!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Không thể tạo tài khoản!\n\n" +
                    "Lỗi MySQL:\n" +
                    ex.Message,
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi!\n\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}