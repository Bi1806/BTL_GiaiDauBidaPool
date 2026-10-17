using PoolTournament.Models;
using PoolTournament.Services;

namespace PoolTournament
{
    // ==========================================
    // THEME + HELPER DÙNG CHUNG
    // ==========================================
    internal static class UiTheme
    {
        public static readonly Color Gold = Color.FromArgb(255, 193, 7);
        public static readonly Color DarkBg = Color.FromArgb(10, 10, 10);
        public static readonly Color PanelBg = Color.FromArgb(20, 20, 20);
        public static readonly Color InputBg = Color.FromArgb(30, 30, 30);
        public static readonly Color Muted = Color.FromArgb(180, 180, 180);
        public static readonly Color Danger = Color.FromArgb(160, 40, 40);
        public static readonly Color Ok = Color.FromArgb(76, 175, 80);
        public static readonly Color Warn = Color.FromArgb(255, 152, 0);

        public static Button MakeButton(string text, int w, int h, Color back, Color fore, bool dimWhenDisabled = true)
        {
            var b = new Button
            {
                Text = text,
                Size = new Size(w, h),
                BackColor = back,
                ForeColor = fore,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Margin = new Padding(0, 0, 10, 0)
            };
            b.FlatAppearance.BorderSize = 0;

            if (dimWhenDisabled)
            {
                b.EnabledChanged += (s, e) =>
                {
                    b.BackColor = b.Enabled ? back : Color.FromArgb(38, 38, 38);
                    b.ForeColor = b.Enabled ? fore : Color.FromArgb(110, 110, 110);
                };
            }

            return b;
        }

        public static Label MakeLabel(string text, float size = 10f, bool bold = false, Color? color = null)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                ForeColor = color ?? Color.White,
                Font = new Font("Segoe UI", size, bold ? FontStyle.Bold : FontStyle.Regular)
            };
        }

        public static NumericUpDown MakeNumber(int min, int max, int value, int width = 70)
        {
            return new NumericUpDown
            {
                Minimum = min,
                Maximum = max,
                Value = Math.Clamp(value, min, max),
                Width = width,
                BackColor = InputBg,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10.5f),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(0, 3, 10, 0)
            };
        }

        public static void StyleGrid(DataGridView g)
        {
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.RowHeadersVisible = false;
            g.BackgroundColor = PanelBg;
            g.BorderStyle = BorderStyle.None;
            g.GridColor = Color.FromArgb(50, 50, 50);
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.ColumnHeadersHeight = 34;
            g.RowTemplate.Height = 30;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            g.ColumnHeadersDefaultCellStyle.BackColor = Gold;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Gold;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            g.DefaultCellStyle.BackColor = PanelBg;
            g.DefaultCellStyle.ForeColor = Color.White;
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 55, 0);
            g.DefaultCellStyle.SelectionForeColor = Gold;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(26, 26, 26);
            g.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 55, 0);
            g.AlternatingRowsDefaultCellStyle.SelectionForeColor = Gold;
        }

        public static DataGridViewTextBoxColumn Col(string name, string header, float weight, bool center = false)
        {
            var c = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = weight,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            if (center) c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return c;
        }
    }

    // ==========================================
    // BẢNG TRẬN ĐẤU + THAO TÁC (GÁN BÀN, NHẬP TỈ SỐ)
    // Dùng chung cho tab Vòng bảng và tab Loại trực tiếp
    // ==========================================
    internal sealed class MatchBoard : Panel
    {
        private sealed class TableItem
        {
            public Guid Id { get; }
            public string Text { get; }
            public TableItem(Guid id, string text) { Id = id; Text = text; }
            public override string ToString() => Text;
        }

        private static readonly Font BoldFont = new("Segoe UI", 10f, FontStyle.Bold);

        private readonly DataGridView _grid = new();
        private readonly Label _lblMatch;
        private readonly ComboBox _cboTable;
        private readonly Button _btnAssign;
        private readonly Button _btnSave;
        private readonly NumericUpDown _nud1;
        private readonly NumericUpDown _nud2;

        private readonly Func<Guid, Guid, Task> _onAssign;
        private readonly Func<Guid, int, int, Task> _onResult;

        private List<MatchModel> _matches = new();
        private Dictionary<Guid, PlayerModel> _players = new();
        private Dictionary<Guid, string> _groupNames = new();
        private List<TournamentTable> _tables = new();
        private bool _canEdit;
        private bool _binding;

        public MatchBoard(Func<Guid, Guid, Task> onAssign, Func<Guid, int, int, Task> onResult)
        {
            _onAssign = onAssign;
            _onResult = onResult;

            Dock = DockStyle.Fill;
            BackColor = UiTheme.DarkBg;

            // ---------- lưới ----------
            _grid.Dock = DockStyle.Fill;
            UiTheme.StyleGrid(_grid);
            _grid.Columns.Add(UiTheme.Col("No", "#", 6, true));
            _grid.Columns.Add(UiTheme.Col("Round", "Vòng", 16));
            _grid.Columns.Add(UiTheme.Col("P1", "Cơ thủ 1", 24));
            _grid.Columns.Add(UiTheme.Col("Score", "Tỉ số", 10, true));
            _grid.Columns.Add(UiTheme.Col("P2", "Cơ thủ 2", 24));
            _grid.Columns.Add(UiTheme.Col("Table", "Bàn", 12, true));
            _grid.Columns.Add(UiTheme.Col("Status", "Trạng thái", 12, true));
            _grid.SelectionChanged += (s, e) => { if (!_binding) UpdateActions(); };

            // ---------- thanh thao tác ----------
            var bar = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 96,
                BackColor = UiTheme.PanelBg,
                Padding = new Padding(14, 10, 14, 8)
            };

            _lblMatch = UiTheme.MakeLabel("Chọn một trận để thao tác", 11f, true, UiTheme.Gold);
            _lblMatch.Location = new Point(14, 10);

            var row = new FlowLayoutPanel
            {
                Location = new Point(14, 46),
                AutoSize = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight
            };

            var lblTable = UiTheme.MakeLabel("Bàn:", 10f, false, UiTheme.Muted);
            lblTable.Margin = new Padding(0, 7, 6, 0);

            _cboTable = new ComboBox
            {
                Width = 190,
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                BackColor = UiTheme.InputBg,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10f),
                Margin = new Padding(0, 3, 10, 0)
            };
            _cboTable.SelectedIndexChanged += (s, e) => UpdateAssignEnabled();

            _btnAssign = UiTheme.MakeButton("GÁN BÀN", 100, 32, UiTheme.InputBg, UiTheme.Gold);
            _btnAssign.Margin = new Padding(0, 0, 30, 0);
            _btnAssign.Click += async (s, e) => await AssignAsync();

            var lblScore = UiTheme.MakeLabel("Tỉ số:", 10f, false, UiTheme.Muted);
            lblScore.Margin = new Padding(0, 7, 6, 0);

            _nud1 = UiTheme.MakeNumber(0, 99, 0, 60);
            var dash = UiTheme.MakeLabel("-", 12f, true);
            dash.Margin = new Padding(0, 5, 10, 0);
            _nud2 = UiTheme.MakeNumber(0, 99, 0, 60);

            _btnSave = UiTheme.MakeButton("LƯU KẾT QUẢ", 140, 32, UiTheme.Gold, Color.Black);
            _btnSave.Click += async (s, e) => await SaveAsync();

            row.Controls.AddRange(new Control[]
            {
                lblTable, _cboTable, _btnAssign, lblScore, _nud1, dash, _nud2, _btnSave
            });

            bar.Controls.Add(_lblMatch);
            bar.Controls.Add(row);

            Controls.Add(_grid);
            Controls.Add(bar);
            _grid.BringToFront();

            UpdateActions();
        }

        private MatchModel? SelectedMatch
        {
            get
            {
                if (_grid.SelectedRows.Count == 0) return null;
                if (_grid.SelectedRows[0].Tag is not Guid id) return null;
                return _matches.FirstOrDefault(m => m.Id == id);
            }
        }

        public void SetData(
            List<MatchModel> matches,
            Dictionary<Guid, PlayerModel> players,
            Dictionary<Guid, string> groupNames,
            List<TournamentTable> tables,
            bool canEdit)
        {
            Guid? keep = SelectedMatch?.Id;

            _matches = matches;
            _players = players;
            _groupNames = groupNames;
            _tables = tables;
            _canEdit = canEdit;

            _binding = true;
            _grid.SuspendLayout();
            _grid.Rows.Clear();

            var tableNames = tables.ToDictionary(t => t.Id, t => t.TableName);

            foreach (var m in matches)
            {
                string score = m.Status == MatchStatus.Completed && m.Player1Id.HasValue && m.Player2Id.HasValue
                    ? $"{m.ScorePlayer1} - {m.ScorePlayer2}"
                    : "—";

                string table = m.TableId.HasValue && tableNames.TryGetValue(m.TableId.Value, out var tn) ? tn : "";

                int idx = _grid.Rows.Add(
                    m.MatchNumber,
                    RoundText(m),
                    PlayerName(m.Player1Id, m),
                    score,
                    PlayerName(m.Player2Id, m),
                    table,
                    StatusText(m));

                var r = _grid.Rows[idx];
                r.Tag = m.Id;

                if (m.Status == MatchStatus.Completed && m.WinnerId.HasValue)
                {
                    var winnerCell = m.WinnerId == m.Player1Id ? r.Cells["P1"] : r.Cells["P2"];
                    winnerCell.Style.ForeColor = UiTheme.Gold;
                    winnerCell.Style.Font = BoldFont;
                }

                r.Cells["Status"].Style.ForeColor = m.Status switch
                {
                    MatchStatus.Ongoing => UiTheme.Warn,
                    MatchStatus.Completed => UiTheme.Ok,
                    _ => UiTheme.Muted
                };
            }

            _grid.ResumeLayout();

            // Chọn lại trận đang chọn; nếu không có thì chọn trận kế tiếp cần đấu
            DataGridViewRow? target = null;
            if (keep.HasValue)
                target = _grid.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Tag is Guid g && g == keep.Value);

            target ??= _grid.Rows.Cast<DataGridViewRow>().FirstOrDefault(r =>
            {
                var m = _matches.FirstOrDefault(x => r.Tag is Guid g && x.Id == g);
                return m != null && m.Status != MatchStatus.Completed && m.Player1Id.HasValue && m.Player2Id.HasValue;
            });

            target ??= _grid.Rows.Count > 0 ? _grid.Rows[0] : null;

            _grid.ClearSelection();
            if (target != null)
            {
                target.Selected = true;
                _grid.CurrentCell = target.Cells["P1"];
            }

            _binding = false;
            UpdateActions();
        }

        // ---------- hiển thị ----------
        private string RoundText(MatchModel m)
        {
            if (m.RoundName == RoundCode.Group)
                return m.GroupId.HasValue && _groupNames.TryGetValue(m.GroupId.Value, out var g)
                    ? $"Bảng {g}"
                    : "Vòng bảng";
            return RoundCode.Display(m.RoundName);
        }

        private string PlayerName(Guid? id, MatchModel m)
        {
            if (id.HasValue && _players.TryGetValue(id.Value, out var p)) return p.FullName;
            return m.Status == MatchStatus.Completed ? "BYE" : "(chờ kết quả)";
        }

        private static string StatusText(MatchModel m) => m.Status switch
        {
            MatchStatus.Ongoing => "Đang đấu",
            MatchStatus.Completed => "Hoàn thành",
            _ => "Chờ đấu"
        };

        // ---------- thao tác ----------
        private void UpdateActions()
        {
            var m = SelectedMatch;

            _cboTable.Items.Clear();

            if (m == null)
            {
                _lblMatch.Text = "Chọn một trận để thao tác";
                _cboTable.Enabled = _btnAssign.Enabled = _btnSave.Enabled = false;
                _nud1.Enabled = _nud2.Enabled = false;
                return;
            }

            bool ready = m.Player1Id.HasValue && m.Player2Id.HasValue;
            string n1 = PlayerName(m.Player1Id, m);
            string n2 = PlayerName(m.Player2Id, m);
            _lblMatch.Text = $"{RoundText(m)} · Trận #{m.MatchNumber}:   {n1}   vs   {n2}";

            // Chỉ liệt kê bàn đang hoạt động và còn trống (hoặc bàn đang gán cho chính trận này)
            TableItem? current = null;
            foreach (var t in _tables)
            {
                bool isCurrent = m.TableId == t.Id;
                if (!t.IsActive) continue;
                if (t.Status != TableStatus.Available && !isCurrent) continue;

                var item = new TableItem(t.Id, isCurrent ? $"{t.TableName} (đang gán)" : t.TableName);
                _cboTable.Items.Add(item);
                if (isCurrent) current = item;
            }

            if (current != null) _cboTable.SelectedItem = current;
            else if (_cboTable.Items.Count > 0) _cboTable.SelectedIndex = 0;

            _nud1.Value = m.Status == MatchStatus.Completed ? Math.Clamp(m.ScorePlayer1, 0, 99) : 0;
            _nud2.Value = m.Status == MatchStatus.Completed ? Math.Clamp(m.ScorePlayer2, 0, 99) : 0;

            _nud1.Enabled = _nud2.Enabled = ready && _canEdit;
            _btnSave.Enabled = ready && _canEdit;
            _cboTable.Enabled = ready && _canEdit && m.Status != MatchStatus.Completed;
            UpdateAssignEnabled();
        }

        private void UpdateAssignEnabled()
        {
            var m = SelectedMatch;
            _btnAssign.Enabled = m != null
                && _canEdit
                && m.Status != MatchStatus.Completed
                && m.Player1Id.HasValue && m.Player2Id.HasValue
                && _cboTable.SelectedItem is TableItem;
        }

        private async Task AssignAsync()
        {
            var m = SelectedMatch;
            if (m == null || _cboTable.SelectedItem is not TableItem t) return;
            await _onAssign(m.Id, t.Id);
        }

        private async Task SaveAsync()
        {
            var m = SelectedMatch;
            if (m == null) return;
            await _onResult(m.Id, (int)_nud1.Value, (int)_nud2.Value);
        }
    }

    // ==========================================
    // FORM CHI TIẾT GIẢI ĐẤU
    //   Tab 1: Bốc thăm      Tab 2: Vòng bảng      Tab 3: Loại trực tiếp
    // ==========================================
    public class TournamentDetailForm : Form
    {
        private static readonly Font StepFont = new("Segoe UI", 10.5f);
        private static readonly Font StepFontBold = new("Segoe UI", 10.5f, FontStyle.Bold);
        private static readonly Font StepFontStrike = new("Segoe UI", 10.5f, FontStyle.Strikeout);

        private static readonly string[] StepNames =
            { "Bốc thăm", "Vòng bảng", "Loại trực tiếp", "Kết thúc" };

        // ---------- dữ liệu ----------
        private readonly Guid _tournamentId;
        private TournamentModel _tournament;
        private List<MatchModel> _matches = new();
        private List<GroupStanding> _standings = new();
        private Dictionary<Guid, PlayerModel> _players = new();
        private List<TournamentTable> _tables = new();
        private int _participantCount;

        private bool _busy;
        private bool _firstLoad = true;

        // ---------- controls chung ----------
        private TableLayoutPanel _root = null!;
        private Label _lblTitle = null!;
        private Label _lblStatus = null!;
        private Button _btnReload = null!;
        private readonly Label[] _steps = new Label[4];
        private readonly Button[] _tabButtons = new Button[3];
        private readonly Panel[] _tabs = new Panel[3];
        private readonly System.Windows.Forms.Timer _toastTimer = new() { Interval = 4000 };

        // ---------- tab bốc thăm ----------
        private Label _lblDrawInfo = null!;
        private Label _lblGroupCount = null!;
        private NumericUpDown _nudGroups = null!;
        private Button _btnDrawGroups = null!;
        private Button _btnDrawKo = null!;
        private Button _btnReset = null!;
        private Label _lblDrawHint = null!;
        private FlowLayoutPanel _flpGroups = null!;

        // ---------- tab vòng bảng ----------
        private DataGridView _dgvStandings = null!;
        private MatchBoard _groupBoard = null!;
        private NumericUpDown _nudAdvance = null!;
        private Button _btnGenKo = null!;
        private Label _lblGenHint = null!;

        // ---------- tab loại trực tiếp ----------
        private MatchBoard _koBoard = null!;

        public TournamentDetailForm(TournamentModel tournament)
        {
            _tournament = tournament;
            _tournamentId = tournament.Id;

            BuildUi();

            Load += async (s, e) => await RunAsync(ReloadAsync);
            FormClosed += (s, e) => _toastTimer.Dispose();
        }

        // ==========================================
        // DỰNG GIAO DIỆN
        // ==========================================
        private void BuildUi()
        {
            Text = "CHI TIẾT GIẢI ĐẤU";
            BackColor = UiTheme.DarkBg;
            ForeColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(1200, 720);
            MinimumSize = new Size(1000, 620);

            _root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5,
                BackColor = UiTheme.DarkBg
            };
            _root.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            _root.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            _root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            _root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            _root.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            Controls.Add(_root);

            // ----- hàng 0: tiêu đề -----
            var header = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0) };
            _lblTitle = UiTheme.MakeLabel("🏆 ...", 18f, true, UiTheme.Gold);
            _lblTitle.Location = new Point(20, 10);
            _btnReload = UiTheme.MakeButton("⟳ Tải lại", 100, 32, UiTheme.InputBg, UiTheme.Gold);
            _btnReload.Top = 12;
            _btnReload.Click += async (s, e) => await RunAsync(ReloadAsync);
            header.Controls.Add(_lblTitle);
            header.Controls.Add(_btnReload);
            header.Resize += (s, e) => _btnReload.Left = header.Width - _btnReload.Width - 20;
            _root.Controls.Add(header, 0, 0);

            // ----- hàng 1: các bước -----
            var stepper = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                Padding = new Padding(18, 8, 0, 0),
                Margin = new Padding(0)
            };
            for (int i = 0; i < _steps.Length; i++)
            {
                _steps[i] = UiTheme.MakeLabel(StepNames[i], 10.5f);
                _steps[i].Margin = new Padding(0, 0, 0, 0);
                stepper.Controls.Add(_steps[i]);

                if (i < _steps.Length - 1)
                {
                    var arrow = UiTheme.MakeLabel("   ›   ", 10.5f, false, UiTheme.Muted);
                    arrow.Margin = new Padding(0);
                    stepper.Controls.Add(arrow);
                }
            }
            _root.Controls.Add(stepper, 0, 1);

            // ----- hàng 2: nút chuyển tab -----
            var nav = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                Padding = new Padding(16, 6, 0, 0),
                Margin = new Padding(0)
            };
            string[] tabTitles = { "🎲  BỐC THĂM", "🏅  VÒNG BẢNG", "🥇  LOẠI TRỰC TIẾP" };
            for (int i = 0; i < _tabButtons.Length; i++)
            {
                int index = i;
                _tabButtons[i] = UiTheme.MakeButton(tabTitles[i], 190, 34, UiTheme.InputBg, UiTheme.Gold, false);
                _tabButtons[i].Click += (s, e) => ShowTab(index);
                nav.Controls.Add(_tabButtons[i]);
            }
            _root.Controls.Add(nav, 0, 2);

            // ----- hàng 3: nội dung -----
            var content = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0) };
            _root.Controls.Add(content, 0, 3);

            _tabs[0] = BuildDrawTab();
            _tabs[1] = BuildGroupTab();
            _tabs[2] = BuildKnockoutTab();
            foreach (var t in _tabs) content.Controls.Add(t);

            // ----- hàng 4: thông báo -----
            var statusBar = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0), BackColor = UiTheme.PanelBg };
            _lblStatus = new Label
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(16, 0, 0, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = UiTheme.Ok,
                Font = new Font("Segoe UI", 9.5f)
            };
            statusBar.Controls.Add(_lblStatus);
            _root.Controls.Add(statusBar, 0, 4);

            _toastTimer.Tick += (s, e) =>
            {
                _toastTimer.Stop();
                _lblStatus.Text = "";
            };

            ShowTab(0);
        }

        private Panel BuildDrawTab()
        {
            var pnl = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };

            var ctl = new Panel { Dock = DockStyle.Top, Height = 132, BackColor = UiTheme.PanelBg };

            _lblDrawInfo = UiTheme.MakeLabel("", 11f, true);
            _lblDrawInfo.Location = new Point(16, 14);

            var row = new FlowLayoutPanel
            {
                Location = new Point(16, 50),
                AutoSize = true,
                WrapContents = false
            };

            _lblGroupCount = UiTheme.MakeLabel("Số bảng:", 10f, false, UiTheme.Muted);
            _lblGroupCount.Margin = new Padding(0, 7, 6, 0);
            _nudGroups = UiTheme.MakeNumber(1, 16, 2, 60);

            _btnDrawGroups = UiTheme.MakeButton("🎲 BỐC THĂM CHIA BẢNG", 220, 34, UiTheme.Gold, Color.Black);
            _btnDrawGroups.Click += BtnDrawGroups_Click;

            _btnDrawKo = UiTheme.MakeButton("ĐẤU LOẠI TRỰC TIẾP (không chia bảng)", 340, 34, UiTheme.InputBg, UiTheme.Gold);
            _btnDrawKo.Click += BtnDrawKo_Click;

            _btnReset = UiTheme.MakeButton("HỦY BỐC THĂM", 160, 34, UiTheme.Danger, Color.White);
            _btnReset.Click += BtnReset_Click;

            row.Controls.AddRange(new Control[]
            {
                _lblGroupCount, _nudGroups, _btnDrawGroups, _btnDrawKo, _btnReset
            });

            _lblDrawHint = UiTheme.MakeLabel("", 9.5f, false, UiTheme.Muted);
            _lblDrawHint.Location = new Point(16, 98);

            ctl.Controls.Add(_lblDrawInfo);
            ctl.Controls.Add(row);
            ctl.Controls.Add(_lblDrawHint);

            _flpGroups = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(0, 14, 0, 0)
            };

            pnl.Controls.Add(_flpGroups);
            pnl.Controls.Add(ctl);
            _flpGroups.BringToFront();
            return pnl;
        }

        private Panel BuildGroupTab()
        {
            var pnl = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };

            // ----- thanh tạo nhánh -----
            var top = new Panel { Dock = DockStyle.Top, Height = 48 };
            var row = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                WrapContents = false,
                Padding = new Padding(0, 4, 0, 0)
            };

            var lbl = UiTheme.MakeLabel("Đi tiếp mỗi bảng:", 10f, false, UiTheme.Muted);
            lbl.Margin = new Padding(0, 8, 6, 0);
            _nudAdvance = UiTheme.MakeNumber(1, 8, 2, 60);
            _nudAdvance.ValueChanged += (s, e) => BindStandings();

            _btnGenKo = UiTheme.MakeButton("TẠO NHÁNH LOẠI TRỰC TIẾP ▸", 260, 34, UiTheme.Gold, Color.Black);
            _btnGenKo.Click += BtnGenKo_Click;

            _lblGenHint = UiTheme.MakeLabel("", 9.5f, false, UiTheme.Muted);
            _lblGenHint.Margin = new Padding(0, 10, 0, 0);

            row.Controls.AddRange(new Control[] { lbl, _nudAdvance, _btnGenKo, _lblGenHint });
            top.Controls.Add(row);

            // ----- bảng xếp hạng + danh sách trận -----
            _dgvStandings = new DataGridView { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 8) };
            UiTheme.StyleGrid(_dgvStandings);
            _dgvStandings.Columns.Add(UiTheme.Col("Group", "Bảng", 8, true));
            _dgvStandings.Columns.Add(UiTheme.Col("Rank", "Hạng", 8, true));
            _dgvStandings.Columns.Add(UiTheme.Col("Player", "Cơ thủ", 34));
            _dgvStandings.Columns.Add(UiTheme.Col("Played", "Trận", 9, true));
            _dgvStandings.Columns.Add(UiTheme.Col("Won", "Thắng", 9, true));
            _dgvStandings.Columns.Add(UiTheme.Col("Lost", "Thua", 9, true));
            _dgvStandings.Columns.Add(UiTheme.Col("Diff", "Hiệu số", 11, true));
            _dgvStandings.Columns.Add(UiTheme.Col("Points", "Điểm", 9, true));

            _groupBoard = new MatchBoard(OnAssignAsync, OnResultAsync) { Margin = new Padding(0) };

            var split = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            split.RowStyles.Add(new RowStyle(SizeType.Percent, 38));
            split.RowStyles.Add(new RowStyle(SizeType.Percent, 62));
            split.Controls.Add(_dgvStandings, 0, 0);
            split.Controls.Add(_groupBoard, 0, 1);

            pnl.Controls.Add(split);
            pnl.Controls.Add(top);
            split.BringToFront();
            return pnl;
        }

        private Panel BuildKnockoutTab()
        {
            var pnl = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };

            var note = UiTheme.MakeLabel(
                "Nhập tỉ số xong, người thắng sẽ tự động được đưa vào trận vòng sau.",
                9.5f, false, UiTheme.Muted);
            var noteHost = new Panel { Dock = DockStyle.Top, Height = 28 };
            note.Location = new Point(0, 4);
            noteHost.Controls.Add(note);

            _koBoard = new MatchBoard(OnAssignAsync, OnResultAsync);

            pnl.Controls.Add(_koBoard);
            pnl.Controls.Add(noteHost);
            _koBoard.BringToFront();
            return pnl;
        }

        private void ShowTab(int index)
        {
            for (int i = 0; i < _tabs.Length; i++)
            {
                _tabs[i].Visible = i == index;
                _tabButtons[i].BackColor = i == index ? UiTheme.Gold : UiTheme.InputBg;
                _tabButtons[i].ForeColor = i == index ? Color.Black : UiTheme.Gold;
            }
        }

        // ==========================================
        // CHẠY TÁC VỤ + TẢI DỮ LIỆU
        // ==========================================
        private async Task RunAsync(Func<Task> action)
        {
            if (_busy) return;

            _busy = true;
            UseWaitCursor = true;
            _root.Enabled = false;

            try
            {
                await SupabaseClient.InitializeAsync();
                await action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Không thực hiện được",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _busy = false;
                UseWaitCursor = false;
                _root.Enabled = true;
            }
        }

        private async Task ReloadAsync()
        {
            var db = SupabaseClient.Instance;

            _tournament = await TournamentService.GetTournamentAsync(_tournamentId);
            _matches = await TournamentService.GetMatchesAsync(_tournamentId);
            _standings = await TournamentService.GetStandingsAsync(_tournamentId);

            var players = await db.From<PlayerModel>().Get();
            _players = players.Models.ToDictionary(p => p.Id);

            var tables = await db.From<TournamentTable>().Get();
            _tables = tables.Models
                .OrderBy(t => t.SortOrder)
                .ThenBy(t => t.TableName)
                .ToList();

            var parts = await db.From<TournamentParticipantModel>()
                .Where(x => x.TournamentId == _tournamentId)
                .Get();
            _participantCount = parts.Models.Count;

            RefreshUi();
        }

        private void Toast(string message)
        {
            _lblStatus.ForeColor = UiTheme.Ok;
            _lblStatus.Text = "✓ " + message;
            _toastTimer.Stop();
            _toastTimer.Start();
        }

        // ==========================================
        // CẬP NHẬT GIAO DIỆN THEO DỮ LIỆU
        // ==========================================
        private static string StatusText(string? status) => status switch
        {
            TournamentStatus.Draft => "Sắp diễn ra",
            TournamentStatus.Ongoing => "Đang diễn ra",
            TournamentStatus.Completed => "Đã kết thúc",
            TournamentStatus.Cancelled => "Đã hủy",
            _ => status ?? ""
        };

        private bool HasGroupStage => _matches.Any(m => m.RoundName == RoundCode.Group);
        private bool HasKnockout => _matches.Any(m => RoundCode.IsKnockout(m.RoundName));

        private void RefreshUi()
        {
            _lblTitle.Text = "🏆 " + _tournament.Title;
            Text = "CHI TIẾT GIẢI ĐẤU - " + _tournament.Title;

            int stage = _tournament.Status == TournamentStatus.Completed ? 3
                : HasKnockout ? 2
                : HasGroupStage ? 1
                : 0;

            UpdateStepper(stage);
            UpdateDrawTab();
            BindStandings();
            UpdateGenButton();

            var groupNames = _standings.ToDictionary(s => s.Group.Id, s => s.Group.GroupName);
            bool canEdit = _tournament.Status == TournamentStatus.Ongoing;

            _groupBoard.SetData(
                _matches.Where(m => m.RoundName == RoundCode.Group).ToList(),
                _players, groupNames, _tables, canEdit);

            _koBoard.SetData(
                _matches.Where(m => RoundCode.IsKnockout(m.RoundName)).ToList(),
                _players, groupNames, _tables, canEdit);

            if (_firstLoad)
            {
                _firstLoad = false;
                ShowTab(stage == 0 ? 0 : stage == 1 ? 1 : 2);
            }
        }

        private void UpdateStepper(int stage)
        {
            bool koOnly = HasKnockout && !HasGroupStage;

            for (int i = 0; i < _steps.Length; i++)
            {
                string mark = i < stage ? "✓ " : i == stage ? "● " : "○ ";
                _steps[i].Text = mark + StepNames[i];
                _steps[i].ForeColor = i < stage ? UiTheme.Ok : i == stage ? UiTheme.Gold : UiTheme.Muted;
                _steps[i].Font = i == stage ? StepFontBold : StepFont;

                // Giải loại trực tiếp thuần: bước "Vòng bảng" bị bỏ qua
                if (i == 1 && koOnly)
                {
                    _steps[i].Font = StepFontStrike;
                    _steps[i].ForeColor = UiTheme.Muted;
                    _steps[i].Text = StepNames[i];
                }
            }
        }

        private void UpdateDrawTab()
        {
            bool hasDraw = _matches.Count > 0 || _standings.Count > 0;
            bool open = _tournament.Status != TournamentStatus.Completed
                     && _tournament.Status != TournamentStatus.Cancelled;

            _lblDrawInfo.Text =
                $"Cơ thủ đã đăng ký: {_participantCount}/{_tournament.MaxParticipants}      ·      " +
                $"Trạng thái: {StatusText(_tournament.Status)}";

            _lblGroupCount.Visible = !hasDraw;
            _nudGroups.Visible = !hasDraw;
            _btnDrawGroups.Visible = !hasDraw;
            _btnDrawKo.Visible = !hasDraw;
            _btnReset.Visible = hasDraw;

            // Số bảng tối đa: mỗi bảng cần ít nhất 2 cơ thủ
            int maxGroups = Math.Clamp(_participantCount / 2, 1, 16);
            _nudGroups.Maximum = maxGroups;
            if (_firstLoad) _nudGroups.Value = Math.Clamp(_participantCount / 4, 1, maxGroups);

            bool enough = _participantCount >= 2;
            _btnDrawGroups.Enabled = open && enough;
            _btnDrawKo.Enabled = open && enough;
            _btnReset.Enabled = _tournament.Status != TournamentStatus.Cancelled;

            if (!hasDraw)
            {
                _lblDrawHint.Text = !enough
                    ? "Cần ít nhất 2 cơ thủ đăng ký. Quay lại trang Quản lý giải đấu để thêm cơ thủ."
                    : "Chia bảng theo kiểu snake, mỗi bảng ít nhất 2 cơ thủ và đá vòng tròn một lượt. " +
                      "Sau khi bốc thăm sẽ không thể thêm/xóa cơ thủ.";
            }
            else
            {
                _lblDrawHint.Text = HasGroupStage
                    ? "Đã bốc thăm. Chuyển sang tab Vòng bảng để nhập kết quả."
                    : "Giải đấu loại trực tiếp. Chuyển sang tab Loại trực tiếp để nhập kết quả.";
            }

            BuildGroupCards();
        }

        private void BuildGroupCards()
        {
            _flpGroups.SuspendLayout();

            foreach (var c in _flpGroups.Controls.Cast<Control>().ToList())
            {
                _flpGroups.Controls.Remove(c);
                c.Dispose();
            }

            if (_standings.Count == 0)
            {
                bool noPlayers = !HasKnockout && _participantCount < 2;

                string msg = HasKnockout
                    ? "Giải đấu loại trực tiếp - không có bảng đấu."
                    : noPlayers
                        ? $"Giải này mới có {_participantCount} cơ thủ đăng ký, cần ít nhất 2 cơ thủ để bốc thăm.\n\n" +
                          "Cách thêm cơ thủ:\n" +
                          "  1.  Vào trang Quản lý người chơi và tạo cơ thủ (nếu chưa có).\n" +
                          "  2.  Vào trang Quản lý giải đấu, chọn giải, rồi ở khung \"Cơ thủ tham gia\" chọn cơ thủ và bấm \"+ Thêm\".\n" +
                          "  3.  Quay lại đây, bấm \"Tải lại\" rồi bốc thăm."
                        : "Chưa bốc thăm. Bảng đấu sẽ hiển thị ở đây.";

                var lbl = UiTheme.MakeLabel(msg, 10.5f, false, noPlayers ? UiTheme.Gold : UiTheme.Muted);
                lbl.MaximumSize = new Size(820, 0);
                _flpGroups.Controls.Add(lbl);
            }

            foreach (var gs in _standings)
            {
                var card = new Panel
                {
                    Width = 250,
                    Height = 52 + gs.Rows.Count * 26,
                    BackColor = UiTheme.PanelBg,
                    Margin = new Padding(0, 0, 14, 14)
                };

                var title = UiTheme.MakeLabel($"BẢNG {gs.Group.GroupName}", 12f, true, UiTheme.Gold);
                title.Location = new Point(14, 12);
                card.Controls.Add(title);

                int y = 44;
                foreach (var r in gs.Rows)
                {
                    string rank = string.IsNullOrWhiteSpace(r.Player.RankLevel) ? "" : $"  ({r.Player.RankLevel})";
                    var lbl = UiTheme.MakeLabel($"•  {r.Player.FullName}{rank}", 10f);
                    lbl.AutoSize = false;
                    lbl.Size = new Size(222, 24);
                    lbl.Location = new Point(14, y);
                    card.Controls.Add(lbl);
                    y += 26;
                }

                _flpGroups.Controls.Add(card);
            }

            _flpGroups.ResumeLayout();
        }

        private void BindStandings()
        {
            if (_dgvStandings == null) return;

            // Số người đi tiếp không vượt quá số người của bảng nhỏ nhất
            int smallest = _standings.Count == 0 ? 1 : Math.Max(1, _standings.Min(s => s.Rows.Count));
            if (_nudAdvance.Maximum != smallest)
                _nudAdvance.Maximum = smallest;

            int advance = (int)_nudAdvance.Value;

            _dgvStandings.Rows.Clear();
            foreach (var gs in _standings)
            {
                foreach (var r in gs.Rows)
                {
                    string diff = r.ScoreDiff > 0 ? $"+{r.ScoreDiff}" : r.ScoreDiff.ToString();
                    int idx = _dgvStandings.Rows.Add(
                        gs.Group.GroupName, r.Rank, r.Player.FullName,
                        r.Played, r.Won, r.Lost, diff, r.Points);

                    // Dòng vàng = cơ thủ đi tiếp
                    if (r.Rank <= advance)
                        _dgvStandings.Rows[idx].DefaultCellStyle.ForeColor = UiTheme.Gold;
                }
            }

            _dgvStandings.ClearSelection();
        }

        private void UpdateGenButton()
        {
            var groupMatches = _matches.Where(m => m.RoundName == RoundCode.Group).ToList();
            int pending = groupMatches.Count(m => m.Status != MatchStatus.Completed);

            bool ok = groupMatches.Count > 0
                && pending == 0
                && !HasKnockout
                && _tournament.Status == TournamentStatus.Ongoing;

            _btnGenKo.Enabled = ok;
            _nudAdvance.Enabled = groupMatches.Count > 0 && !HasKnockout;

            _lblGenHint.Text =
                groupMatches.Count == 0 ? "Chưa có vòng bảng."
                : HasKnockout ? "Đã tạo nhánh loại trực tiếp."
                : pending > 0 ? $"Còn {pending} trận vòng bảng chưa có kết quả."
                : "Vòng bảng đã xong. Dòng màu vàng là cơ thủ đi tiếp.";
        }

        // ==========================================
        // SỰ KIỆN NÚT
        // ==========================================
        private async void BtnDrawGroups_Click(object? sender, EventArgs e)
        {
            int groups = (int)_nudGroups.Value;

            var confirm = MessageBox.Show(
                $"Bốc thăm chia {groups} bảng cho {_participantCount} cơ thủ?\n\n" +
                "Sau khi bốc thăm sẽ không thể thêm hoặc xóa cơ thủ khỏi giải.",
                "Xác nhận bốc thăm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            await RunAsync(async () =>
            {
                await TournamentService.DrawGroupStageAsync(_tournamentId, groups);
                await ReloadAsync();
                ShowTab(1);
                Toast("Đã bốc thăm và tạo lịch thi đấu vòng bảng.");
            });
        }

        private async void BtnDrawKo_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"Bốc thăm đấu loại trực tiếp cho {_participantCount} cơ thủ (không chia bảng)?\n\n" +
                "Sau khi bốc thăm sẽ không thể thêm hoặc xóa cơ thủ khỏi giải.",
                "Xác nhận bốc thăm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            await RunAsync(async () =>
            {
                await TournamentService.DrawKnockoutOnlyAsync(_tournamentId);
                await ReloadAsync();
                ShowTab(2);
                Toast("Đã bốc thăm và lập nhánh đấu.");
            });
        }

        private async void BtnReset_Click(object? sender, EventArgs e)
        {
            bool hasResults = _matches.Any(m => m.Status == MatchStatus.Completed
                && m.Player1Id.HasValue && m.Player2Id.HasValue);

            var confirm = MessageBox.Show(
                "Hủy bốc thăm sẽ XÓA toàn bộ bảng đấu, lịch thi đấu" +
                (hasResults ? " và các kết quả đã nhập" : "") + ".\n\n" +
                "Giải sẽ quay về trạng thái \"Sắp diễn ra\". Bạn có chắc không?",
                "Xác nhận hủy bốc thăm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            await RunAsync(async () =>
            {
                await TournamentService.ResetDrawAsync(_tournamentId);
                await ReloadAsync();
                ShowTab(0);
                Toast("Đã hủy bốc thăm.");
            });
        }

        private async void BtnGenKo_Click(object? sender, EventArgs e)
        {
            int advance = (int)_nudAdvance.Value;

            var confirm = MessageBox.Show(
                $"Lấy top {advance} mỗi bảng vào vòng loại trực tiếp?",
                "Tạo nhánh loại trực tiếp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            await RunAsync(async () =>
            {
                await TournamentService.GenerateKnockoutFromGroupsAsync(_tournamentId, advance);
                await ReloadAsync();
                ShowTab(2);
                Toast("Đã tạo nhánh loại trực tiếp.");
            });
        }

        private Task OnAssignAsync(Guid matchId, Guid tableId)
        {
            return RunAsync(async () =>
            {
                await TournamentService.AssignTableAsync(matchId, tableId);
                await ReloadAsync();
                Toast("Đã gán bàn, trận đấu chuyển sang trạng thái đang đấu.");
            });
        }

        private Task OnResultAsync(Guid matchId, int score1, int score2)
        {
            return RunAsync(async () =>
            {
                await TournamentService.UpdateMatchResultAsync(matchId, score1, score2);
                await ReloadAsync();
                Toast("Đã lưu kết quả.");

                if (_tournament.Status == TournamentStatus.Completed)
                {
                    var final = _matches.FirstOrDefault(m => m.RoundName == RoundCode.Knockout(2));
                    string champion = final?.WinnerId != null
                        && _players.TryGetValue(final.WinnerId.Value, out var p)
                        ? p.FullName : "";

                    MessageBox.Show(
                        champion.Length > 0
                            ? $"🏆 Giải đấu đã kết thúc!\n\nNhà vô địch: {champion}"
                            : "🏆 Giải đấu đã kết thúc!",
                        "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
        }
    }
}
