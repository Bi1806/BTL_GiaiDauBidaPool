namespace PoolTournament
{
    partial class PlayerForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gbPlayerInfo = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblRank = new System.Windows.Forms.Label();
            this.cbRankLevel = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.btnChooseAvatar = new System.Windows.Forms.Button();
            this.txtAvatarUrl = new System.Windows.Forms.TextBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.gbTournaments = new System.Windows.Forms.GroupBox();
            this.lblTotalTournaments = new System.Windows.Forms.Label();
            this.dgvTournaments = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbPlayerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.gbTournaments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournaments)).BeginInit();
            this.SuspendLayout();

            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitContainer.SplitterDistance = 850;
            this.splitContainer.Size = new System.Drawing.Size(1360, 750);
            this.splitContainer.TabIndex = 0;
            this.splitContainer.Panel1.Controls.Add(this.dgvPlayers);
            this.splitContainer.Panel1.Controls.Add(this.gbPlayerInfo);
            this.splitContainer.Panel2.Controls.Add(this.gbTournaments);

            // 
            // gbPlayerInfo
            // 
            this.gbPlayerInfo.Controls.Add(this.lblName);
            this.gbPlayerInfo.Controls.Add(this.txtFullName);
            this.gbPlayerInfo.Controls.Add(this.lblRank);
            this.gbPlayerInfo.Controls.Add(this.cbRankLevel);
            this.gbPlayerInfo.Controls.Add(this.lblPhone);
            this.gbPlayerInfo.Controls.Add(this.txtPhone);
            this.gbPlayerInfo.Controls.Add(this.lblStatus);
            this.gbPlayerInfo.Controls.Add(this.cbStatus);
            this.gbPlayerInfo.Controls.Add(this.lblEmail);
            this.gbPlayerInfo.Controls.Add(this.txtEmail);
            this.gbPlayerInfo.Controls.Add(this.lblAvatar);
            this.gbPlayerInfo.Controls.Add(this.btnChooseAvatar);
            this.gbPlayerInfo.Controls.Add(this.txtAvatarUrl);
            this.gbPlayerInfo.Controls.Add(this.picAvatar);
            this.gbPlayerInfo.Controls.Add(this.btnAdd);
            this.gbPlayerInfo.Controls.Add(this.btnUpdate);
            this.gbPlayerInfo.Controls.Add(this.btnClear);
            this.gbPlayerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPlayerInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbPlayerInfo.Height = 220;
            this.gbPlayerInfo.Location = new System.Drawing.Point(0, 0);
            this.gbPlayerInfo.Name = "gbPlayerInfo";
            this.gbPlayerInfo.Padding = new System.Windows.Forms.Padding(10);
            this.gbPlayerInfo.Size = new System.Drawing.Size(850, 220);
            this.gbPlayerInfo.TabIndex = 0;
            this.gbPlayerInfo.TabStop = false;
            this.gbPlayerInfo.Text = "Thông tin chi tiết Cơ thủ";

            // lblName & txtFullName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 21);
            this.lblName.Text = "Họ và tên:";

            this.txtFullName.Location = new System.Drawing.Point(125, 28);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(200, 29);

            // lblRank & cbRankLevel
            this.lblRank.AutoSize = true;
            this.lblRank.Location = new System.Drawing.Point(345, 32);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(97, 21);
            this.lblRank.Text = "Hạng (Rank):";

            this.cbRankLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRankLevel.FormattingEnabled = true;
            this.cbRankLevel.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "Chuyên nghiệp", "Nghiệp dư" });
            this.cbRankLevel.Location = new System.Drawing.Point(450, 28);
            this.cbRankLevel.Name = "cbRankLevel";
            this.cbRankLevel.Size = new System.Drawing.Size(210, 29);

            // lblPhone & txtPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 75);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(104, 21);
            this.lblPhone.Text = "Số điện thoại:";

            this.txtPhone.Location = new System.Drawing.Point(125, 71);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 29);

            // lblStatus & cbStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(345, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 21);
            this.lblStatus.Text = "Trạng thái:";

            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] { "active", "suspended", "inactive" });
            this.cbStatus.Location = new System.Drawing.Point(450, 71);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(210, 29);

            // lblEmail & txtEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 118);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(51, 21);
            this.lblEmail.Text = "Email:";

            this.txtEmail.Location = new System.Drawing.Point(125, 114);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 29);

            // lblAvatar, btnChooseAvatar & txtAvatarUrl
            this.lblAvatar.AutoSize = true;
            this.lblAvatar.Location = new System.Drawing.Point(345, 118);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(98, 21);
            this.lblAvatar.Text = "Ảnh đại diện:";

            this.btnChooseAvatar.Location = new System.Drawing.Point(450, 113);
            this.btnChooseAvatar.Name = "btnChooseAvatar";
            this.btnChooseAvatar.Size = new System.Drawing.Size(105, 31);
            this.btnChooseAvatar.Text = "📁 Chọn ảnh...";
            this.btnChooseAvatar.UseVisualStyleBackColor = true;
            this.btnChooseAvatar.Click += new System.EventHandler(this.BtnChooseAvatar_Click);

            this.txtAvatarUrl.Location = new System.Drawing.Point(560, 114);
            this.txtAvatarUrl.Name = "txtAvatarUrl";
            this.txtAvatarUrl.ReadOnly = true;
            this.txtAvatarUrl.Size = new System.Drawing.Size(100, 29);
            this.txtAvatarUrl.PlaceholderText = "Đường dẫn...";

            // picAvatar
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(680, 25);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(140, 140);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabStop = false;

            // Buttons
            this.btnAdd.BackColor = System.Drawing.Color.LightGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.Location = new System.Drawing.Point(125, 162);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 40);
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            this.btnUpdate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Location = new System.Drawing.Point(245, 162);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 40);
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClear.Location = new System.Drawing.Point(365, 162);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 40);
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // dgvPlayers
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlayers.Location = new System.Drawing.Point(0, 220);
            this.dgvPlayers.MultiSelect = false;
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.RowHeadersWidth = 51;
            this.dgvPlayers.RowTemplate.Height = 30;
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.Size = new System.Drawing.Size(850, 530);
            this.dgvPlayers.TabIndex = 1;
            this.dgvPlayers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPlayers_CellClick);
            this.dgvPlayers.SelectionChanged += new System.EventHandler(this.DgvPlayers_SelectionChanged);

            // gbTournaments
            this.gbTournaments.Controls.Add(this.dgvTournaments);
            this.gbTournaments.Controls.Add(this.lblTotalTournaments);
            this.gbTournaments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTournaments.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbTournaments.Location = new System.Drawing.Point(0, 0);
            this.gbTournaments.Name = "gbTournaments";
            this.gbTournaments.Padding = new System.Windows.Forms.Padding(10);
            this.gbTournaments.Size = new System.Drawing.Size(506, 750);
            this.gbTournaments.TabIndex = 0;
            this.gbTournaments.TabStop = false;
            this.gbTournaments.Text = "Giải đấu đã && đang tham gia";

            // lblTotalTournaments
            this.lblTotalTournaments.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalTournaments.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalTournaments.Height = 35;
            this.lblTotalTournaments.Location = new System.Drawing.Point(10, 32);
            this.lblTotalTournaments.Name = "lblTotalTournaments";
            this.lblTotalTournaments.Size = new System.Drawing.Size(486, 35);
            this.lblTotalTournaments.Text = "Tổng số giải đã tham gia: 0";
            this.lblTotalTournaments.UseMnemonic = false;

            // dgvTournaments
            this.dgvTournaments.AllowUserToAddRows = false;
            this.dgvTournaments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTournaments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTournaments.Location = new System.Drawing.Point(10, 67);
            this.dgvTournaments.Name = "dgvTournaments";
            this.dgvTournaments.ReadOnly = true;
            this.dgvTournaments.RowHeadersWidth = 51;
            this.dgvTournaments.RowTemplate.Height = 30;
            this.dgvTournaments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTournaments.Size = new System.Drawing.Size(486, 673);
            this.dgvTournaments.TabIndex = 1;

            // Form Main
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 750);
            this.Controls.Add(this.splitContainer);
            this.Name = "PlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ CƠ THỦ VÀ LỊCH SỬ THAM GIA GIẢI ĐẤU";

            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gbPlayerInfo.ResumeLayout(false);
            this.gbPlayerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.gbTournaments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournaments)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox gbPlayerInfo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.ComboBox cbRankLevel;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Button btnChooseAvatar;
        private System.Windows.Forms.TextBox txtAvatarUrl;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.GroupBox gbTournaments;
        private System.Windows.Forms.Label lblTotalTournaments;
        private System.Windows.Forms.DataGridView dgvTournaments;
    }
}