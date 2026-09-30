namespace PoolTournament.Forms
{
    partial class ForgotPasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlForgotPassword = new Panel();
            btnResetPassword = new Button();
            txtConfirmPassword = new TextBox();
            label2 = new Label();
            txtNewPassword = new TextBox();
            lblMatKhauMoi = new Label();
            btnVerifyOTP = new Button();
            txtOTP = new TextBox();
            lblOTP = new Label();
            lblTimer = new Label();
            btnSendOTP = new Button();
            txtEmail = new TextBox();
            lblUsername = new Label();
            pnllblQuenMatKhau = new Panel();
            pnlForgotPassword.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.FromArgb(30, 30, 30);
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Gold;
            lblTitle.Location = new Point(107, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(245, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUÊN MẬT KHẨU";
            // 
            // pnlForgotPassword
            // 
            pnlForgotPassword.BackColor = Color.FromArgb(30, 30, 30);
            pnlForgotPassword.Controls.Add(btnResetPassword);
            pnlForgotPassword.Controls.Add(txtConfirmPassword);
            pnlForgotPassword.Controls.Add(label2);
            pnlForgotPassword.Controls.Add(txtNewPassword);
            pnlForgotPassword.Controls.Add(lblMatKhauMoi);
            pnlForgotPassword.Controls.Add(btnVerifyOTP);
            pnlForgotPassword.Controls.Add(txtOTP);
            pnlForgotPassword.Controls.Add(lblOTP);
            pnlForgotPassword.Controls.Add(lblTimer);
            pnlForgotPassword.Controls.Add(btnSendOTP);
            pnlForgotPassword.Controls.Add(txtEmail);
            pnlForgotPassword.Controls.Add(lblUsername);
            pnlForgotPassword.Location = new Point(39, 75);
            pnlForgotPassword.Margin = new Padding(3, 2, 3, 2);
            pnlForgotPassword.Name = "pnlForgotPassword";
            pnlForgotPassword.Size = new Size(425, 298);
            pnlForgotPassword.TabIndex = 7;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.Gold;
            btnResetPassword.Cursor = Cursors.Hand;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatAppearance.MouseDownBackColor = SystemColors.ButtonHighlight;
            btnResetPassword.FlatAppearance.MouseOverBackColor = SystemColors.ButtonHighlight;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnResetPassword.ForeColor = SystemColors.ActiveCaptionText;
            btnResetPassword.Location = new Point(68, 258);
            btnResetPassword.Margin = new Padding(3, 2, 3, 2);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(245, 30);
            btnResetPassword.TabIndex = 11;
            btnResetPassword.Text = "Đổi mật khẩu";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(30, 30, 30);
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 10.8F);
            txtConfirmPassword.ForeColor = Color.Black;
            txtConfirmPassword.Location = new Point(168, 214);
            txtConfirmPassword.Margin = new Padding(3, 2, 3, 2);
            txtConfirmPassword.Multiline = true;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(245, 27);
            txtConfirmPassword.TabIndex = 10;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.KeyDown += txtConfirmPassword_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(21, 219);
            label2.Name = "label2";
            label2.Size = new Size(133, 15);
            label2.TabIndex = 9;
            label2.Text = "Xác nhận mật khẩu mới";
            // 
            // txtNewPassword
            // 
            txtNewPassword.BackColor = Color.FromArgb(30, 30, 30);
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Segoe UI", 10.8F);
            txtNewPassword.ForeColor = Color.Black;
            txtNewPassword.Location = new Point(168, 167);
            txtNewPassword.Margin = new Padding(3, 2, 3, 2);
            txtNewPassword.Multiline = true;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(245, 27);
            txtNewPassword.TabIndex = 8;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.KeyDown += txtNewPassword_KeyDown;
            // 
            // lblMatKhauMoi
            // 
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.ForeColor = Color.Gold;
            lblMatKhauMoi.Location = new Point(21, 175);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(81, 15);
            lblMatKhauMoi.TabIndex = 7;
            lblMatKhauMoi.Text = "Mật khẩu mới";
            // 
            // btnVerifyOTP
            // 
            btnVerifyOTP.BackColor = Color.Gold;
            btnVerifyOTP.Cursor = Cursors.Hand;
            btnVerifyOTP.FlatAppearance.BorderSize = 0;
            btnVerifyOTP.FlatAppearance.MouseDownBackColor = SystemColors.ButtonHighlight;
            btnVerifyOTP.FlatAppearance.MouseOverBackColor = SystemColors.ButtonHighlight;
            btnVerifyOTP.FlatStyle = FlatStyle.Flat;
            btnVerifyOTP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVerifyOTP.ForeColor = SystemColors.WindowText;
            btnVerifyOTP.Location = new Point(68, 121);
            btnVerifyOTP.Margin = new Padding(3, 2, 3, 2);
            btnVerifyOTP.Name = "btnVerifyOTP";
            btnVerifyOTP.Size = new Size(245, 30);
            btnVerifyOTP.TabIndex = 6;
            btnVerifyOTP.Text = "Xác nhận OTP";
            btnVerifyOTP.UseVisualStyleBackColor = false;
            btnVerifyOTP.Click += btnVerifyOTP_Click;
            // 
            // txtOTP
            // 
            txtOTP.BackColor = Color.FromArgb(30, 30, 30);
            txtOTP.BorderStyle = BorderStyle.FixedSingle;
            txtOTP.Font = new Font("Segoe UI", 10.8F);
            txtOTP.ForeColor = Color.Black;
            txtOTP.Location = new Point(168, 83);
            txtOTP.Margin = new Padding(3, 2, 3, 2);
            txtOTP.MaxLength = 6;
            txtOTP.Name = "txtOTP";
            txtOTP.PlaceholderText = "Nhập mã 6 chữ số ...";
            txtOTP.Size = new Size(245, 27);
            txtOTP.TabIndex = 5;
            txtOTP.KeyDown += txtOTP_KeyDown;
            // 
            // lblOTP
            // 
            lblOTP.AutoSize = true;
            lblOTP.ForeColor = Color.Gold;
            lblOTP.Location = new Point(21, 88);
            lblOTP.Name = "lblOTP";
            lblOTP.Size = new Size(131, 15);
            lblOTP.TabIndex = 4;
            lblOTP.Text = "Mã xác thực OTP (6 số):";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.ForeColor = Color.Gold;
            lblTimer.Location = new Point(243, 55);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(34, 15);
            lblTimer.TabIndex = 3;
            lblTimer.Text = "05:00";
            // 
            // btnSendOTP
            // 
            btnSendOTP.BackColor = Color.Gold;
            btnSendOTP.Cursor = Cursors.Hand;
            btnSendOTP.FlatAppearance.BorderSize = 0;
            btnSendOTP.FlatAppearance.MouseDownBackColor = SystemColors.ButtonHighlight;
            btnSendOTP.FlatAppearance.MouseOverBackColor = SystemColors.ButtonHighlight;
            btnSendOTP.FlatStyle = FlatStyle.Flat;
            btnSendOTP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSendOTP.ForeColor = SystemColors.WindowText;
            btnSendOTP.Location = new Point(21, 46);
            btnSendOTP.Margin = new Padding(3, 2, 3, 2);
            btnSendOTP.Name = "btnSendOTP";
            btnSendOTP.Size = new Size(204, 30);
            btnSendOTP.TabIndex = 2;
            btnSendOTP.Text = "Gửi mã OTP";
            btnSendOTP.UseVisualStyleBackColor = false;
            btnSendOTP.Click += btnSendOTP_Click;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(30, 30, 30);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10.8F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(168, 15);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Nhập email tài khoản của bạn ...";
            txtEmail.Size = new Size(245, 23);
            txtEmail.TabIndex = 1;
            txtEmail.KeyDown += txtEmail_KeyDown;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.FromArgb(30, 30, 30);
            lblUsername.ForeColor = Color.Gold;
            lblUsername.Location = new Point(21, 20);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(81, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Email đăng ký";
            // 
            // pnllblQuenMatKhau
            // 
            pnllblQuenMatKhau.BackColor = Color.FromArgb(30, 30, 30);
            pnllblQuenMatKhau.Location = new Point(39, 12);
            pnllblQuenMatKhau.Name = "pnllblQuenMatKhau";
            pnllblQuenMatKhau.Size = new Size(425, 73);
            pnllblQuenMatKhau.TabIndex = 8;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 420);
            Controls.Add(lblTitle);
            Controls.Add(pnlForgotPassword);
            Controls.Add(pnllblQuenMatKhau);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khôi phục Mật khẩu";
            pnlForgotPassword.ResumeLayout(false);
            pnlForgotPassword.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlForgotPassword;
        private TextBox txtEmail;
        private Label lblUsername;
        private Button btnSendOTP;
        private TextBox txtOTP;
        private Label lblOTP;
        private Label lblTimer;
        private Label label2;
        private TextBox txtNewPassword;
        private Label lblMatKhauMoi;
        private Button btnVerifyOTP;
        private TextBox txtConfirmPassword;
        private Button btnResetPassword;
        private Panel pnllblQuenMatKhau;
    }
}