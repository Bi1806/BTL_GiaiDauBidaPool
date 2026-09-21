using System.Drawing;
using System.Windows.Forms;

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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblLogo = new Label();
            lblWelcome = new Label();
            lblUser = new Label();
            pnlMenu = new Panel();

            btnTournament = new Button();
            btnPlayers = new Button();
            btnDraw = new Button();
            btnSchedule = new Button();
            btnBracket = new Button();
            btnTables = new Button();
            btnStatistics = new Button();
            btnLogout = new Button();

            pnlContent = new Panel();

            pnlHeader.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();

            // =====================================================
            // MAIN FORM
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(1250, 750);
            ForeColor = Color.White;

            MinimumSize = new Size(1100, 650);

            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POOL TOURNAMENT MANAGEMENT";

            // =====================================================
            // HEADER
            // =====================================================

            pnlHeader.BackColor = Color.FromArgb(20, 20, 20);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1250, 75);
            pnlHeader.TabIndex = 0;

            // -----------------------------------------------------
            // LOGO
            // -----------------------------------------------------

            lblLogo.AutoSize = true;
            lblLogo.Font = new Font(
                "Segoe UI",
                18F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );

            lblLogo.ForeColor = Color.Gold;

            lblLogo.Location = new Point(25, 20);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(230, 32);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🎱 POOL TOURNAMENT";

            // -----------------------------------------------------
            // WELCOME
            // -----------------------------------------------------

            lblUser.Anchor =
      AnchorStyles.Top |
      AnchorStyles.Right;

            lblUser.AutoSize = true;

            lblUser.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            lblUser.ForeColor =
                Color.FromArgb(210, 210, 210);

            lblUser.Location =
                new Point(940, 28);

            lblUser.Name =
                "lblUser";

            lblUser.Size =
                new Size(280, 19);

            lblUser.TabIndex = 1;

            lblUser.Text =
                "Xin chào, Nguyễn Trường Giang";

            pnlHeader.Controls.Add(lblUser);

            lblWelcome.AutoSize = true;

            lblWelcome.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );

            lblWelcome.ForeColor =
                Color.FromArgb(210, 210, 210);

            lblWelcome.Location =
                new Point(940, 28);

            lblWelcome.Name = "lblWelcome";

            lblWelcome.Size =
                new Size(280, 19);

            lblWelcome.TabIndex = 1;

            lblWelcome.Text =
                "Chào mừng đến với Pool Tournament";

            pnlHeader.Controls.Add(lblUser);
            pnlHeader.Controls.Add(lblLogo);

            // =====================================================
            // MENU
            // =====================================================

            pnlMenu.BackColor =
                Color.FromArgb(30, 30, 30);

            pnlMenu.Dock = DockStyle.Top;

            pnlMenu.Location =
                new Point(0, 75);

            pnlMenu.Name =
                "pnlMenu";

            pnlMenu.Size =
                new Size(1250, 65);

            pnlMenu.TabIndex = 1;

            // =====================================================
            // BUTTON GIẢI ĐẤU
            // =====================================================

            btnTournament.BackColor =
                Color.FromArgb(45, 45, 45);

            btnTournament.FlatAppearance.BorderColor =
                Color.FromArgb(70, 70, 70);

            btnTournament.FlatAppearance.BorderSize = 1;

            btnTournament.FlatStyle =
                FlatStyle.Flat;

            btnTournament.Font =
                new Font(
                    "Segoe UI Semibold",
                    9.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point
                );

            btnTournament.ForeColor =
                Color.White;

            btnTournament.Location =
                new Point(15, 13);

            btnTournament.Name =
                "btnTournament";

            btnTournament.Size =
                new Size(140, 40);

            btnTournament.TabIndex = 0;

            btnTournament.Text =
                "🏆  GIẢI ĐẤU";

            btnTournament.UseVisualStyleBackColor =
                false;

            btnTournament.Click +=
                btnTournament_Click;

            // =====================================================
            // BUTTON CƠ THỦ
            // =====================================================

            btnPlayers.BackColor =
                Color.FromArgb(45, 45, 45);

            btnPlayers.FlatAppearance.BorderColor =
                Color.FromArgb(70, 70, 70);

            btnPlayers.FlatAppearance.BorderSize = 1;

            btnPlayers.FlatStyle =
                FlatStyle.Flat;

            btnPlayers.Font =
                new Font(
                    "Segoe UI Semibold",
                    9.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point
                );

            btnPlayers.ForeColor =
                Color.White;

            btnPlayers.Location =
                new Point(160, 13);

            btnPlayers.Name =
                "btnPlayers";

            btnPlayers.Size =
                new Size(140, 40);

            btnPlayers.TabIndex = 1;

            btnPlayers.Text =
                "👤  CƠ THỦ";

            btnPlayers.UseVisualStyleBackColor =
                false;

            btnPlayers.Click +=
                btnPlayers_Click;

            // =====================================================
            // BUTTON BỐC THĂM
            // =====================================================

            btnDraw.BackColor =
                Color.FromArgb(45, 45, 45);

            btnDraw.FlatAppearance.BorderColor =
                Color.FromArgb(70, 70, 70);

            btnDraw.FlatAppearance.BorderSize = 1;

            btnDraw.FlatStyle =
                FlatStyle.Flat;

            btnDraw.Font =
                new Font(
                    "Segoe UI Semibold",
                    9.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point
                );

            btnDraw.ForeColor =
                Color.White;

            btnDraw.Location =
                new Point(305, 13);

            btnDraw.Name =
                "btnDraw";

            btnDraw.Size =
                new Size(140, 40);

            btnDraw.TabIndex = 2;

            btnDraw.Text =
                "🎱  BỐC THĂM";

            btnDraw.UseVisualStyleBackColor =
                false;

            btnDraw.Click +=
                btnDraw_Click;

            // =====================================================
            // BUTTON LỊCH THI ĐẤU
            // =====================================================

            btnSchedule.BackColor =
                Color.FromArgb(45, 45, 45);

            btnSchedule.FlatAppearance.BorderColor =
                Color.FromArgb(70, 70, 70);

            btnSchedule.FlatAppearance.BorderSize = 1;

            btnSchedule.FlatStyle =
                FlatStyle.Flat;

            btnSchedule.Font =
                new Font(
                    "Segoe UI Semibold",
                    9.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point
                );

            btnSchedule.ForeColor =
                Color.White;

            btnSchedule.Location =
                new Point(450, 13);

            btnSchedule.Name =
                "btnSchedule";

            btnSchedule.Size =
                new Size(140, 40);

            btnSchedule.TabIndex = 3;

            btnSchedule.Text =
                "📅  LỊCH THI ĐẤU";

            btnSchedule.UseVisualStyleBackColor =
                false;

            // =====================================================
            // BUTTON BRACKET
            // =====================================================

            btnBracket.BackColor =
                Color.FromArgb(45, 45, 45);

            btnBracket.FlatAppearance.BorderColor =
                Color.FromArgb(70, 70, 70);

            btnBracket.FlatAppearance.BorderSize = 1;

            btnBracket.FlatStyle =
                FlatStyle.Flat;

            btnBracket.Font =
                new Font(
                    "Segoe UI Semibold",
                    9.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point
                );

            btnBracket.ForeColor =
                Color.White;

            btnBracket.Location =
                new Point(595, 13);

            btnBracket.Name =
                "btnBracket";

            btnBracket.Size =
                new Size(140, 40);

            btnBracket.TabIndex = 4;

            btnBracket.Text =
                "🏅  BRACKET";

            btnBracket.UseVisualStyleBackColor =
                false;

            // =====================================================
            // BUTTON BÀN ĐẤU
            // =====================================================

            btnTables.BackColor =
                Color.FromArgb(45, 45, 45);

            btnTables.FlatAppearance.BorderColor =
                Color.FromArgb(70, 70, 70);

            btnTables.FlatAppearance.BorderSize = 1;

            btnTables.FlatStyle =
                FlatStyle.Flat;

            btnTables.Font =
                new Font(
                    "Segoe UI Semibold",
                    9.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point
                );

            btnTables.ForeColor =
                Color.White;

            btnTables.Location =
                new Point(740, 13);

            btnTables.Name =
                "btnTables";

            btnTables.Size =
                new Size(140, 40);

            btnTables.TabIndex = 5;

            btnTables.Text =
                "🎱  BÀN ĐẤU";

            btnTables.UseVisualStyleBackColor =
                false;

            // =====================================================
            // BUTTON THỐNG KÊ
            // =====================================================

            btnStatistics.BackColor =
                Color.FromArgb(45, 45, 45);

            btnStatistics.FlatAppearance.BorderColor =
                Color.FromArgb(70, 70, 70);

            btnStatistics.FlatAppearance.BorderSize = 1;

            btnStatistics.FlatStyle =
                FlatStyle.Flat;

            btnStatistics.Font =
                new Font(
                    "Segoe UI Semibold",
                    9.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point
                );

            btnStatistics.ForeColor =
                Color.White;

            btnStatistics.Location =
                new Point(885, 13);

            btnStatistics.Name =
                "btnStatistics";

            btnStatistics.Size =
                new Size(140, 40);

            btnStatistics.TabIndex = 6;

            btnStatistics.Text =
                "📊  THỐNG KÊ";

            btnStatistics.UseVisualStyleBackColor =
                false;

            // =====================================================
            // BUTTON ĐĂNG XUẤT
            // =====================================================

            btnLogout.BackColor =
                Color.FromArgb(45, 45, 45);

            btnLogout.FlatAppearance.BorderColor =
                Color.FromArgb(120, 70, 70);

            btnLogout.FlatAppearance.BorderSize = 1;

            btnLogout.FlatStyle =
                FlatStyle.Flat;

            btnLogout.Font =
                new Font(
                    "Segoe UI Semibold",
                    9.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point
                );

            btnLogout.ForeColor =
                Color.FromArgb(255, 120, 120);

            btnLogout.Location =
                new Point(1030, 13);

            btnLogout.Name =
                "btnLogout";

            btnLogout.Size =
                new Size(140, 40);

            btnLogout.TabIndex = 7;

            btnLogout.Text =
                "🚪  ĐĂNG XUẤT";

            btnLogout.UseVisualStyleBackColor =
                false;

            btnLogout.Click +=
                btnLogout_Click;

            // =====================================================
            // ADD BUTTONS TO MENU
            // =====================================================

            pnlMenu.Controls.Add(btnTournament);
            pnlMenu.Controls.Add(btnPlayers);
            pnlMenu.Controls.Add(btnDraw);
            pnlMenu.Controls.Add(btnSchedule);
            pnlMenu.Controls.Add(btnBracket);
            pnlMenu.Controls.Add(btnTables);
            pnlMenu.Controls.Add(btnStatistics);
            pnlMenu.Controls.Add(btnLogout);

            // =====================================================
            // CONTENT PANEL
            // =====================================================

            pnlContent.BackColor =
                Color.FromArgb(15, 15, 15);

            pnlContent.Dock =
                DockStyle.Fill;

            pnlContent.Location =
                new Point(0, 140);

            pnlContent.Name =
                "pnlContent";

            pnlContent.Size =
                new Size(1250, 610);

            pnlContent.TabIndex = 2;

            // -----------------------------------------------------
            // WELCOME TEXT
            // -----------------------------------------------------

            lblWelcome = new Label();

            lblWelcome.AutoSize = true;

            lblWelcome.Font =
                new Font(
                    "Segoe UI",
                    22F,
                    FontStyle.Bold,
                    GraphicsUnit.Point
                );

            lblWelcome.ForeColor =
                Color.Gold;

            lblWelcome.Location =
                new Point(40, 40);

            lblWelcome.Name =
                "lblWelcome";

            lblWelcome.Size =
                new Size(500, 40);

            lblWelcome.TabIndex = 0;

            lblWelcome.Text =
                "Chào mừng đến với Pool Tournament";

            pnlContent.Controls.Add(lblWelcome);

            // =====================================================
            // ADD MAIN PANELS
            // =====================================================

            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Controls.Add(pnlHeader);

            // =====================================================
            // RESUME
            // =====================================================

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlMenu.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();

            ResumeLayout(false);
        }

        #endregion

        // =========================================================
        // CONTROLS
        // =========================================================

        private Panel pnlHeader;
        private Panel pnlMenu;
        private Panel pnlContent;

        private Label lblLogo;
        private Label lblWelcome;
        private Label lblUser;

        private Button btnTournament;
        private Button btnPlayers;
        private Button btnDraw;
        private Button btnSchedule;
        private Button btnBracket;
        private Button btnTables;
        private Button btnStatistics;
        private Button btnLogout;
    }
}