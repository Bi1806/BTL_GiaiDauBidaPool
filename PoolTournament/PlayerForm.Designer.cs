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

        // ===== BẢNG MÀU CHỦ ĐỀ BI-A =====
        private static readonly System.Drawing.Color FeltDark = System.Drawing.Color.FromArgb(7, 38, 27);
        private static readonly System.Drawing.Color FeltLight = System.Drawing.Color.FromArgb(18, 82, 58);
        private static readonly System.Drawing.Color CardBack = System.Drawing.Color.FromArgb(16, 43, 34);
        private static readonly System.Drawing.Color CardBorder = System.Drawing.Color.FromArgb(38, 96, 71);
        private static readonly System.Drawing.Color InputBack = System.Drawing.Color.FromArgb(11, 31, 24);
        private static readonly System.Drawing.Color Gold = System.Drawing.Color.FromArgb(230, 184, 74);
        private static readonly System.Drawing.Color TextMain = System.Drawing.Color.FromArgb(233, 243, 238);
        private static readonly System.Drawing.Color TextMuted = System.Drawing.Color.FromArgb(154, 187, 172);
        private static readonly System.Drawing.Color RowAlt = System.Drawing.Color.FromArgb(13, 37, 29);
        private static readonly System.Drawing.Color RowBase = System.Drawing.Color.FromArgb(18, 48, 38);
        private static readonly System.Drawing.Color SelBack = System.Drawing.Color.FromArgb(29, 122, 85);
        private static readonly System.Drawing.Color HeadBack = System.Drawing.Color.FromArgb(10, 56, 39);

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            pnlFooter = new Panel();
            pnlContent = new Panel();
            splitContainer = new SplitContainer();
            pnlPlayersCard = new Panel();
            dgvPlayers = new DataGridView();
            gbPlayerInfo = new GroupBox();
            tlpInfo = new TableLayoutPanel();
            lblName = new Label();
            txtFullName = new TextBox();
            lblRank = new Label();
            cbRankLevel = new ComboBox();
            picAvatar = new PictureBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblStatus = new Label();
            cbStatus = new ComboBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblAvatar = new Label();
            tlpAvatarPick = new TableLayoutPanel();
            btnChooseAvatar = new Button();
            txtAvatarUrl = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            gbTournaments = new GroupBox();
            dgvTournaments = new DataGridView();
            lblTotalTournaments = new Label();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            pnlPlayersCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).BeginInit();
            gbPlayerInfo.SuspendLayout();
            tlpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            tlpAvatarPick.SuspendLayout();
            flpButtons.SuspendLayout();
            gbTournaments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTournaments).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4, 5, 4, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1829, 140);
            pnlHeader.TabIndex = 10;
            pnlHeader.Paint += PoolHeader_Paint;
            // 
            // pnlFooter
            // 
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 1123);
            pnlFooter.Margin = new Padding(4, 5, 4, 5);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1829, 77);
            pnlFooter.TabIndex = 11;
            pnlFooter.Paint += PoolFooter_Paint;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(splitContainer);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 140);
            pnlContent.Margin = new Padding(4, 5, 4, 5);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20, 20, 20, 20);
            pnlContent.Size = new Size(1829, 983);
            pnlContent.TabIndex = 12;
            pnlContent.Paint += PoolFelt_Paint;
            // 
            // splitContainer
            // 
            splitContainer.BackColor = Color.Transparent;
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(20, 20);
            splitContainer.Margin = new Padding(4, 5, 4, 5);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(pnlPlayersCard);
            splitContainer.Panel1.Controls.Add(gbPlayerInfo);
            splitContainer.Panel1MinSize = 560;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(gbTournaments);
            splitContainer.Panel2MinSize = 260;
            splitContainer.Size = new Size(1789, 943);
            splitContainer.SplitterDistance = 1114;
            splitContainer.SplitterWidth = 14;
            splitContainer.TabIndex = 0;
            // 
            // pnlPlayersCard
            // 
            pnlPlayersCard.BackColor = Color.Transparent;
            pnlPlayersCard.Controls.Add(dgvPlayers);
            pnlPlayersCard.Dock = DockStyle.Fill;
            pnlPlayersCard.Location = new Point(0, 400);
            pnlPlayersCard.Margin = new Padding(4, 5, 4, 5);
            pnlPlayersCard.Name = "pnlPlayersCard";
            pnlPlayersCard.Padding = new Padding(20, 83, 20, 23);
            pnlPlayersCard.Size = new Size(1114, 543);
            pnlPlayersCard.TabIndex = 1;
            pnlPlayersCard.Tag = "8|DANH SÁCH CƠ THỦ";
            pnlPlayersCard.Paint += PoolCard_Paint;
            // 
            // dgvPlayers
            // 
            dgvPlayers.AllowUserToAddRows = false;
            dgvPlayers.AllowUserToDeleteRows = false;
            dgvPlayers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(13, 37, 29);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(233, 243, 238);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(29, 122, 85);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvPlayers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlayers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPlayers.BorderStyle = BorderStyle.None;
            dgvPlayers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPlayers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(10, 56, 39);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(230, 184, 74);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(10, 56, 39);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(230, 184, 74);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPlayers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(18, 48, 38);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(233, 243, 238);
            dataGridViewCellStyle3.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(29, 122, 85);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPlayers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPlayers.Dock = DockStyle.Fill;
            dgvPlayers.BackgroundColor = Color.FromArgb(16, 43, 34);
            dgvPlayers.EnableHeadersVisualStyles = false;
            dgvPlayers.GridColor = Color.FromArgb(28, 74, 57);
            dgvPlayers.Location = new Point(20, 83);
            dgvPlayers.Margin = new Padding(4, 5, 4, 5);
            dgvPlayers.MultiSelect = false;
            dgvPlayers.Name = "dgvPlayers";
            dgvPlayers.ReadOnly = true;
            dgvPlayers.RowHeadersVisible = false;
            dgvPlayers.RowHeadersWidth = 62;
            dgvPlayers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlayers.Size = new Size(1074, 437);
            dgvPlayers.TabIndex = 1;
            dgvPlayers.SelectionChanged += DgvPlayers_SelectionChanged;
            // 
            // gbPlayerInfo
            // 
            gbPlayerInfo.AutoSize = true;
            gbPlayerInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gbPlayerInfo.BackColor = Color.Transparent;
            gbPlayerInfo.Controls.Add(tlpInfo);
            gbPlayerInfo.Dock = DockStyle.Top;
            gbPlayerInfo.Location = new Point(0, 0);
            gbPlayerInfo.Margin = new Padding(4, 5, 4, 5);
            gbPlayerInfo.Name = "gbPlayerInfo";
            gbPlayerInfo.Padding = new Padding(29, 87, 29, 30);
            gbPlayerInfo.Size = new Size(1114, 400);
            gbPlayerInfo.TabIndex = 0;
            gbPlayerInfo.TabStop = false;
            gbPlayerInfo.Tag = "9|THÔNG TIN CHI TIẾT CƠ THỦ";
            gbPlayerInfo.Paint += PoolCard_Paint;
            // 
            // tlpInfo
            // 
            tlpInfo.AutoSize = true;
            tlpInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpInfo.BackColor = Color.Transparent;
            tlpInfo.ColumnCount = 5;
            tlpInfo.ColumnStyles.Add(new ColumnStyle());
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle());
            tlpInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInfo.ColumnStyles.Add(new ColumnStyle());
            tlpInfo.Controls.Add(lblName, 0, 0);
            tlpInfo.Controls.Add(txtFullName, 1, 0);
            tlpInfo.Controls.Add(lblRank, 2, 0);
            tlpInfo.Controls.Add(cbRankLevel, 3, 0);
            tlpInfo.Controls.Add(picAvatar, 4, 0);
            tlpInfo.Controls.Add(lblPhone, 0, 1);
            tlpInfo.Controls.Add(txtPhone, 1, 1);
            tlpInfo.Controls.Add(lblStatus, 2, 1);
            tlpInfo.Controls.Add(cbStatus, 3, 1);
            tlpInfo.Controls.Add(lblEmail, 0, 2);
            tlpInfo.Controls.Add(txtEmail, 1, 2);
            tlpInfo.Controls.Add(lblAvatar, 2, 2);
            tlpInfo.Controls.Add(tlpAvatarPick, 3, 2);
            tlpInfo.Controls.Add(flpButtons, 1, 3);
            tlpInfo.Dock = DockStyle.Top;
            tlpInfo.Location = new Point(29, 111);
            tlpInfo.Margin = new Padding(4, 5, 4, 5);
            tlpInfo.Name = "tlpInfo";
            tlpInfo.RowCount = 4;
            tlpInfo.RowStyles.Add(new RowStyle());
            tlpInfo.RowStyles.Add(new RowStyle());
            tlpInfo.RowStyles.Add(new RowStyle());
            tlpInfo.RowStyles.Add(new RowStyle());
            tlpInfo.Size = new Size(1056, 259);
            tlpInfo.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Left;
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.ForeColor = Color.FromArgb(233, 243, 238);
            lblName.Location = new Point(4, 14);
            lblName.Margin = new Padding(4, 10, 14, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(93, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Họ và tên:";
            // 
            // txtFullName
            // 
            txtFullName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFullName.BackColor = Color.FromArgb(11, 31, 24);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.ForeColor = Color.FromArgb(233, 243, 238);
            txtFullName.Location = new Point(143, 11);
            txtFullName.Margin = new Padding(4, 10, 29, 10);
            txtFullName.MinimumSize = new Size(199, 2);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Nhập tên cơ thủ...";
            txtFullName.Size = new Size(239, 31);
            txtFullName.TabIndex = 1;
            // 
            // lblRank
            // 
            lblRank.Anchor = AnchorStyles.Left;
            lblRank.AutoSize = true;
            lblRank.BackColor = Color.Transparent;
            lblRank.ForeColor = Color.FromArgb(233, 243, 238);
            lblRank.Location = new Point(415, 14);
            lblRank.Margin = new Padding(4, 10, 14, 10);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(113, 25);
            lblRank.TabIndex = 2;
            lblRank.Text = "Hạng (Rank):";
            // 
            // cbRankLevel
            // 
            cbRankLevel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbRankLevel.BackColor = Color.FromArgb(11, 31, 24);
            cbRankLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRankLevel.FlatStyle = FlatStyle.Flat;
            cbRankLevel.FormattingEnabled = true;
            cbRankLevel.ForeColor = Color.FromArgb(233, 243, 238);
            cbRankLevel.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "Chuyên nghiệp", "Nghiệp dư" });
            cbRankLevel.Location = new Point(549, 10);
            cbRankLevel.Margin = new Padding(4, 10, 4, 10);
            cbRankLevel.MinimumSize = new Size(198, 0);
            cbRankLevel.Name = "cbRankLevel";
            cbRankLevel.Size = new Size(264, 33);
            cbRankLevel.TabIndex = 3;
            // 
            // picAvatar
            // 
            picAvatar.Anchor = AnchorStyles.Top;
            picAvatar.BackColor = Color.Transparent;
            picAvatar.Location = new Point(846, 5);
            picAvatar.Margin = new Padding(29, 5, 9, 5);
            picAvatar.Name = "picAvatar";
            tlpInfo.SetRowSpan(picAvatar, 4);
            picAvatar.Size = new Size(200, 233);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 13;
            picAvatar.TabStop = false;
            picAvatar.Paint += PoolAvatar_Paint;
            // 
            // lblPhone
            // 
            lblPhone.Anchor = AnchorStyles.Left;
            lblPhone.AutoSize = true;
            lblPhone.BackColor = Color.Transparent;
            lblPhone.ForeColor = Color.FromArgb(233, 243, 238);
            lblPhone.Location = new Point(4, 67);
            lblPhone.Margin = new Padding(4, 10, 14, 10);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(121, 25);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.BackColor = Color.FromArgb(11, 31, 24);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.ForeColor = Color.FromArgb(233, 243, 238);
            txtPhone.Location = new Point(143, 64);
            txtPhone.Margin = new Padding(4, 10, 29, 10);
            txtPhone.MinimumSize = new Size(199, 2);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "09xx xxx xxx";
            txtPhone.Size = new Size(239, 31);
            txtPhone.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.Transparent;
            lblStatus.ForeColor = Color.FromArgb(233, 243, 238);
            lblStatus.Location = new Point(415, 67);
            lblStatus.Margin = new Padding(4, 10, 14, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(93, 25);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Trạng thái:";
            // 
            // cbStatus
            // 
            cbStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cbStatus.BackColor = Color.FromArgb(11, 31, 24);
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FlatStyle = FlatStyle.Flat;
            cbStatus.FormattingEnabled = true;
            cbStatus.ForeColor = Color.FromArgb(233, 243, 238);
            cbStatus.Items.AddRange(new object[] { "active", "suspended", "inactive" });
            cbStatus.Location = new Point(549, 63);
            cbStatus.Margin = new Padding(4, 10, 4, 10);
            cbStatus.MinimumSize = new Size(198, 0);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(264, 33);
            cbStatus.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Left;
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.ForeColor = Color.FromArgb(233, 243, 238);
            lblEmail.Location = new Point(4, 130);
            lblEmail.Margin = new Padding(4, 10, 14, 10);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BackColor = Color.FromArgb(11, 31, 24);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.ForeColor = Color.FromArgb(233, 243, 238);
            txtEmail.Location = new Point(143, 127);
            txtEmail.Margin = new Padding(4, 10, 29, 10);
            txtEmail.MinimumSize = new Size(199, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "email@example.com";
            txtEmail.Size = new Size(239, 31);
            txtEmail.TabIndex = 9;
            // 
            // lblAvatar
            // 
            lblAvatar.Anchor = AnchorStyles.Left;
            lblAvatar.AutoSize = true;
            lblAvatar.BackColor = Color.Transparent;
            lblAvatar.ForeColor = Color.FromArgb(233, 243, 238);
            lblAvatar.Location = new Point(415, 130);
            lblAvatar.Margin = new Padding(4, 10, 14, 10);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(116, 25);
            lblAvatar.TabIndex = 10;
            lblAvatar.Text = "Ảnh đại diện:";
            // 
            // tlpAvatarPick
            // 
            tlpAvatarPick.AutoSize = true;
            tlpAvatarPick.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpAvatarPick.BackColor = Color.Transparent;
            tlpAvatarPick.ColumnCount = 2;
            tlpAvatarPick.ColumnStyles.Add(new ColumnStyle());
            tlpAvatarPick.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpAvatarPick.Controls.Add(btnChooseAvatar, 0, 0);
            tlpAvatarPick.Controls.Add(txtAvatarUrl, 1, 0);
            tlpAvatarPick.Dock = DockStyle.Fill;
            tlpAvatarPick.Location = new Point(545, 111);
            tlpAvatarPick.Margin = new Padding(0, 5, 0, 5);
            tlpAvatarPick.Name = "tlpAvatarPick";
            tlpAvatarPick.RowCount = 1;
            tlpAvatarPick.RowStyles.Add(new RowStyle());
            tlpAvatarPick.Size = new Size(272, 63);
            tlpAvatarPick.TabIndex = 11;
            // 
            // btnChooseAvatar
            // 
            btnChooseAvatar.Anchor = AnchorStyles.Left;
            btnChooseAvatar.AutoSize = true;
            btnChooseAvatar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnChooseAvatar.BackColor = Color.FromArgb(24, 64, 49);
            btnChooseAvatar.Cursor = Cursors.Hand;
            btnChooseAvatar.FlatAppearance.BorderColor = Color.FromArgb(38, 96, 71);
            btnChooseAvatar.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 86, 65);
            btnChooseAvatar.FlatStyle = FlatStyle.Flat;
            btnChooseAvatar.ForeColor = Color.FromArgb(233, 243, 238);
            btnChooseAvatar.Location = new Point(4, 5);
            btnChooseAvatar.Margin = new Padding(4, 5, 11, 5);
            btnChooseAvatar.Name = "btnChooseAvatar";
            btnChooseAvatar.Padding = new Padding(14, 8, 14, 8);
            btnChooseAvatar.Size = new Size(140, 53);
            btnChooseAvatar.TabIndex = 11;
            btnChooseAvatar.Text = "Chọn ảnh...";
            btnChooseAvatar.UseVisualStyleBackColor = false;
            btnChooseAvatar.Click += BtnChooseAvatar_Click;
            // 
            // txtAvatarUrl
            // 
            txtAvatarUrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtAvatarUrl.BackColor = Color.FromArgb(11, 31, 24);
            txtAvatarUrl.BorderStyle = BorderStyle.FixedSingle;
            txtAvatarUrl.ForeColor = Color.FromArgb(154, 187, 172);
            txtAvatarUrl.Location = new Point(159, 16);
            txtAvatarUrl.Margin = new Padding(4, 10, 4, 10);
            txtAvatarUrl.MinimumSize = new Size(128, 2);
            txtAvatarUrl.Name = "txtAvatarUrl";
            txtAvatarUrl.PlaceholderText = "Đường dẫn...";
            txtAvatarUrl.ReadOnly = true;
            txtAvatarUrl.Size = new Size(128, 31);
            txtAvatarUrl.TabIndex = 12;
            // 
            // flpButtons
            // 
            flpButtons.AutoSize = true;
            flpButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpButtons.BackColor = Color.Transparent;
            tlpInfo.SetColumnSpan(flpButtons, 3);
            flpButtons.Controls.Add(btnAdd);
            flpButtons.Controls.Add(btnUpdate);
            flpButtons.Controls.Add(btnClear);
            flpButtons.Location = new Point(139, 196);
            flpButtons.Margin = new Padding(0, 17, 0, 0);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new Size(486, 63);
            flpButtons.TabIndex = 14;
            flpButtons.WrapContents = false;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAdd.BackColor = Color.FromArgb(22, 163, 74);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 197, 94);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(0, 0);
            btnAdd.Margin = new Padding(0, 0, 14, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(26, 13, 26, 13);
            btnAdd.Size = new Size(154, 61);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUpdate.BackColor = Color.FromArgb(202, 138, 4);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 179, 8);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(168, 0);
            btnUpdate.Margin = new Padding(0, 0, 14, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Padding = new Padding(26, 13, 26, 13);
            btnUpdate.Size = new Size(145, 61);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.AutoSize = true;
            btnClear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClear.BackColor = Color.FromArgb(28, 74, 57);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(38, 96, 71);
            btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 96, 71);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.FromArgb(233, 243, 238);
            btnClear.Location = new Point(327, 0);
            btnClear.Margin = new Padding(0, 0, 14, 0);
            btnClear.Name = "btnClear";
            btnClear.Padding = new Padding(26, 13, 26, 13);
            btnClear.Size = new Size(145, 63);
            btnClear.TabIndex = 16;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // gbTournaments
            // 
            gbTournaments.BackColor = Color.Transparent;
            gbTournaments.Controls.Add(dgvTournaments);
            gbTournaments.Controls.Add(lblTotalTournaments);
            gbTournaments.Dock = DockStyle.Fill;
            gbTournaments.Location = new Point(0, 0);
            gbTournaments.Margin = new Padding(4, 5, 4, 5);
            gbTournaments.Name = "gbTournaments";
            gbTournaments.Padding = new Padding(20, 83, 20, 23);
            gbTournaments.Size = new Size(661, 943);
            gbTournaments.TabIndex = 0;
            gbTournaments.TabStop = false;
            gbTournaments.Tag = "1|GIẢI ĐẤU ĐÃ & ĐANG THAM GIA";
            gbTournaments.Paint += PoolCard_Paint;
            // 
            // dgvTournaments
            // 
            dgvTournaments.AllowUserToAddRows = false;
            dgvTournaments.AllowUserToDeleteRows = false;
            dgvTournaments.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(13, 37, 29);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(233, 243, 238);
            dataGridViewCellStyle4.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(29, 122, 85);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTournaments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTournaments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTournaments.BorderStyle = BorderStyle.None;
            dgvTournaments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTournaments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(10, 56, 39);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(230, 184, 74);
            dataGridViewCellStyle5.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(10, 56, 39);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(230, 184, 74);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvTournaments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvTournaments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(18, 48, 38);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(233, 243, 238);
            dataGridViewCellStyle6.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(29, 122, 85);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvTournaments.DefaultCellStyle = dataGridViewCellStyle6;
            dgvTournaments.Dock = DockStyle.Fill;
            dgvTournaments.BackgroundColor = Color.FromArgb(16, 43, 34);
            dgvTournaments.EnableHeadersVisualStyles = false;
            dgvTournaments.GridColor = Color.FromArgb(28, 74, 57);
            dgvTournaments.Location = new Point(20, 177);
            dgvTournaments.Margin = new Padding(4, 5, 4, 5);
            dgvTournaments.Name = "dgvTournaments";
            dgvTournaments.ReadOnly = true;
            dgvTournaments.RowHeadersVisible = false;
            dgvTournaments.RowHeadersWidth = 62;
            dgvTournaments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTournaments.Size = new Size(621, 743);
            dgvTournaments.TabIndex = 1;
            // 
            // lblTotalTournaments
            // 
            lblTotalTournaments.BackColor = Color.FromArgb(10, 56, 39);
            lblTotalTournaments.Dock = DockStyle.Top;
            lblTotalTournaments.ForeColor = Color.FromArgb(230, 184, 74);
            lblTotalTournaments.Location = new Point(20, 107);
            lblTotalTournaments.Margin = new Padding(4, 0, 4, 0);
            lblTotalTournaments.Name = "lblTotalTournaments";
            lblTotalTournaments.Padding = new Padding(17, 13, 17, 13);
            lblTotalTournaments.Size = new Size(621, 70);
            lblTotalTournaments.TabIndex = 2;
            lblTotalTournaments.Text = "Tổng số giải đã tham gia: 0";
            lblTotalTournaments.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PlayerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1829, 1200);
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.FromArgb(233, 243, 238);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1476, 1063);
            Name = "PlayerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "POOL CLUB • QUẢN LÝ CƠ THỦ VÀ LỊCH SỬ THAM GIA GIẢI ĐẤU";
            Load += PoolTheme_Load;
            pnlContent.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            pnlPlayersCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).EndInit();
            gbPlayerInfo.ResumeLayout(false);
            gbPlayerInfo.PerformLayout();
            tlpInfo.ResumeLayout(false);
            tlpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            tlpAvatarPick.ResumeLayout(false);
            tlpAvatarPick.PerformLayout();
            flpButtons.ResumeLayout(false);
            flpButtons.PerformLayout();
            gbTournaments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTournaments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        #region Vẽ giao diện chủ đề Billiards

        private void PoolTheme_Load(object sender, System.EventArgs e)
        {
            this.DoubleBuffered = true;
            EnableDoubleBuffer(this.pnlContent);
            EnableDoubleBuffer(this.pnlHeader);
            EnableDoubleBuffer(this.pnlFooter);
            EnableDoubleBuffer(this.gbPlayerInfo);
            EnableDoubleBuffer(this.gbTournaments);
            EnableDoubleBuffer(this.pnlPlayersCard);

            this.pnlContent.Resize += (s, ev) => this.pnlContent.Invalidate();
            this.pnlHeader.Resize += (s, ev) => this.pnlHeader.Invalidate();
            this.pnlFooter.Resize += (s, ev) => this.pnlFooter.Invalidate();
            this.gbPlayerInfo.Resize += (s, ev) => this.gbPlayerInfo.Invalidate();
            this.gbTournaments.Resize += (s, ev) => this.gbTournaments.Invalidate();
            this.pnlPlayersCard.Resize += (s, ev) => this.pnlPlayersCard.Invalidate();

            // Chia panel theo TỈ LỆ (không dùng pixel cứng -> không vỡ khi đổi DPI)
            this.splitContainer.Resize += (s, ev) => ApplySplitterRatio();
            this.BeginInvoke(new System.Action(ApplySplitterRatio));
        }

        private void ApplySplitterRatio()
        {
            if (this.splitContainer == null || this.splitContainer.Width <= 0) return;
            int want = (int)(this.splitContainer.Width * 0.63);
            int min = this.splitContainer.Panel1MinSize;
            int max = this.splitContainer.Width - this.splitContainer.Panel2MinSize
                      - this.splitContainer.SplitterWidth;
            if (max < min) return;
            if (want < min) want = min;
            if (want > max) want = max;
            try { this.splitContainer.SplitterDistance = want; } catch { }
        }

        private static void EnableDoubleBuffer(System.Windows.Forms.Control c)
        {
            if (c == null) return;
            var prop = typeof(System.Windows.Forms.Control).GetProperty(
                "DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (prop != null) prop.SetValue(c, true, null);
        }

        private void PoolFelt_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var c = (System.Windows.Forms.Control)sender;
            var g = e.Graphics;
            var r = c.ClientRectangle;
            if (r.Width <= 0 || r.Height <= 0) return;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                r, FeltLight, FeltDark, System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal))
            {
                g.FillRectangle(lg, r);
            }

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                var glow = new System.Drawing.Rectangle(
                    r.Width / 2 - r.Width / 2, -r.Height / 3, r.Width, r.Height);
                path.AddEllipse(glow);
                using (var pgb = new System.Drawing.Drawing2D.PathGradientBrush(path))
                {
                    pgb.CenterColor = System.Drawing.Color.FromArgb(52, 255, 255, 255);
                    pgb.SurroundColors = new[] { System.Drawing.Color.FromArgb(0, 0, 0, 0) };
                    g.FillEllipse(pgb, glow);
                }
            }

            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(10, 255, 255, 255), 1f))
            {
                for (int x = -r.Height; x < r.Width; x += 9)
                    g.DrawLine(pen, x, r.Bottom, x + r.Height, r.Top);
            }

            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(90, 0, 0, 0), 3f))
            {
                g.DrawRectangle(pen, 1, 1, r.Width - 3, r.Height - 3);
            }
        }

        private void PoolCard_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var c = (System.Windows.Forms.Control)sender;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var rect = new System.Drawing.Rectangle(4, 4, c.Width - 9, c.Height - 9);
            if (rect.Width <= 4 || rect.Height <= 4) return;

            for (int i = 4; i > 0; i--)
            {
                using (var sp = new System.Drawing.Pen(System.Drawing.Color.FromArgb(10 * i, 0, 0, 0), 1))
                using (var spath = RoundedRect(
                    new System.Drawing.Rectangle(rect.X - i, rect.Y - i + 2, rect.Width + i * 2, rect.Height + i * 2), 16 + i))
                {
                    g.DrawPath(sp, spath);
                }
            }

            using (var path = RoundedRect(rect, 16))
            {
                using (var lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                    rect, System.Drawing.Color.FromArgb(22, 56, 44), CardBack,
                    System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                {
                    g.FillPath(lg, path);
                }
                using (var pen = new System.Drawing.Pen(CardBorder, 1.4f))
                {
                    g.DrawPath(pen, path);
                }
            }

            string tag = c.Tag as string;
            if (string.IsNullOrEmpty(tag)) return;
            var parts = tag.Split('|');
            string number = parts[0];
            string title = parts.Length > 1 ? parts[1] : "";

            float cx = rect.X + 26f;
            float cy = rect.Y + 23f;
            DrawPoolBall(g, cx, cy, 12f, BallColor(number), number, IsStriped(number));

            using (var f = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold))
            using (var b = new System.Drawing.SolidBrush(Gold))
            {
                g.DrawString(title, f, b, rect.X + 44f, rect.Y + 12f);
            }

            using (var lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                new System.Drawing.Rectangle(rect.X + 18, rect.Y + 38, rect.Width - 36, 2),
                Gold, System.Drawing.Color.FromArgb(0, 230, 184, 74),
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
            {
                g.FillRectangle(lg, rect.X + 18, rect.Y + 38, rect.Width - 36, 2);
            }
        }

        private void PoolHeader_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var c = (System.Windows.Forms.Control)sender;
            var g = e.Graphics;
            var r = c.ClientRectangle;
            if (r.Width <= 0) return;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (var lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                r, System.Drawing.Color.FromArgb(74, 44, 23), System.Drawing.Color.FromArgb(32, 18, 10),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                g.FillRectangle(lg, r);
            }

            var rnd = new System.Random(7);
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(26, 255, 226, 180), 1f))
            {
                for (int i = 0; i < 26; i++)
                {
                    int y = rnd.Next(r.Height);
                    g.DrawBezier(pen, 0, y, r.Width * 0.3f, y - 5, r.Width * 0.7f, y + 5, r.Width, y);
                }
            }

            using (var lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                new System.Drawing.Rectangle(0, r.Height - 3, r.Width, 3),
                System.Drawing.Color.FromArgb(180, 130, 40), Gold,
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
            {
                g.FillRectangle(lg, 0, r.Height - 3, r.Width, 3);
            }

            DrawPoolBall(g, 44f, r.Height / 2f, 24f, System.Drawing.Color.FromArgb(20, 20, 20), "8", false);

            using (var f1 = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold))
            using (var f2 = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular))
            using (var b1 = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 245, 225)))
            using (var b2 = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(214, 178, 122)))
            using (var sh = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(120, 0, 0, 0)))
            {
                g.DrawString("QUẢN LÝ CƠ THỦ & GIẢI ĐẤU", f1, sh, 81f, 15f);
                g.DrawString("QUẢN LÝ CƠ THỦ & GIẢI ĐẤU", f1, b1, 80f, 14f);
                g.DrawString("POOL BILLIARDS CLUB  •  PLAYER & TOURNAMENT MANAGER", f2, b2, 82f, 48f);
            }

            string[] balls = { "1", "2", "3", "4", "5", "9", "8" };
            float x = r.Width - 34f;
            for (int i = 0; i < balls.Length && x > 420; i++)
            {
                DrawPoolBall(g, x, r.Height / 2f, 16f, BallColor(balls[i]), balls[i], IsStriped(balls[i]));
                x -= 38f;
            }
        }

        private void PoolFooter_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var c = (System.Windows.Forms.Control)sender;
            var g = e.Graphics;
            var r = c.ClientRectangle;
            if (r.Width <= 0) return;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                r, System.Drawing.Color.FromArgb(32, 18, 10), System.Drawing.Color.FromArgb(58, 34, 18),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                g.FillRectangle(lg, r);
            }
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(120, 230, 184, 74), 2f))
            {
                g.DrawLine(pen, 0, 0, r.Width, 0);
            }

            float cy = r.Height / 2f;

            using (var lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                new System.Drawing.RectangleF(r.Width - 330f, cy - 4f, 240f, 8f),
                System.Drawing.Color.FromArgb(198, 150, 92), System.Drawing.Color.FromArgb(92, 56, 28),
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
            {
                g.FillRectangle(lg, r.Width - 330f, cy - 3f, 240f, 6f);
            }
            using (var tip = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(70, 130, 180)))
            {
                g.FillRectangle(tip, r.Width - 336f, cy - 3f, 7f, 6f);
            }
            DrawPoolBall(g, r.Width - 352f, cy, 12f, System.Drawing.Color.FromArgb(245, 245, 240), "", false);

            using (var f = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular))
            using (var b = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(176, 142, 96)))
            {
                g.DrawString("Pool Club Manager  •  Chọn một cơ thủ trong danh sách để xem lịch sử thi đấu",
                    f, b, 18f, cy - 9f);
            }
        }

        private void PoolAvatar_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var c = (System.Windows.Forms.Control)sender;
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var rect = new System.Drawing.Rectangle(0, 0, c.Width - 1, c.Height - 1);
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(150, 230, 184, 74), 2f))
            using (var path = RoundedRect(rect, 12))
            {
                g.DrawPath(pen, path);
            }

            if (((System.Windows.Forms.PictureBox)c).Image == null)
            {
                using (var f = new System.Drawing.Font("Segoe UI", 9F))
                using (var b = new System.Drawing.SolidBrush(TextMuted))
                using (var sf = new System.Drawing.StringFormat
                {
                    Alignment = System.Drawing.StringAlignment.Center,
                    LineAlignment = System.Drawing.StringAlignment.Center
                })
                {
                    g.DrawString("Ảnh cơ thủ", f, b, rect, sf);
                }
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(System.Drawing.Rectangle r, int radius)
        {
            int d = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            if (r.Width <= d || r.Height <= d) { path.AddRectangle(r); return path; }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static System.Drawing.Color BallColor(string number)
        {
            switch (number)
            {
                case "1": case "9": return System.Drawing.Color.FromArgb(240, 190, 20);
                case "2": case "10": return System.Drawing.Color.FromArgb(25, 90, 190);
                case "3": case "11": return System.Drawing.Color.FromArgb(205, 40, 40);
                case "4": case "12": return System.Drawing.Color.FromArgb(120, 50, 160);
                case "5": case "13": return System.Drawing.Color.FromArgb(235, 120, 25);
                case "6": case "14": return System.Drawing.Color.FromArgb(20, 130, 80);
                case "7": case "15": return System.Drawing.Color.FromArgb(135, 45, 40);
                case "8": return System.Drawing.Color.FromArgb(22, 22, 22);
                default: return System.Drawing.Color.FromArgb(240, 240, 235);
            }
        }

        private static bool IsStriped(string number)
        {
            int n;
            return int.TryParse(number, out n) && n >= 9 && n <= 15;
        }

        private static void DrawPoolBall(System.Drawing.Graphics g, float cx, float cy, float radius,
            System.Drawing.Color color, string number, bool striped)
        {
            var rect = new System.Drawing.RectangleF(cx - radius, cy - radius, radius * 2f, radius * 2f);

            using (var shadow = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(70, 0, 0, 0)))
            {
                g.FillEllipse(shadow, cx - radius * 0.85f, cy + radius * 0.6f, radius * 1.7f, radius * 0.55f);
            }

            var baseColor = striped ? System.Drawing.Color.FromArgb(245, 245, 240) : color;

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(rect);
                using (var pgb = new System.Drawing.Drawing2D.PathGradientBrush(path))
                {
                    pgb.CenterPoint = new System.Drawing.PointF(cx - radius * 0.35f, cy - radius * 0.35f);
                    pgb.CenterColor = System.Windows.Forms.ControlPaint.Light(baseColor, 0.7f);
                    pgb.SurroundColors = new[] { System.Windows.Forms.ControlPaint.Dark(baseColor, 0.18f) };
                    g.FillEllipse(pgb, rect);
                }

                if (striped)
                {
                    var oldClip = g.Clip;
                    g.SetClip(path);
                    using (var lg = new System.Drawing.Drawing2D.LinearGradientBrush(
                        new System.Drawing.RectangleF(cx - radius, cy - radius * 0.62f, radius * 2f, radius * 1.24f),
                        System.Windows.Forms.ControlPaint.Light(color, 0.45f),
                        System.Windows.Forms.ControlPaint.Dark(color, 0.12f),
                        System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(lg, cx - radius, cy - radius * 0.62f, radius * 2f, radius * 1.24f);
                    }
                    g.Clip = oldClip;
                }
            }

            if (!string.IsNullOrEmpty(number))
            {
                float nr = radius * 0.56f;
                var nrect = new System.Drawing.RectangleF(cx - nr, cy - nr, nr * 2f, nr * 2f);
                using (var white = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(250, 250, 248)))
                {
                    g.FillEllipse(white, nrect);
                }
                float fontSize = System.Math.Max(5.5f, radius * 0.62f);
                using (var f = new System.Drawing.Font("Segoe UI", fontSize, System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Pixel))
                using (var b = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(25, 25, 25)))
                using (var sf = new System.Drawing.StringFormat
                {
                    Alignment = System.Drawing.StringAlignment.Center,
                    LineAlignment = System.Drawing.StringAlignment.Center
                })
                {
                    g.DrawString(number, f, b, nrect, sf);
                }
            }

            using (var hi = new System.Drawing.Drawing2D.GraphicsPath())
            {
                var hrect = new System.Drawing.RectangleF(
                    cx - radius * 0.62f, cy - radius * 0.72f, radius * 0.7f, radius * 0.5f);
                hi.AddEllipse(hrect);
                using (var pgb = new System.Drawing.Drawing2D.PathGradientBrush(hi))
                {
                    pgb.CenterColor = System.Drawing.Color.FromArgb(190, 255, 255, 255);
                    pgb.SurroundColors = new[] { System.Drawing.Color.FromArgb(0, 255, 255, 255) };
                    g.FillEllipse(pgb, hrect);
                }
            }

            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(90, 0, 0, 0), 1f))
            {
                g.DrawEllipse(pen, rect);
            }
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlPlayersCard;
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
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.TableLayoutPanel tlpAvatarPick;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
    }
}