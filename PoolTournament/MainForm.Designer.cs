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
            pnlMenu.Margin = new Padding(4, 4, 4, 4);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(326, 816);
            pnlMenu.TabIndex = 0;
            // 
            // btnStatistics
            // 
            btnStatistics.Location = new Point(100, 581);
            btnStatistics.Margin = new Padding(4, 4, 4, 4);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(118, 36);
            btnStatistics.TabIndex = 3;
            btnStatistics.Text = "Thống kê";
            btnStatistics.UseVisualStyleBackColor = true;
            // 
            // btnSchedule
            // 
            btnSchedule.Location = new Point(100, 330);
            btnSchedule.Margin = new Padding(4, 4, 4, 4);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(118, 36);
            btnSchedule.TabIndex = 3;
            btnSchedule.Text = "Lịch thi đấu";
            btnSchedule.UseVisualStyleBackColor = true;
            // 
            // btnTables
            // 
            btnTables.Location = new Point(100, 498);
            btnTables.Margin = new Padding(4, 4, 4, 4);
            btnTables.Name = "btnTables";
            btnTables.Size = new Size(118, 36);
            btnTables.TabIndex = 2;
            btnTables.Text = "Bàn đấu";
            btnTables.UseVisualStyleBackColor = true;
            // 
            // btnTournament
            // 
            btnTournament.Location = new Point(100, 101);
            btnTournament.Margin = new Padding(4, 4, 4, 4);
            btnTournament.Name = "btnTournament";
            btnTournament.Size = new Size(118, 36);
            btnTournament.TabIndex = 2;
            btnTournament.Text = "Giải đấu";
            btnTournament.UseVisualStyleBackColor = true;
            btnTournament.Click += btnTournament_Click;
            // 
            // btnBracket
            // 
            btnBracket.Location = new Point(100, 415);
            btnBracket.Margin = new Padding(4, 4, 4, 4);
            btnBracket.Name = "btnBracket";
            btnBracket.Size = new Size(118, 36);
            btnBracket.TabIndex = 1;
            btnBracket.Text = "Bracket";
            btnBracket.UseVisualStyleBackColor = true;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(100, 252);
            btnDraw.Margin = new Padding(4, 4, 4, 4);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(118, 36);
            btnDraw.TabIndex = 2;
            btnDraw.Text = "Bốc thăm";
            btnDraw.UseVisualStyleBackColor = true;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 14F);
            lblLogo.Location = new Point(15, 35);
            lblLogo.Margin = new Padding(4, 0, 4, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(281, 38);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "POOL TOURNAMENT";
            // 
            // btnPlayers
            // 
            btnPlayers.Location = new Point(100, 175);
            btnPlayers.Margin = new Padding(4, 4, 4, 4);
            btnPlayers.Name = "btnPlayers";
            btnPlayers.Size = new Size(118, 36);
            btnPlayers.TabIndex = 1;
            btnPlayers.Text = "Cơ thủ";
            btnPlayers.UseVisualStyleBackColor = true;
            btnPlayers.Click += btnPlayers_Click;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(btnLogout);
            pnlContent.Controls.Add(lblWelcome);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 0);
            pnlContent.Margin = new Padding(4, 4, 4, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1478, 816);
            pnlContent.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.Location = new Point(838, 175);
            btnLogout.Margin = new Padding(4, 4, 4, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(118, 36);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblWelcome.Location = new Point(375, 35);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(726, 54);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng đến với Pool Tournament";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1478, 816);
            Controls.Add(pnlMenu);
            Controls.Add(pnlContent);
            Margin = new Padding(4, 4, 4, 4);
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