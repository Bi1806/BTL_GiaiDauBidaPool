namespace PoolTournament
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            pnlLogin = new Panel();
            btnForgotPassword = new Button();
            lblSubtitle = new Label();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(148, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(319, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "POOL TOURNAMENT";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = Color.Black;
            lblUsername.Location = new Point(21, 34);
            lblUsername.Name = "lblUsername";
            lblUsername.RightToLeft = RightToLeft.No;
            lblUsername.Size = new Size(89, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(21, 102);
            lblPassword.Name = "lblPassword";
            lblPassword.RightToLeft = RightToLeft.No;
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.WhiteSmoke;
            txtUsername.Location = new Point(32, 65);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(245, 27);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.WhiteSmoke;
            txtPassword.Location = new Point(32, 128);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(245, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 193, 7);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(32, 190);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(245, 30);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(btnForgotPassword);
            pnlLogin.Controls.Add(lblUsername);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Location = new Point(158, 131);
            pnlLogin.Margin = new Padding(3, 2, 3, 2);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(332, 241);
            pnlLogin.TabIndex = 6;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.BackColor = Color.Transparent;
            btnForgotPassword.FlatAppearance.BorderSize = 0;
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            btnForgotPassword.ForeColor = Color.FromArgb(255, 193, 7);
            btnForgotPassword.Location = new Point(164, 162);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(165, 23);
            btnForgotPassword.TabIndex = 6;
            btnForgotPassword.Text = "Quên mật khẩu";
            btnForgotPassword.UseVisualStyleBackColor = false;
            btnForgotPassword.Click += btnForgotPassword_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.BorderStyle = BorderStyle.FixedSingle;
            lblSubtitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(210, 82);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(215, 21);
            lblSubtitle.TabIndex = 7;
            lblSubtitle.Text = "HỆ THỐNG QUẢN LÝ GIẢI ĐẤU";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 394);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Controls.Add(pnlLogin);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POOL TOURNAMENT";
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Panel pnlLogin;
        private Label lblSubtitle;
        private Button btnForgotPassword;
    }
}
