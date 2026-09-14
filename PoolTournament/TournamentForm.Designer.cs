namespace PoolTournament
{
    partial class TournamentForm
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
            lblTournamentName = new Label();
            lblLocation = new Label();
            lblFormat = new Label();
            lblDate = new Label();
            txtTournamentName = new TextBox();
            txtLocation = new TextBox();
            cboFormat = new ComboBox();
            dtpDate = new DateTimePicker();
            btnCreateTournament = new Button();
            dgvTournaments = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colFormat = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTournaments).BeginInit();
            SuspendLayout();
            // 
            // lblTournamentName
            // 
            lblTournamentName.AutoSize = true;
            lblTournamentName.Location = new Point(122, 47);
            lblTournamentName.Name = "lblTournamentName";
            lblTournamentName.Size = new Size(64, 20);
            lblTournamentName.TabIndex = 0;
            lblTournamentName.Text = "Tên giải:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(122, 115);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(73, 20);
            lblLocation.TabIndex = 1;
            lblLocation.Text = "Địa điểm:";
            // 
            // lblFormat
            // 
            lblFormat.AutoSize = true;
            lblFormat.Location = new Point(122, 184);
            lblFormat.Name = "lblFormat";
            lblFormat.Size = new Size(69, 20);
            lblFormat.TabIndex = 2;
            lblFormat.Text = "Thể thức:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(122, 259);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 20);
            lblDate.TabIndex = 3;
            lblDate.Text = "Ngày tổ chức:";
            // 
            // txtTournamentName
            // 
            txtTournamentName.Location = new Point(419, 43);
            txtTournamentName.Name = "txtTournamentName";
            txtTournamentName.Size = new Size(125, 27);
            txtTournamentName.TabIndex = 4;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(419, 115);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(125, 27);
            txtLocation.TabIndex = 5;
            // 
            // cboFormat
            // 
            cboFormat.FormattingEnabled = true;
            cboFormat.Items.AddRange(new object[] { "8-Ball", "9-Ball", "10-Ball", "Straight Pool" });
            cboFormat.Location = new Point(419, 184);
            cboFormat.Name = "cboFormat";
            cboFormat.Size = new Size(151, 28);
            cboFormat.TabIndex = 8;
            cboFormat.SelectedIndexChanged += cboFormat_SelectedIndexChanged;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(419, 259);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 9;
            // 
            // btnCreateTournament
            // 
            btnCreateTournament.Location = new Point(271, 318);
            btnCreateTournament.Name = "btnCreateTournament";
            btnCreateTournament.Size = new Size(127, 29);
            btnCreateTournament.TabIndex = 10;
            btnCreateTournament.Text = "Tạo giải đấu";
            btnCreateTournament.UseVisualStyleBackColor = true;
            btnCreateTournament.Click += btnCreateTournament_Click;
            // 
            // dgvTournaments
            // 
            dgvTournaments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTournaments.Columns.AddRange(new DataGridViewColumn[] { colName, colLocation, colFormat, colDate });
            dgvTournaments.Location = new Point(171, 353);
            dgvTournaments.Name = "dgvTournaments";
            dgvTournaments.RowHeadersWidth = 51;
            dgvTournaments.Size = new Size(300, 188);
            dgvTournaments.TabIndex = 11;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.HeaderText = "Tên giải";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            // 
            // colLocation
            // 
            colLocation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLocation.HeaderText = "Địa điểm";
            colLocation.MinimumWidth = 6;
            colLocation.Name = "colLocation";
            // 
            // colFormat
            // 
            colFormat.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFormat.HeaderText = "Thể thức";
            colFormat.MinimumWidth = 6;
            colFormat.Name = "colFormat";
            // 
            // colDate
            // 
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDate.HeaderText = "Ngày tổ chức";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            // 
            // TournamentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 594);
            Controls.Add(dgvTournaments);
            Controls.Add(btnCreateTournament);
            Controls.Add(dtpDate);
            Controls.Add(cboFormat);
            Controls.Add(txtLocation);
            Controls.Add(txtTournamentName);
            Controls.Add(lblDate);
            Controls.Add(lblFormat);
            Controls.Add(lblLocation);
            Controls.Add(lblTournamentName);
            Name = "TournamentForm";
            Text = "QUẢN LÝ GIẢI ĐẤU";
            ((System.ComponentModel.ISupportInitialize)dgvTournaments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTournamentName;
        private Label lblLocation;
        private Label lblFormat;
        private Label lblDate;
        private TextBox txtTournamentName;
        private TextBox txtLocation;
        private ComboBox cboFormat;
        private DateTimePicker dtpDate;
        private Button btnCreateTournament;
        private DataGridView dgvTournaments;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colFormat;
        private DataGridViewTextBoxColumn colDate;
    }
}