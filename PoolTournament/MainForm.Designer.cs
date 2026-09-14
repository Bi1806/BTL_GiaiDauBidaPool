namespace PoolTournament
{
    partial class MainForm
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
            pnlMenu = new Panel();
            btnStatistics = new Button();
            btnSchedule = new Button();
            btnTables = new Button();
            btnTournament = new Button();
            btnBracket = new Button();
            btnDraw = new Button();
            lblLogo = new Label();
            btnPlayers = new Button();
            pnlContent = new Panel();
            btnLogout = new Button();
            lblWelcome = new Label();
            pnlMenu.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnStatistics);
            pnlMenu.Controls.Add(btnSchedule);
            pnlMenu.Controls.Add(btnTables);
            pnlMenu.Controls.Add(btnTournament);
            pnlMenu.Controls.Add(btnBracket);
            pnlMenu.Controls.Add(btnDraw);
            pnlMenu.Controls.Add(lblLogo);
            pnlMenu.Controls.Add(btnPlayers);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(261, 653);
            pnlMenu.TabIndex = 0;
            // 
            // btnStatistics
            // 
            btnStatistics.Location = new Point(80, 465);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(94, 29);
            btnStatistics.TabIndex = 3;
            btnStatistics.Text = "Thống kê";
            btnStatistics.UseVisualStyleBackColor = true;
            // 
            // btnSchedule
            // 
            btnSchedule.Location = new Point(80, 264);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(94, 29);
            btnSchedule.TabIndex = 3;
            btnSchedule.Text = "Lịch thi đấu";
            btnSchedule.UseVisualStyleBackColor = true;
            // 
            // btnTables
            // 
            btnTables.Location = new Point(80, 398);
            btnTables.Name = "btnTables";
            btnTables.Size = new Size(94, 29);
            btnTables.TabIndex = 2;
            btnTables.Text = "Bàn đấu";
            btnTables.UseVisualStyleBackColor = true;
            // 
            // btnTournament
            // 
            btnTournament.Location = new Point(80, 81);
            btnTournament.Name = "btnTournament";
            btnTournament.Size = new Size(94, 29);
            btnTournament.TabIndex = 2;
            btnTournament.Text = "Giải đấu";
            btnTournament.UseVisualStyleBackColor = true;
            btnTournament.Click += btnTournament_Click;
            // 
            // btnBracket
            // 
            btnBracket.Location = new Point(80, 332);
            btnBracket.Name = "btnBracket";
            btnBracket.Size = new Size(94, 29);
            btnBracket.TabIndex = 1;
            btnBracket.Text = "Bracket";
            btnBracket.UseVisualStyleBackColor = true;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(80, 202);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(94, 29);
            btnDraw.TabIndex = 2;
            btnDraw.Text = "Bốc thăm";
            btnDraw.UseVisualStyleBackColor = true;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 14F);
            lblLogo.Location = new Point(12, 28);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(239, 32);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "POOL TOURNAMENT";
            // 
            // btnPlayers
            // 
            btnPlayers.Location = new Point(80, 140);
            btnPlayers.Name = "btnPlayers";
            btnPlayers.Size = new Size(94, 29);
            btnPlayers.TabIndex = 1;
            btnPlayers.Text = "Cơ thủ";
            btnPlayers.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(btnLogout);
            pnlContent.Controls.Add(lblWelcome);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1182, 653);
            pnlContent.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new Point(670, 140);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblWelcome.Location = new Point(300, 28);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(618, 46);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng đến với Pool Tournament";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(pnlMenu);
            Controls.Add(pnlContent);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POOL TOURNAMENT MANAGEMENT";
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Label lblLogo;
        private Button btnTournament;
        private Button btnSchedule;
        private Button btnTables;
        private Button btnBracket;
        private Button btnDraw;
        private Button btnPlayers;
        private Button btnStatistics;
        private Panel pnlContent;
        private Label lblWelcome;
        private Button btnLogout;
    }
}