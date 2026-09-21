using System.Drawing;
using System.Windows.Forms;

namespace PoolTournament.Forms
{
    partial class DrawForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel pnlTournament;
        private Label lblTournament;
        private TextBox txtTournamentName;

      

        private Panel pnlPlayers;
        private Label lblPlayerList;
        private Label lblPlayerCount;
        private ListBox lstPlayers;

        private Panel pnlResult;
        private Label lblResult;
        private ListBox lstResult;

        private Button btnDraw;
        private Button btnRedraw;
        private Button btnClear;

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
            lblTitle = new Label();
            lblSubtitle = new Label();

            pnlTournament = new Panel();
            lblTournament = new Label();
            txtTournamentName = new TextBox();

            

            pnlPlayers = new Panel();
            lblPlayerList = new Label();
            lblPlayerCount = new Label();
            lstPlayers = new ListBox();
       

            pnlResult = new Panel();
            lblResult = new Label();
            lstResult = new ListBox();

            btnDraw = new Button();
            btnRedraw = new Button();
            btnClear = new Button();

            pnlHeader.SuspendLayout();
            pnlTournament.SuspendLayout();
            pnlPlayers.SuspendLayout();
            pnlResult.SuspendLayout();
            SuspendLayout();

            // =========================
            // FORM
            // =========================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(1100, 700);
            ForeColor = Color.White;
            MinimumSize = new Size(1000, 650);
            Name = "DrawForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POOL TOURNAMENT - Bốc thăm";

            // =========================
            // HEADER
            // =========================

            pnlHeader.BackColor = Color.FromArgb(25, 25, 25);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 105);
            pnlHeader.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font(
                "Segoe UI",
                24F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblTitle.ForeColor = Color.Gold;
            lblTitle.Location = new Point(35, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(340, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BỐC THĂM GIẢI ĐẤU";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lblSubtitle.ForeColor = Color.FromArgb(180, 180, 180);
            lblSubtitle.Location = new Point(39, 66);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(350, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Thiết lập giải đấu và chia cặp thi đấu ngẫu nhiên";

            // =========================
            // TOURNAMENT PANEL
            // =========================

            pnlTournament.BackColor = Color.FromArgb(25, 25, 25);
            pnlTournament.Controls.Add(lblTournament);
            pnlTournament.Controls.Add(txtTournamentName);
            pnlTournament.Location = new Point(35, 130);
            pnlTournament.Name = "pnlTournament";
            pnlTournament.Size = new Size(1030, 70);
            pnlTournament.TabIndex = 1;

            lblTournament.AutoSize = true;
            lblTournament.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblTournament.ForeColor = Color.White;
            lblTournament.Location = new Point(20, 24);
            lblTournament.Name = "lblTournament";
            lblTournament.Size = new Size(85, 19);
            lblTournament.TabIndex = 0;
            lblTournament.Text = "Tên giải đấu:";

            txtTournamentName.BackColor = Color.FromArgb(40, 40, 40);
            txtTournamentName.BorderStyle = BorderStyle.FixedSingle;
            txtTournamentName.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            txtTournamentName.ForeColor = Color.White;
            txtTournamentName.Location = new Point(125, 20);
            txtTournamentName.Name = "txtTournamentName";
            txtTournamentName.Size = new Size(450, 25);
            txtTournamentName.TabIndex = 1;


          

            // =========================
            // PLAYERS PANEL
            // =========================

            pnlPlayers.BackColor = Color.FromArgb(25, 25, 25);
            pnlPlayers.Controls.Add(lblPlayerList);
            pnlPlayers.Controls.Add(lblPlayerCount);
            pnlPlayers.Controls.Add(lstPlayers);
            pnlPlayers.Location = new Point(35, 265);
            pnlPlayers.Name = "pnlPlayers";
            pnlPlayers.Size = new Size(490, 330);
            pnlPlayers.TabIndex = 5;

            lblPlayerList.AutoSize = true;
            lblPlayerList.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblPlayerList.ForeColor = Color.Gold;
            lblPlayerList.Location = new Point(20, 18);
            lblPlayerList.Name = "lblPlayerList";
            lblPlayerList.Size = new Size(190, 21);
            lblPlayerList.TabIndex = 0;
            lblPlayerList.Text = "DANH SÁCH CƠ THỦ";

            lblPlayerCount.AutoSize = true;
            lblPlayerCount.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lblPlayerCount.ForeColor = Color.FromArgb(170, 170, 170);
            lblPlayerCount.Location = new Point(20, 47);
            lblPlayerCount.Name = "lblPlayerCount";
            lblPlayerCount.Size = new Size(100, 15);
            lblPlayerCount.TabIndex = 1;
            lblPlayerCount.Text = "Số người chơi: 0";

            lstPlayers.BackColor = Color.FromArgb(35, 35, 35);
            lstPlayers.BorderStyle = BorderStyle.FixedSingle;
            lstPlayers.Font = new Font(
                "Segoe UI",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lstPlayers.ForeColor = Color.White;
            lstPlayers.FormattingEnabled = true;
            lstPlayers.ItemHeight = 25;
            lstPlayers.Location = new Point(20, 75);
            lstPlayers.Name = "lstPlayers";
            lstPlayers.Size = new Size(450, 180);
            lstPlayers.TabIndex = 2;

           

            // =========================
            // RESULT PANEL
            // =========================

            pnlResult.BackColor = Color.FromArgb(25, 25, 25);
            pnlResult.Controls.Add(lblResult);
            pnlResult.Controls.Add(lstResult);
            pnlResult.Location = new Point(545, 265);
            pnlResult.Name = "pnlResult";
            pnlResult.Size = new Size(520, 330);
            pnlResult.TabIndex = 6;

            lblResult.AutoSize = true;
            lblResult.Font = new Font(
                "Segoe UI",
                12F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            lblResult.ForeColor = Color.Gold;
            lblResult.Location = new Point(20, 18);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(185, 21);
            lblResult.TabIndex = 0;
            lblResult.Text = "KẾT QUẢ BỐC THĂM";

            lstResult.BackColor = Color.FromArgb(35, 35, 35);
            lstResult.BorderStyle = BorderStyle.FixedSingle;
            lstResult.Font = new Font(
                "Consolas",
                10F,
                FontStyle.Regular,
                GraphicsUnit.Point
            );
            lstResult.ForeColor = Color.White;
            lstResult.FormattingEnabled = true;
            lstResult.ItemHeight = 22;
            lstResult.Location = new Point(20, 55);
            lstResult.Name = "lstResult";
            lstResult.Size = new Size(480, 250);
            lstResult.TabIndex = 1;

            // =========================
            // ACTION BUTTONS
            // =========================

            btnDraw.BackColor = Color.Gold;
            btnDraw.FlatAppearance.BorderSize = 0;
            btnDraw.FlatStyle = FlatStyle.Flat;
            btnDraw.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            btnDraw.ForeColor = Color.Black;
            btnDraw.Location = new Point(600, 615);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(145, 40);
            btnDraw.TabIndex = 7;
            btnDraw.Text = "🎱  BỐC THĂM";
            btnDraw.UseVisualStyleBackColor = false;
            btnDraw.Click += btnDraw_Click;

            btnRedraw.BackColor = Color.FromArgb(55, 55, 55);
            btnRedraw.FlatAppearance.BorderColor = Color.Gold;
            btnRedraw.FlatAppearance.BorderSize = 1;
            btnRedraw.FlatStyle = FlatStyle.Flat;
            btnRedraw.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            btnRedraw.ForeColor = Color.Gold;
            btnRedraw.Location = new Point(760, 615);
            btnRedraw.Name = "btnRedraw";
            btnRedraw.Size = new Size(145, 40);
            btnRedraw.TabIndex = 8;
            btnRedraw.Text = "↻  BỐC LẠI";
            btnRedraw.UseVisualStyleBackColor = false;
            btnRedraw.Click += btnRedraw_Click;

            btnClear.BackColor = Color.FromArgb(55, 55, 55);
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(120, 120, 120);
            btnClear.FlatAppearance.BorderSize = 1;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point
            );
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(920, 615);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(145, 40);
            btnClear.TabIndex = 9;
            btnClear.Text = "↻  TẢI LẠI";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;

            // =========================
            // ADD CONTROLS
            // =========================

            Controls.Add(pnlHeader);
            Controls.Add(pnlTournament);
          
            Controls.Add(pnlPlayers);
            Controls.Add(pnlResult);
            Controls.Add(btnDraw);
            Controls.Add(btnRedraw);
            Controls.Add(btnClear);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            pnlTournament.ResumeLayout(false);
            pnlTournament.PerformLayout();

            pnlPlayers.ResumeLayout(false);
            pnlPlayers.PerformLayout();

            pnlResult.ResumeLayout(false);
            pnlResult.PerformLayout();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}