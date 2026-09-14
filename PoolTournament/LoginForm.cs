using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace PoolTournament
{
    public partial class LoginForm : Form
    {
        private PictureBox logo;

        private const int EM_SETMARGINS = 0xD3;
        private const int EC_LEFTMARGIN = 0x1;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int Msg,
            IntPtr wParam,
            IntPtr lParam
        );

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

        // ==========================================
        // CĂN GIỮA PANEL KHI FORM THAY ĐỔI KÍCH THƯỚC
        // ==========================================
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
            // ===== MÀU SẮC =====
            Color gold = Color.FromArgb(255, 193, 7);
            Color darkBackground = Color.FromArgb(10, 10, 10);
            Color panelBackground = Color.FromArgb(20, 20, 20);
            Color inputBackground = Color.FromArgb(32, 32, 32);
            Color white = Color.FromArgb(245, 245, 245);

            // ==========================================
            // FORM
            // ==========================================
            this.Text = "POOL TOURNAMENT MANAGEMENT";
            this.BackColor = darkBackground;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ClientSize = new Size(900, 600);

            // ===== BACKGROUND IMAGE =====
            string backgroundPath = Path.Combine(
                Application.StartupPath,
                "img",
                "background.png"
            );

            if (File.Exists(backgroundPath))
            {
                using (Image temp = Image.FromFile(backgroundPath))
                {
                    this.BackgroundImage = new Bitmap(temp);
                }

                this.BackgroundImageLayout = ImageLayout.Stretch;
            }



            // ==========================================
            // PANEL LOGIN
            // ==========================================
            pnlLogin.BackColor = panelBackground;
            MakeRoundedPanel(pnlLogin, 20);
            pnlLogin.Size = new Size(430, 520);

            CenterLoginPanel();

            // ==========================================
            // TITLE
            // ==========================================
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




            // ==========================================
            // SUBTITLE
            // ==========================================
            lblSubtitle.Text = "Chào mừng bạn quay trở lại!";

            lblSubtitle.ForeColor = Color.FromArgb(180, 180, 180);

            lblSubtitle.Font = new Font(
                "Segoe UI",
                10,
                FontStyle.Regular
            );

            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            lblSubtitle.AutoSize = false;

            lblSubtitle.Width = 380;
            lblSubtitle.Height = 30;

            lblSubtitle.Left = 25;
            lblSubtitle.Top = 170;

            lblSubtitle.BorderStyle = BorderStyle.None;

            pnlLogin.Controls.Add(lblSubtitle);

            // ==========================================
            // USERNAME LABEL
            // ==========================================
            lblUsername.Text = "Tên đăng nhập:";

            lblUsername.ForeColor = gold;
            lblUsername.Font = new Font(
                "Segoe UI",
                10,
                FontStyle.Regular
            );

            lblUsername.AutoSize = false;

            lblUsername.Width = 330;
            lblUsername.Height = 25;

            lblUsername.Left = 50;
            lblUsername.Top = 220;

            // ==========================================
            // USERNAME TEXTBOX
            // ==========================================
            txtUsername.BackColor = Color.FromArgb(30, 30, 30);
            txtUsername.ForeColor = Color.White;

            txtUsername.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Regular
            );

            txtUsername.BorderStyle = BorderStyle.FixedSingle;

            txtUsername.Width = 330;
            txtUsername.Height = 35;

            txtUsername.Left = 50;
            txtUsername.Top = 245;

            txtUsername.AutoSize = false;
            txtUsername.Height = 40;

            txtUsername.PlaceholderText = "Nhập tên đăng nhập...";

            // ==========================================
            // PASSWORD LABEL
            // ==========================================
            lblPassword.Text = "Mật khẩu:";

            lblPassword.ForeColor = gold;
            lblPassword.Font = new Font(
                "Segoe UI",
                10,
                FontStyle.Regular
            );

            lblPassword.AutoSize = false;

            lblPassword.Width = 330;
            lblPassword.Height = 25;

            lblPassword.Left = 50;
            lblPassword.Top = 300;

            // ==========================================
            // PASSWORD TEXTBOX
            // ==========================================
            txtPassword.BackColor = Color.FromArgb(30, 30, 30);
            txtPassword.ForeColor = Color.White;

            txtPassword.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Regular
            );

            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.PlaceholderText = "Nhập mật khẩu...";
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.PasswordChar = '●';


            txtPassword.Width = 330;
            txtPassword.Height = 35;

            txtPassword.Left = 50;
            txtPassword.Top = 325;

            txtPassword.AutoSize = false;
            txtPassword.Height = 40;

            // ==========================================
            // LOGIN BUTTON
            // ==========================================
            btnLogin.Text = "ĐĂNG NHẬP";

            btnLogin.BackColor = gold;
            btnLogin.ForeColor = Color.Black;

            btnLogin.Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Bold
            );

            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;

            btnLogin.Cursor = Cursors.Hand;

            btnLogin.Width = 330;
            btnLogin.Height = 45;

            btnLogin.Left = 50;
            btnLogin.Top = 390;

            // Hiệu ứng hover
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;

            // Thêm vào cuối SetupLoginUI()
            pnlLogin.Region = new Region(GetRoundedPath(new Rectangle(0, 0, pnlLogin.Width, pnlLogin.Height), 20));
            btnLogin.Region = new Region(GetRoundedPath(new Rectangle(0, 0, btnLogin.Width, btnLogin.Height), 10));

            // Đăng ký event khi Focus
            txtUsername.Enter += (s, e) => { txtUsername.BackColor = Color.FromArgb(45, 45, 45); };
            txtUsername.Leave += (s, e) => { txtUsername.BackColor = Color.FromArgb(32, 32, 32); };

            txtPassword.Enter += (s, e) => { txtPassword.BackColor = Color.FromArgb(45, 45, 45); };
            txtPassword.Leave += (s, e) => { txtPassword.BackColor = Color.FromArgb(32, 32, 32); };


            // ==========================================
            // BUTTON ĐĂNG KÝ
            // ==========================================

            btnRegister = new Button();

            btnRegister.Text = "Chưa có tài khoản? Đăng ký";

            btnRegister.BackColor = Color.Transparent;
            btnRegister.ForeColor = Color.FromArgb(255, 193, 7);

            btnRegister.Font = new Font(
                "Segoe UI",
                9
            );

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

        private void MakeRoundedPanel(Panel panel, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(
                panel.Width - radius,
                0,
                radius,
                radius,
                270,
                90
            );

            path.AddArc(
                panel.Width - radius,
                panel.Height - radius,
                radius,
                radius,
                0,
                90
            );

            path.AddArc(
                0,
                panel.Height - radius,
                radius,
                radius,
                90,
                90
            );

            path.CloseFigure();

            panel.Region = new Region(path);
        }


        // ==========================================
        // LOGO
        // ==========================================
        private void AddLogo()
        {
            string logoPath = Path.Combine(
                Application.StartupPath,
                "img",
                "logo.png"
            );

            if (!File.Exists(logoPath))
            {
                MessageBox.Show(
                    "Không tìm thấy logo:\n" + logoPath,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

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
            Color borderColor = Color.FromArgb(90, 90, 90);
            Color gray = Color.FromArgb(180, 180, 180);

            // =====================================================
            // KHUNG USERNAME
            // =====================================================

            Panel usernamePanel = new Panel();

            usernamePanel.Left = txtUsername.Left;
            usernamePanel.Top = txtUsername.Top;

            usernamePanel.Width = 330;
            usernamePanel.Height = 40;

            usernamePanel.BackColor = inputColor;

            usernamePanel.BorderStyle = BorderStyle.FixedSingle;

            pnlLogin.Controls.Add(usernamePanel);


            // =====================================================
            // ICON USER
            // =====================================================

            Label userIcon = new Label();

            userIcon.Text = "👤";
            userIcon.Font = new Font("Segoe UI Emoji", 11);

            userIcon.ForeColor = gold;
            userIcon.BackColor = inputColor;

            userIcon.Width = 35;
            userIcon.Height = 38;

            userIcon.Left = 0;
            userIcon.Top = 0;

            userIcon.TextAlign = ContentAlignment.MiddleCenter;

            usernamePanel.Controls.Add(userIcon);


            // =====================================================
            // ĐƯA TEXTBOX VÀO TRONG KHUNG
            // =====================================================

            txtUsername.Parent = usernamePanel;

            txtUsername.BorderStyle = BorderStyle.None;

            txtUsername.Left = 35;
            txtUsername.Top = 0;

            txtUsername.Width = 293;
            txtUsername.Height = 38;

            txtUsername.BackColor = inputColor;


            // =====================================================
            // KHUNG PASSWORD
            // =====================================================

            Panel passwordPanel = new Panel();

            passwordPanel.Left = txtPassword.Left;
            passwordPanel.Top = txtPassword.Top;

            passwordPanel.Width = 330;
            passwordPanel.Height = 40;

            passwordPanel.BackColor = inputColor;

            passwordPanel.BorderStyle = BorderStyle.FixedSingle;

            pnlLogin.Controls.Add(passwordPanel);


            // =====================================================
            // ICON PASSWORD
            // =====================================================

            Label passwordIcon = new Label();

            passwordIcon.Text = "🔒";
            passwordIcon.Font = new Font("Segoe UI Emoji", 10);

            passwordIcon.ForeColor = gold;
            passwordIcon.BackColor = inputColor;

            passwordIcon.Width = 35;
            passwordIcon.Height = 38;

            passwordIcon.Left = 0;
            passwordIcon.Top = 0;

            passwordIcon.TextAlign = ContentAlignment.MiddleCenter;

            passwordPanel.Controls.Add(passwordIcon);


            // =====================================================
            // TEXTBOX PASSWORD
            // =====================================================

            txtPassword.Parent = passwordPanel;

            txtPassword.BorderStyle = BorderStyle.None;

            txtPassword.Left = 35;
            txtPassword.Top = 0;

            txtPassword.Width = 255;
            txtPassword.Height = 38;

            txtPassword.BackColor = inputColor;


            // =====================================================
            // NÚT HIỆN / ẨN MẬT KHẨU
            // =====================================================

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


            // =====================================================
            // HIỆN / ẨN MẬT KHẨU
            // =====================================================
            btnShowPassword.Click += (sender, e) =>
            {
                if (txtPassword.PasswordChar == '\0')
                {
                    // Đang hiện → chuyển sang ẩn
                    txtPassword.PasswordChar = '●';
                    btnShowPassword.Text = "👁";
                }
                else
                {
                    // Đang ẩn → hiện mật khẩu thật
                    txtPassword.PasswordChar = '\0';
                    btnShowPassword.Text = "🙈";
                }

                txtPassword.Focus();
                txtPassword.SelectionStart = txtPassword.Text.Length;
            };


            // =====================================================
            // CLICK ICON PASSWORD
            // =====================================================

            passwordIcon.Click += (sender, e) =>
            {
                txtPassword.Focus();
            };
        }

        // ==========================================
        // HOVER BUTTON
        // ==========================================


        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(255, 210, 50);
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(255, 193, 7);
        }
        private Button btnRegister;

        private void BtnRegister_Click(
    object sender,
    EventArgs e)
        {
            RegisterForm registerForm =
                new RegisterForm();

            registerForm.ShowDialog();
        }



        // ==========================================
        // ĐĂNG NHẬP
        // ==========================================

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // ==============================
            // KIỂM TRA BỎ TRỐNG
            // ==============================

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

            // ==============================
            // KIỂM TRA TÀI KHOẢN TRONG MYSQL
            // ==============================

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    string sql = @"
                SELECT COUNT(*)
                FROM TaiKhoan
                WHERE TenDangNhap = @username
                AND MatKhau = @password
            ";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "Đăng nhập thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            MainForm mainForm = new MainForm();
                            mainForm.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Tên đăng nhập hoặc mật khẩu không đúng!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );

                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kết nối đến cơ sở dữ liệu!\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


    }
}