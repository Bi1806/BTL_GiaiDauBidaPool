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
            lblSubtitle = new Label();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(169, 41);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(391, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "POOL TOURNAMENT";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.ForeColor = Color.Black;
            lblUsername.Location = new Point(24, 45);
            lblUsername.Name = "lblUsername";
            lblUsername.RightToLeft = RightToLeft.No;
            lblUsername.Size = new Size(110, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(24, 136);
            lblPassword.Name = "lblPassword";
            lblPassword.RightToLeft = RightToLeft.No;
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.WhiteSmoke;
            txtUsername.Location = new Point(36, 87);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 31);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.WhiteSmoke;
            txtPassword.Location = new Point(36, 170);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(280, 31);
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
            btnLogin.Location = new Point(36, 234);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(280, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(lblUsername);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Location = new Point(180, 175);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(380, 300);
            pnlLogin.TabIndex = 6;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.BorderStyle = BorderStyle.FixedSingle;
            lblSubtitle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(240, 110);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(259, 25);
            lblSubtitle.TabIndex = 7;
            lblSubtitle.Text = "HỆ THỐNG QUẢN LÝ GIẢI ĐẤU";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(896, 526);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Controls.Add(pnlLogin);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
    }
}
