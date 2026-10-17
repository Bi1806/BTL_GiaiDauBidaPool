using PoolTournament.Models;
using PoolTournament.Services;

namespace PoolTournament
{
    public partial class TournamentForm : Form
    {
        // ==========================================
        // MÀU SẮC (đồng bộ với LoginForm / RegisterForm)
        // ==========================================
        private static readonly Color Gold = Color.FromArgb(255, 193, 7);
        private static readonly Color DarkBg = Color.FromArgb(10, 10, 10);
        private static readonly Color PanelBg = Color.FromArgb(20, 20, 20);
        private static readonly Color InputBg = Color.FromArgb(30, 30, 30);
        private static readonly Color Muted = Color.FromArgb(180, 180, 180);

        // Trạng thái giải đấu: giá trị lưu DB <-> chữ hiển thị
        private sealed class StatusItem
        {
            public string Value { get; }
            public string Text { get; }

            public StatusItem(string value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString() => Text;
        }

        private static readonly StatusItem[] Statuses =
        {
            new("draft", "⏳ Sắp diễn ra"),
            new("ongoing", "🔴 Đang diễn ra"),
            new("completed", "✅ Đã kết thúc"),
            new("cancelled", "❌ Đã hủy")
        };

        // ==========================================
        // DỮ LIỆU
        // ==========================================
        private List<TournamentModel> _tournaments = new();
        private List<PlayerModel> _allPlayers = new();
        private Dictionary<Guid, int> _participantCounts = new();

        private List<PlayerModel> _registeredPlayers = new();
        private List<PlayerModel> _availablePlayers = new();
        private HashSet<Guid> _registeredIds = new();

        private Guid? _selectedId;
        private Guid? _participantsLoadedFor;
        private bool _binding;
        private bool _busy;

        // ==========================================
        // CONTROLS
        // ==========================================
        private TextBox txtSearch = null!;
        private ComboBox cboFilter = null!;
        private Button btnRefresh = null!;
        private Button btnOpen = null!;
        private DataGridView dgvTournaments = null!;

        private Panel pnlDetail = null!;
        private TextBox txtTitle = null!;
        private TextBox txtDescription = null!;
        private DateTimePicker dtpStart = null!;
        private DateTimePicker dtpEnd = null!;
        private NumericUpDown nudMax = null!;
        private ComboBox cboStatus = null!;
        private Button btnAdd = null!;
        private Button btnUpdate = null!;
        private Button btnDelete = null!;
        private Button btnClear = null!;

        private Panel pnlPlayers = null!;
        private Label lblPlayers = null!;
        private ListBox lstParticipants = null!;
        private ComboBox cboPlayers = null!;
        private Button btnAddPlayer = null!;
        private Button btnRemovePlayer = null!;

        public TournamentForm()
        {
            InitializeComponent();
            BuildUi();

            this.Load += async (s, e) => await RunAsync(LoadDataAsync);
        }

        private TournamentModel? CurrentTournament =>
            _selectedId.HasValue
                ? _tournaments.FirstOrDefault(t => t.Id == _selectedId.Value)
                : null;

        // ==========================================
        // DỰNG GIAO DIỆN
        // ==========================================
        private void BuildUi()
        {
            this.Text = "QUẢN LÝ GIẢI ĐẤU";
            this.BackColor = DarkBg;
            this.ForeColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1200, 720);

            var lblHeader = new Label
            {
                Text = "🏆 QUẢN LÝ GIẢI ĐẤU",
                ForeColor = Gold,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 12)
            };
            this.Controls.Add(lblHeader);

            // ---------- Thanh tìm kiếm / lọc ----------
            txtSearch = AddTextBox(this, 20, 65, 300);
            txtSearch.PlaceholderText = "Tìm theo tên giải...";
            txtSearch.TextChanged += async (s, e) => await RebindGridAsync(false);

            cboFilter = new ComboBox
            {
                Location = new Point(330, 65),
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                BackColor = InputBg,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10.5f)
            };
            cboFilter.Items.Add(new StatusItem("", "Tất cả trạng thái"));
            cboFilter.Items.AddRange(Statuses.Cast<object>().ToArray());
            cboFilter.SelectedIndex = 0;
            cboFilter.SelectedIndexChanged += async (s, e) => await RebindGridAsync(false);
            this.Controls.Add(cboFilter);

            btnRefresh = MakeButton(this, "⟳ Tải lại", 520, 63, 100, 32, InputBg, Gold);
            btnRefresh.Click += async (s, e) => await RunAsync(LoadDataAsync);

            btnOpen = MakeButton(this, "▶ Vào giải", 630, 63, 110, 32, Gold, Color.Black);
            btnOpen.Click += BtnOpen_Click;

            // ---------- Bảng danh sách giải ----------
            dgvTournaments = new DataGridView
            {
                Location = new Point(20, 105),
                Size = new Size(720, 595),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                BackgroundColor = PanelBg,
                BorderStyle = BorderStyle.None,
                GridColor = Color.FromArgb(50, 50, 50),
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 36,
                RowTemplate = { Height = 32 }
            };
            dgvTournaments.ColumnHeadersDefaultCellStyle.BackColor = Gold;
            dgvTournaments.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvTournaments.ColumnHeadersDefaultCellStyle.SelectionBackColor = Gold;
            dgvTournaments.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTournaments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTournaments.DefaultCellStyle.BackColor = PanelBg;
            dgvTournaments.DefaultCellStyle.ForeColor = Color.White;
            dgvTournaments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 55, 0);
            dgvTournaments.DefaultCellStyle.SelectionForeColor = Gold;
            dgvTournaments.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTournaments.SelectionChanged += Dgv_SelectionChanged;
            dgvTournaments.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0) BtnOpen_Click(s, EventArgs.Empty);
            };
            this.Controls.Add(dgvTournaments);

            BuildDetailPanel();
            BuildPlayersPanel();
        }

        private void BuildDetailPanel()
        {
            pnlDetail = new Panel
            {
                Location = new Point(760, 65),
                Size = new Size(420, 340),
                BackColor = PanelBg,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            this.Controls.Add(pnlDetail);

            AddLabel(pnlDetail, "Tên giải *", 15, 10);
            txtTitle = AddTextBox(pnlDetail, 15, 32, 390);
            txtTitle.MaxLength = 150;

            AddLabel(pnlDetail, "Mô tả", 15, 70);
            txtDescription = AddTextBox(pnlDetail, 15, 92, 390);
            txtDescription.Multiline = true;
            txtDescription.Height = 60;
            txtDescription.ScrollBars = ScrollBars.Vertical;

            AddLabel(pnlDetail, "Ngày bắt đầu", 15, 160);
            dtpStart = new DateTimePicker
            {
                Location = new Point(15, 182),
                Width = 185,
                Format = DateTimePickerFormat.Short
            };
            pnlDetail.Controls.Add(dtpStart);

            AddLabel(pnlDetail, "Ngày kết thúc", 215, 160);
            dtpEnd = new DateTimePicker
            {
                Location = new Point(215, 182),
                Width = 190,
                Format = DateTimePickerFormat.Short
            };
            pnlDetail.Controls.Add(dtpEnd);

            AddLabel(pnlDetail, "Số cơ thủ tối đa", 15, 225);
            nudMax = new NumericUpDown
            {
                Location = new Point(15, 247),
                Width = 185,
                Minimum = 2,
                Maximum = 128,
                Value = 16,
                BackColor = InputBg,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10.5f)
            };
            pnlDetail.Controls.Add(nudMax);

            AddLabel(pnlDetail, "Trạng thái", 215, 225);
            cboStatus = new ComboBox
            {
                Location = new Point(215, 247),
                Width = 190,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                BackColor = InputBg,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10.5f)
            };
            cboStatus.Items.AddRange(Statuses.Cast<object>().ToArray());
            cboStatus.SelectedIndex = 0;
            pnlDetail.Controls.Add(cboStatus);

            btnAdd = MakeButton(pnlDetail, "THÊM", 15, 292, 90, 36, Gold, Color.Black);
            btnUpdate = MakeButton(pnlDetail, "SỬA", 115, 292, 90, 36, Gold, Color.Black);
            btnDelete = MakeButton(pnlDetail, "XÓA", 215, 292, 90, 36, Color.FromArgb(160, 40, 40), Color.White);
            btnClear = MakeButton(pnlDetail, "LÀM MỚI", 315, 292, 90, 36, InputBg, Gold);

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void BuildPlayersPanel()
        {
            pnlPlayers = new Panel
            {
                Location = new Point(760, 415),
                Size = new Size(420, 285),
                BackColor = PanelBg,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            this.Controls.Add(pnlPlayers);

            lblPlayers = new Label
            {
                Text = "Chọn một giải đấu để quản lý cơ thủ",
                ForeColor = Gold,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = false,
                Width = 390,
                Height = 24,
                Location = new Point(15, 10)
            };
            pnlPlayers.Controls.Add(lblPlayers);

            lstParticipants = new ListBox
            {
                Location = new Point(15, 38),
                Size = new Size(390, 150),
                BackColor = InputBg,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10)
            };
            pnlPlayers.Controls.Add(lstParticipants);

            cboPlayers = new ComboBox
            {
                Location = new Point(15, 198),
                Width = 285,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                BackColor = InputBg,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10)
            };
            pnlPlayers.Controls.Add(cboPlayers);

            btnAddPlayer = MakeButton(pnlPlayers, "+ Thêm", 310, 196, 95, 30, Gold, Color.Black);
            btnRemovePlayer = MakeButton(pnlPlayers, "Xóa cơ thủ đã chọn khỏi giải", 15, 238, 390, 32,
                Color.FromArgb(160, 40, 40), Color.White);

            btnAddPlayer.Click += BtnAddPlayer_Click;
            btnRemovePlayer.Click += BtnRemovePlayer_Click;

            RefreshPlayerSection();
        }

        // ---------- Helper tạo control ----------
        private Label AddLabel(Control parent, string text, int x, int y)
        {
            var label = new Label
            {
                Text = text,
                ForeColor = Gold,
                Font = new Font("Segoe UI", 9.5f),
                AutoSize = false,
                Width = 190,
                Height = 22,
                Location = new Point(x, y)
            };
            parent.Controls.Add(label);
            return label;
        }

        private TextBox AddTextBox(Control parent, int x, int y, int width)
        {
            var textBox = new TextBox
            {
                Location = new Point(x, y),
                Width = width,
                BackColor = InputBg,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10.5f)
            };
            textBox.Enter += (s, e) => textBox.BackColor = Color.FromArgb(45, 45, 45);
            textBox.Leave += (s, e) => textBox.BackColor = InputBg;
            parent.Controls.Add(textBox);
            return textBox;
        }

        private Button MakeButton(Control parent, string text, int x, int y, int w, int h, Color back, Color fore)
        {
            var button = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(w, h),
                BackColor = back,
                ForeColor = fore,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold)
            };
            button.FlatAppearance.BorderSize = 0;
            parent.Controls.Add(button);
            return button;
        }

        // ==========================================
        // CHẠY TÁC VỤ BẤT ĐỒNG BỘ (khóa UI + bắt lỗi)
        // ==========================================
        private async Task RunAsync(Func<Task> action)
        {
            if (_busy) return;

            _busy = true;
            this.UseWaitCursor = true;
            pnlDetail.Enabled = false;
            pnlPlayers.Enabled = false;

            try
            {
                await SupabaseClient.InitializeAsync();

                if (SupabaseClient.Instance == null)
                    throw new Exception("Supabase chưa được khởi tạo.");

                await action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Có lỗi xảy ra:\n\n" + ex.Message,
                    "Lỗi Supabase",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                _busy = false;
                this.UseWaitCursor = false;
                pnlDetail.Enabled = true;
                pnlPlayers.Enabled = true;
            }
        }

        // ==========================================
        // TẢI DỮ LIỆU
        // ==========================================
        private async Task LoadDataAsync()
        {
            var client = SupabaseClient.Instance;

            var tournamentRes = await client.From<TournamentModel>().Get();
            _tournaments = tournamentRes.Models;

            var participantRes = await client.From<TournamentParticipantModel>().Get();
            _participantCounts = participantRes.Models
                .GroupBy(p => p.TournamentId)
                .ToDictionary(g => g.Key, g => g.Count());

            var playerRes = await client.From<PlayerModel>().Get();
            _allPlayers = playerRes.Models;

            await RebindGridAsync(true);
        }

        private async Task LoadParticipantsAsync(Guid tournamentId)
        {
            var res = await SupabaseClient.Instance
                .From<TournamentParticipantModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Get();

            // Người dùng đã chọn giải khác trong lúc chờ -> bỏ kết quả cũ
            if (_selectedId != tournamentId) return;

            _registeredIds = res.Models.Select(m => m.PlayerId).ToHashSet();
            _participantCounts[tournamentId] = res.Models.Count;
            _participantsLoadedFor = tournamentId;

            _registeredPlayers = _allPlayers
                .Where(p => _registeredIds.Contains(p.Id))
                .OrderBy(p => p.FullName)
                .ToList();

            _availablePlayers = _allPlayers
                .Where(p => !_registeredIds.Contains(p.Id))
                .OrderBy(p => p.FullName)
                .ToList();
        }

        // ==========================================
        // HIỂN THỊ DANH SÁCH GIẢI ĐẤU
        // ==========================================
        private async Task RebindGridAsync(bool forceParticipants)
        {
            string keyword = txtSearch.Text.Trim();
            string statusFilter = (cboFilter.SelectedItem as StatusItem)?.Value ?? "";

            var rows = _tournaments
                .Where(t => keyword.Length == 0 ||
                            (t.Title ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .Where(t => statusFilter.Length == 0 || t.Status == statusFilter)
                .OrderByDescending(t => t.Status == "ongoing")
                .ThenByDescending(t => t.StartDate)
                .Select(t => new
                {
                    t.Id,
                    Title = t.Title,
                    StartDate = t.StartDate.ToString("dd/MM/yyyy"),
                    EndDate = t.EndDate.ToString("dd/MM/yyyy"),
                    Registered = $"{(_participantCounts.TryGetValue(t.Id, out var c) ? c : 0)}/{t.MaxParticipants}",
                    StatusText = GetStatusText(t.Status)
                })
                .ToList();

            _binding = true;
            try
            {
                dgvTournaments.DataSource = rows;

                if (dgvTournaments.Columns["Id"] != null) dgvTournaments.Columns["Id"].Visible = false;
                SetHeader("Title", "Tên giải", 200);
                SetHeader("StartDate", "Bắt đầu", 90);
                SetHeader("EndDate", "Kết thúc", 90);
                SetHeader("Registered", "Cơ thủ", 70);
                SetHeader("StatusText", "Trạng thái", 120);
                dgvTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Chọn lại dòng đang chọn (nếu còn trong danh sách)
                DataGridViewRow? match = null;
                if (_selectedId.HasValue)
                {
                    foreach (DataGridViewRow row in dgvTournaments.Rows)
                    {
                        if (row.Cells["Id"].Value is Guid g && g == _selectedId.Value)
                        {
                            match = row;
                            break;
                        }
                    }
                }

                if (match != null)
                {
                    dgvTournaments.CurrentCell = match.Cells["Title"];
                    match.Selected = true;
                }
                else
                {
                    dgvTournaments.ClearSelection();
                    dgvTournaments.CurrentCell = null;
                }
            }
            finally
            {
                _binding = false;
            }

            await ShowSelectedAsync(forceParticipants);
        }

        private void SetHeader(string column, string header, float fillWeight)
        {
            var col = dgvTournaments.Columns[column];
            if (col == null) return;
            col.HeaderText = header;
            col.FillWeight = fillWeight;
        }

        private static string GetStatusText(string? status)
        {
            var item = Statuses.FirstOrDefault(s => s.Value == status);
            return item?.Text ?? (status ?? "");
        }

        // ==========================================
        // CHỌN MỘT GIẢI -> ĐỔ LÊN FORM
        // ==========================================
        private async void Dgv_SelectionChanged(object? sender, EventArgs e)
        {
            if (_binding || _busy) return;
            await ShowSelectedAsync(false);
        }

        private Guid? GetGridSelectedId()
        {
            var row = dgvTournaments.CurrentRow;
            if (row == null) return null;
            return row.Cells["Id"].Value is Guid g ? g : null;
        }

        private async Task ShowSelectedAsync(bool forceParticipants)
        {
            var id = GetGridSelectedId();
            var tournament = id.HasValue
                ? _tournaments.FirstOrDefault(t => t.Id == id.Value)
                : null;

            if (tournament == null)
            {
                ClearForm();
                return;
            }

            _selectedId = tournament.Id;
            FillForm(tournament);

            if (forceParticipants || _participantsLoadedFor != tournament.Id)
            {
                try
                {
                    await LoadParticipantsAsync(tournament.Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không tải được danh sách cơ thủ của giải:\n\n" + ex.Message,
                        "Lỗi Supabase",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            RefreshPlayerSection();
        }

        private void FillForm(TournamentModel t)
        {
            txtTitle.Text = t.Title ?? "";
            txtDescription.Text = t.Description ?? "";
            dtpStart.Value = ClampDate(t.StartDate);
            dtpEnd.Value = ClampDate(t.EndDate);
            nudMax.Value = Math.Min(Math.Max(t.MaxParticipants, (int)nudMax.Minimum), (int)nudMax.Maximum);

            int index = Array.FindIndex(Statuses, s => s.Value == t.Status);
            cboStatus.SelectedIndex = index >= 0 ? index : 0;
        }

        private static DateTime ClampDate(DateTime d)
        {
            if (d < DateTimePicker.MinimumDateTime || d > DateTimePicker.MaximumDateTime)
                return DateTime.Today;
            return d;
        }

        private void ClearForm()
        {
            _selectedId = null;
            _participantsLoadedFor = null;
            _registeredIds = new HashSet<Guid>();
            _registeredPlayers = new List<PlayerModel>();
            _availablePlayers = new List<PlayerModel>();

            txtTitle.Clear();
            txtDescription.Clear();
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today;
            nudMax.Value = 16;
            cboStatus.SelectedIndex = 0;

            RefreshPlayerSection();
        }

        // ==========================================
        // KIỂM TRA DỮ LIỆU NHẬP
        // ==========================================
        private bool ValidateInputs(bool isUpdate)
        {
            string title = txtTitle.Text.Trim();

            if (title.Length == 0)
            {
                Warn("Vui lòng nhập tên giải đấu!");
                txtTitle.Focus();
                return false;
            }

            if (title.Length < 3)
            {
                Warn("Tên giải đấu phải có ít nhất 3 ký tự!");
                txtTitle.Focus();
                return false;
            }

            if (dtpEnd.Value.Date < dtpStart.Value.Date)
            {
                Warn("Ngày kết thúc không được trước ngày bắt đầu!");
                dtpEnd.Focus();
                return false;
            }

            Guid? excludeId = isUpdate ? _selectedId : null;
            bool duplicated = _tournaments.Any(t =>
                t.Id != excludeId &&
                string.Equals(t.Title?.Trim(), title, StringComparison.OrdinalIgnoreCase));

            if (duplicated)
            {
                Warn("Đã có giải đấu trùng tên này!");
                txtTitle.Focus();
                return false;
            }

            if (isUpdate && _registeredIds.Count > nudMax.Value)
            {
                Warn($"Giải đã có {_registeredIds.Count} cơ thủ đăng ký, " +
                     "không thể đặt số cơ thủ tối đa thấp hơn con số này!");
                nudMax.Focus();
                return false;
            }

            return true;
        }

        private static void Warn(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ==========================================
        // THÊM / SỬA / XÓA GIẢI ĐẤU
        // ==========================================
        private async void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs(isUpdate: false)) return;

            await RunAsync(async () =>
            {
                var newTournament = new TournamentModel
                {
                    Title = txtTitle.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    StartDate = dtpStart.Value.Date,
                    EndDate = dtpEnd.Value.Date,
                    MaxParticipants = (int)nudMax.Value,
                    Status = (cboStatus.SelectedItem as StatusItem)?.Value ?? "draft",
                    CreatedAt = DateTime.UtcNow
                };

                var res = await SupabaseClient.Instance
                    .From<TournamentModel>()
                    .Insert(newTournament);

                _selectedId = res.Models.FirstOrDefault()?.Id;

                MessageBox.Show("Tạo giải đấu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            });
        }

        private async void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                Warn("Vui lòng chọn giải đấu cần sửa từ danh sách!");
                return;
            }

            if (!ValidateInputs(isUpdate: true)) return;

            Guid id = _selectedId.Value;

            await RunAsync(async () =>
            {
                string title = txtTitle.Text.Trim();
                string description = txtDescription.Text.Trim();
                DateTime start = dtpStart.Value.Date;
                DateTime end = dtpEnd.Value.Date;
                int max = (int)nudMax.Value;
                string status = (cboStatus.SelectedItem as StatusItem)?.Value ?? "draft";

                await SupabaseClient.Instance
                    .From<TournamentModel>()
                    .Where(x => x.Id == id)
                    .Set(x => x.Title, title)
                    .Set(x => x.Description, description)
                    .Set(x => x.StartDate, start)
                    .Set(x => x.EndDate, end)
                    .Set(x => x.MaxParticipants, max)
                    .Set(x => x.Status, status)
                    .Update();

                MessageBox.Show("Cập nhật giải đấu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            });
        }

        private void BtnOpen_Click(object? sender, EventArgs e)
        {
            var tournament = CurrentTournament;
            if (tournament == null)
            {
                Warn("Vui lòng chọn giải đấu cần mở từ danh sách!");
                return;
            }

            var form = new TournamentDetailForm(tournament);

            // Khi đóng, tải lại danh sách để cập nhật trạng thái / số cơ thủ
            form.FormClosed += async (s, ev) => await RunAsync(LoadDataAsync);
            form.Show(this);
        }

        private async void BtnDelete_Click(object? sender, EventArgs e)
        {
            var tournament = CurrentTournament;
            if (tournament == null)
            {
                Warn("Vui lòng chọn giải đấu cần xóa từ danh sách!");
                return;
            }

            int count = _participantCounts.TryGetValue(tournament.Id, out var c) ? c : 0;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa giải \"{tournament.Title}\"?\n\n" +
                (count > 0
                    ? $"Danh sách {count} cơ thủ đã đăng ký cũng sẽ bị xóa.\n"
                    : "") +
                "Toàn bộ bảng đấu, lịch thi đấu và kết quả của giải cũng sẽ bị xóa.\n" +
                "Hành động này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            Guid id = tournament.Id;

            await RunAsync(async () =>
            {
                // Xóa cả bảng đấu, trận đấu, danh sách đăng ký rồi mới xóa giải
                await TournamentService.DeleteTournamentAsync(id);

                _selectedId = null;
                _participantsLoadedFor = null;

                MessageBox.Show("Đã xóa giải đấu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            });
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            _binding = true;
            try
            {
                dgvTournaments.ClearSelection();
                dgvTournaments.CurrentCell = null;
            }
            finally
            {
                _binding = false;
            }

            ClearForm();
            txtTitle.Focus();
        }

        // ==========================================
        // QUẢN LÝ CƠ THỦ THAM GIA GIẢI
        // ==========================================
        private static bool IsOpenForRegistration(TournamentModel t) =>
            t.Status != "completed" && t.Status != "cancelled";

        private void RefreshPlayerSection()
        {
            var tournament = CurrentTournament;

            lstParticipants.Items.Clear();
            cboPlayers.Items.Clear();

            if (tournament == null)
            {
                lblPlayers.Text = "Chọn một giải đấu để quản lý cơ thủ";
                cboPlayers.Enabled = false;
                btnAddPlayer.Enabled = false;
                btnRemovePlayer.Enabled = false;
                return;
            }

            foreach (var p in _registeredPlayers)
                lstParticipants.Items.Add($"{p.FullName}  -  {p.RankLevel}");

            foreach (var p in _availablePlayers)
                cboPlayers.Items.Add($"{p.FullName}  -  {p.RankLevel}");

            cboPlayers.SelectedIndex = -1;

            lblPlayers.Text = $"Cơ thủ tham gia: {_registeredPlayers.Count}/{tournament.MaxParticipants}";

            bool open = IsOpenForRegistration(tournament);
            cboPlayers.Enabled = open;
            btnAddPlayer.Enabled = open;
            btnRemovePlayer.Enabled = open;
        }

        private async void BtnAddPlayer_Click(object? sender, EventArgs e)
        {
            var tournament = CurrentTournament;
            if (tournament == null)
            {
                Warn("Vui lòng chọn một giải đấu trước!");
                return;
            }

            if (!IsOpenForRegistration(tournament))
            {
                Warn("Giải đấu đã kết thúc hoặc đã hủy, không thể thêm cơ thủ!");
                return;
            }

            int index = cboPlayers.SelectedIndex;
            if (index < 0 || index >= _availablePlayers.Count)
            {
                Warn("Vui lòng chọn cơ thủ cần thêm!");
                return;
            }

            if (_registeredIds.Count >= tournament.MaxParticipants)
            {
                Warn($"Giải đã đủ {tournament.MaxParticipants} cơ thủ. " +
                     "Hãy tăng số cơ thủ tối đa nếu muốn thêm.");
                return;
            }

            var player = _availablePlayers[index];
            Guid tournamentId = tournament.Id;

            await RunAsync(async () =>
            {
                if (await TournamentService.HasDrawAsync(tournamentId))
                {
                    Warn("Giải đã bốc thăm nên không thể thêm cơ thủ. " +
                         "Hãy hủy bốc thăm trong màn hình chi tiết giải nếu muốn thay đổi danh sách.");
                    return;
                }

                await SupabaseClient.Instance
                    .From<TournamentParticipantModel>()
                    .Insert(new TournamentParticipantModel
                    {
                        TournamentId = tournamentId,
                        PlayerId = player.Id,
                        RegisteredAt = DateTime.UtcNow
                    });

                await LoadParticipantsAsync(tournamentId);
                await RebindGridAsync(false);
            });
        }

        private async void BtnRemovePlayer_Click(object? sender, EventArgs e)
        {
            var tournament = CurrentTournament;
            if (tournament == null) return;

            int index = lstParticipants.SelectedIndex;
            if (index < 0 || index >= _registeredPlayers.Count)
            {
                Warn("Vui lòng chọn cơ thủ cần xóa khỏi giải!");
                return;
            }

            var player = _registeredPlayers[index];

            var confirm = MessageBox.Show(
                $"Xóa cơ thủ \"{player.FullName}\" khỏi giải \"{tournament.Title}\"?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            Guid tournamentId = tournament.Id;
            Guid playerId = player.Id;

            await RunAsync(async () =>
            {
                if (await TournamentService.HasDrawAsync(tournamentId))
                {
                    Warn("Giải đã bốc thăm nên không thể xóa cơ thủ. " +
                         "Hãy hủy bốc thăm trong màn hình chi tiết giải nếu muốn thay đổi danh sách.");
                    return;
                }

                await SupabaseClient.Instance
                    .From<TournamentParticipantModel>()
                    .Where(x => x.TournamentId == tournamentId && x.PlayerId == playerId)
                    .Delete();

                await LoadParticipantsAsync(tournamentId);
                await RebindGridAsync(false);
            });
        }
    }
}
