using PoolTournament.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace PoolTournament
{

    public partial class LoginForm : Form
    {
        private PictureBox logo;
        private Button btnRegister;

        public LoginForm()
        {
            InitializeComponent();

            SetupLoginUI();
            AddLogo();
            AddLoginIcons();

            this.Resize += LoginForm_Resize;
            this.AcceptButton = btnLogin;

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
            CenterLoginPanel();
        }

        private void CenterLoginPanel()
        {
            pnlLogin.Left = (this.ClientSize.Width - pnlLogin.Width) / 2;
            pnlLogin.Top = (this.ClientSize.Height - pnlLogin.Height) / 2;
        }

        // ==========================================
        // THIẾT KẾ GIAO DIỆN
        // ==========================================
        private void SetupLoginUI()
        {
            Color gold = Color.FromArgb(255, 193, 7);
            Color darkBackground = Color.FromArgb(10, 10, 10);
            Color panelBackground = Color.FromArgb(20, 20, 20);

            this.Text = "POOL TOURNAMENT MANAGEMENT";
            this.BackColor = darkBackground;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ClientSize = new Size(900, 600);

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

            pnlLogin.BackColor = panelBackground;
            pnlLogin.Size = new Size(430, 520);
            CenterLoginPanel();

            lblTitle.Text = "POOL TOURNAMENT";
            lblTitle.ForeColor = gold;
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.AutoSize = false;
            lblTitle.Width = 380;
            lblTitle.Height = 50;
            lblTitle.Left = 25;
            lblTitle.Top = 120;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnlLogin.Controls.Add(lblTitle);

            lblSubtitle.Text = "Chào mừng bạn quay trở lại!";
            lblSubtitle.ForeColor = Color.FromArgb(180, 180, 180);
            lblSubtitle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtitle.AutoSize = false;
            lblSubtitle.Width = 380;
            lblSubtitle.Height = 30;
            lblSubtitle.Left = 25;
            lblSubtitle.Top = 170;
            pnlLogin.Controls.Add(lblSubtitle);

            lblUsername.Text = "Tên đăng nhập:";
            lblUsername.ForeColor = gold;
            lblUsername.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblUsername.AutoSize = false;
            lblUsername.Width = 330;
            lblUsername.Height = 25;
            lblUsername.Left = 50;
            lblUsername.Top = 220;

            txtUsername.BackColor = Color.FromArgb(30, 30, 30);
            txtUsername.ForeColor = Color.White;
            txtUsername.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Width = 330;
            txtUsername.Left = 50;
            txtUsername.Top = 245;
            txtUsername.Height = 40;
            txtUsername.PlaceholderText = "Nhập tên đăng nhập...";

            lblPassword.Text = "Mật khẩu:";
            lblPassword.ForeColor = gold;
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblPassword.AutoSize = false;
            lblPassword.Width = 330;
            lblPassword.Height = 25;
            lblPassword.Left = 50;
            lblPassword.Top = 300;

            txtPassword.BackColor = Color.FromArgb(30, 30, 30);
            txtPassword.ForeColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.PlaceholderText = "Nhập mật khẩu...";
            txtPassword.PasswordChar = '●';
            txtPassword.Width = 330;
            txtPassword.Left = 50;
            txtPassword.Top = 325;
            txtPassword.Height = 40;

            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.BackColor = gold;
            btnLogin.ForeColor = Color.Black;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Width = 330;
            btnLogin.Height = 45;
            btnLogin.Left = 50;
            btnLogin.Top = 390;

            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;

            pnlLogin.Region = new Region(GetRoundedPath(new Rectangle(0, 0, pnlLogin.Width, pnlLogin.Height), 20));
            btnLogin.Region = new Region(GetRoundedPath(new Rectangle(0, 0, btnLogin.Width, btnLogin.Height), 10));

            txtUsername.Enter += (s, e) => { txtUsername.BackColor = Color.FromArgb(45, 45, 45); };
            txtUsername.Leave += (s, e) => { txtUsername.BackColor = Color.FromArgb(32, 32, 32); };

            txtPassword.Enter += (s, e) => { txtPassword.BackColor = Color.FromArgb(45, 45, 45); };
            txtPassword.Leave += (s, e) => { txtPassword.BackColor = Color.FromArgb(32, 32, 32); };

            btnRegister = new Button();
            btnRegister.Text = "Chưa có tài khoản? Đăng ký";
            btnRegister.BackColor = Color.Transparent;
            btnRegister.ForeColor = Color.FromArgb(255, 193, 7);
            btnRegister.Font = new Font("Segoe UI", 9);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.Width = 330;
            btnRegister.Height = 30;
            btnRegister.Left = 50;
            btnRegister.Top = 445;
            btnRegister.Click += BtnRegister_Click;

            pnlLogin.Controls.Add(btnRegister);
        }

        private void AddLogo()
        {
            string logoPath = Path.Combine(Application.StartupPath, "img", "logo.png");
            if (!File.Exists(logoPath)) return;

            logo = new PictureBox();
            using (Image temp = Image.FromFile(logoPath))
            {
                logo.Image = new Bitmap(temp);
            }
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.Width = 90;
            logo.Height = 90;
            logo.Left = (pnlLogin.Width - logo.Width) / 2;
            logo.Top = 20;
            logo.BackColor = Color.Transparent;
            pnlLogin.Controls.Add(logo);
            logo.BringToFront();
        }

        private void AddLoginIcons()
        {
            Color gold = Color.FromArgb(255, 193, 7);
            Color inputColor = Color.FromArgb(30, 30, 30);
            Color gray = Color.FromArgb(180, 180, 180);

            Panel usernamePanel = new Panel();
            usernamePanel.Left = txtUsername.Left;
            usernamePanel.Top = txtUsername.Top;
            usernamePanel.Width = 330;
            usernamePanel.Height = 40;
            usernamePanel.BackColor = inputColor;
            usernamePanel.BorderStyle = BorderStyle.FixedSingle;
            pnlLogin.Controls.Add(usernamePanel);

            Label userIcon = new Label();
            userIcon.Text = "👤";
            userIcon.Font = new Font("Segoe UI Emoji", 11);
            userIcon.ForeColor = gold;
            userIcon.BackColor = inputColor;
            userIcon.Width = 35;
            userIcon.Height = 38;
            userIcon.TextAlign = ContentAlignment.MiddleCenter;
            usernamePanel.Controls.Add(userIcon);

            txtUsername.Parent = usernamePanel;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Left = 35;
            txtUsername.Top = 0;
            txtUsername.Width = 293;
            txtUsername.Height = 38;

            Panel passwordPanel = new Panel();
            passwordPanel.Left = txtPassword.Left;
            passwordPanel.Top = txtPassword.Top;
            passwordPanel.Width = 330;
            passwordPanel.Height = 40;
            passwordPanel.BackColor = inputColor;
            passwordPanel.BorderStyle = BorderStyle.FixedSingle;
            pnlLogin.Controls.Add(passwordPanel);

            Label passwordIcon = new Label();
            passwordIcon.Text = "🔒";
            passwordIcon.Font = new Font("Segoe UI Emoji", 10);
            passwordIcon.ForeColor = gold;
            passwordIcon.BackColor = inputColor;
            passwordIcon.Width = 35;
            passwordIcon.Height = 38;
            passwordIcon.TextAlign = ContentAlignment.MiddleCenter;
            passwordPanel.Controls.Add(passwordIcon);

            txtPassword.Parent = passwordPanel;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Left = 35;
            txtPassword.Top = 0;
            txtPassword.Width = 255;
            txtPassword.Height = 38;

            Button btnShowPassword = new Button();
            btnShowPassword.Text = "👁";
            btnShowPassword.Font = new Font("Segoe UI Emoji", 10);
            btnShowPassword.ForeColor = gray;
            btnShowPassword.BackColor = inputColor;
            btnShowPassword.FlatStyle = FlatStyle.Flat;
            btnShowPassword.FlatAppearance.BorderSize = 0;
            btnShowPassword.Cursor = Cursors.Hand;
            btnShowPassword.Width = 35;
            btnShowPassword.Height = 36;
            btnShowPassword.Left = 290;
            btnShowPassword.Top = 1;
            passwordPanel.Controls.Add(btnShowPassword);

            btnShowPassword.Click += (sender, e) =>
            {
                if (txtPassword.PasswordChar == '\0')
                {
                    txtPassword.PasswordChar = '●';
                    btnShowPassword.Text = "👁";
                }
                else
                {
                    txtPassword.PasswordChar = '\0';
                    btnShowPassword.Text = "🙈";
                }
                txtPassword.Focus();
                txtPassword.SelectionStart = txtPassword.Text.Length;
            };

            passwordIcon.Click += (sender, e) => { txtPassword.Focus(); };
        }

        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(255, 210, 50);
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(255, 193, 7);
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        // ==========================================
        // XỬ LÝ ĐĂNG NHẬP VỚI SUPABASE
        // ==========================================

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra tên đăng nhập
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

            // Kiểm tra mật khẩu
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

            // Khóa nút đăng nhập
            btnLogin.Enabled = false;
            btnLogin.Text = "ĐANG XỬ LÝ...";

            try
            {
                // ==========================================
                // KHỞI TẠO SUPABASE
                // ==========================================

                await SupabaseClient.InitializeAsync();

                if (SupabaseClient.Instance == null)
                {
                    throw new Exception("Supabase chưa được khởi tạo.");
                }

                // ==========================================
                // BĂM MẬT KHẨU
                // ==========================================

                string hashedPassword = HashPassword(password);

                // ==========================================
                // KIỂM TRA TÀI KHOẢN
                // ==========================================

                var response = await SupabaseClient.Instance
                    .From<User>()
                    .Where(x =>
                        x.Username == username &&
                        x.PasswordHash == hashedPassword
                    )
                    .Get();

                var currentUser = response.Model;

                // ==========================================
                // ĐĂNG NHẬP THÀNH CÔNG
                // ==========================================

                if (currentUser != null)
                {
                    MessageBox.Show(
                        $"Đăng nhập thành công!\n" +
                        $"Xin chào: {currentUser.FullName} ({currentUser.Role?.ToUpper()})",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    MainForm mainForm = new MainForm(currentUser);

                    mainForm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Tên đăng nhập hoặc mật khẩu không chính xác!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi!\n\n" +
                    "Loại lỗi: " + ex.GetType().Name + "\n\n" +
                    "Chi tiết:\n" + ex.Message + "\n\n" +
                    "Vị trí lỗi:\n" + ex.StackTrace,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "ĐĂNG NHẬP";
            }
        }


        // ==========================================
        // HÀM BĂM MẬT KHẨU SHA256
        // ==========================================

        private string HashPassword(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes =
                    sha256Hash.ComputeHash(
                        Encoding.UTF8.GetBytes(rawData)
                    );

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}