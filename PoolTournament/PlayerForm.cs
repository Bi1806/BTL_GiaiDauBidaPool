using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoolTournament
{
    public partial class PlayerForm : Form
    {
        private Guid? _selectedPlayerId = null;
        private string _selectedLocalImagePath = null;

        public PlayerForm()
        {
            InitializeComponent();
            this.Load += PlayerForm_Load;
        }

        private async void PlayerForm_Load(object sender, EventArgs e)
        {
            try
            {
                await SupabaseClient.InitializeAsync();
                await LoadPlayerDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Khởi tạo kết nối Supabase thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Chọn Ảnh & Upload Supabase Storage

        private void BtnChooseAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn ảnh đại diện cho Cơ thủ";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _selectedLocalImagePath = openFileDialog.FileName;
                    txtAvatarUrl.Text = Path.GetFileName(_selectedLocalImagePath);

                    byte[] imageBytes = File.ReadAllBytes(_selectedLocalImagePath);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        if (picAvatar.Image != null) picAvatar.Image.Dispose();
                        picAvatar.Image = new Bitmap(ms); // Dùng new Bitmap thay vì Image.FromStream
                    }
                }
            }
        }

        private async Task<string> UploadAvatarToSupabaseAsync(string localFilePath)
        {
            if (string.IsNullOrEmpty(localFilePath) || !File.Exists(localFilePath))
                return txtAvatarUrl.Text.Trim(); // Giữ nguyên URL cũ nếu không chọn file mới từ máy

            try
            {
                byte[] fileBytes = await File.ReadAllBytesAsync(localFilePath);
                string extension = Path.GetExtension(localFilePath);
                string fileName = $"avatar_{Guid.NewGuid()}{extension}";

                // Upload file lên bucket 'Avatar'
                await SupabaseClient.Instance.Storage
                    .From("Avatar")
                    .Upload(fileBytes, fileName, new Supabase.Storage.FileOptions { Upsert = true });

                // Lấy URL công khai
                string publicUrl = SupabaseClient.Instance.Storage
                    .From("Avatar")
                    .GetPublicUrl(fileName);

                return publicUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi Upload ảnh lên Storage: {ex.Message}", "Cảnh báo Storage", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return txtAvatarUrl.Text.Trim();
            }
        }

        // Hàm hỗ trợ tải ảnh từ Link HTTPS mượt mà không bị lỗi
        private async Task LoadImageFromUrlAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url) || !url.StartsWith("http"))
            {
                if (picAvatar.Image != null) picAvatar.Image.Dispose();
                picAvatar.Image = null;
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(url);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        if (picAvatar.Image != null) picAvatar.Image.Dispose();
                        // Dùng new Bitmap(ms) để copy hoàn toàn dữ liệu ảnh vào bộ nhớ
                        picAvatar.Image = new Bitmap(ms);
                    }
                }
            }
            catch
            {
                if (picAvatar.Image != null) picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }
        }
        #endregion

        #region Tải & Thao tác dữ liệu Supabase

        private async Task LoadPlayerDataAsync()
        {
            try
            {
                if (SupabaseClient.Instance == null) return;

                var response = await SupabaseClient.Instance.From<PlayerModel>().Get();
                var players = response.Models;

                dgvPlayers.DataSource = players.Select(p => new
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Phone = p.Phone,
                    Email = p.Email,
                    RankLevel = p.RankLevel,
                    Status = p.Status,
                    AvatarUrl = p.AvatarUrl
                }).ToList();

                if (dgvPlayers.Columns["Id"] != null) dgvPlayers.Columns["Id"].Visible = false;
                if (dgvPlayers.Columns["AvatarUrl"] != null) dgvPlayers.Columns["AvatarUrl"].Visible = false;

                if (dgvPlayers.Columns["FullName"] != null) dgvPlayers.Columns["FullName"].HeaderText = "Họ và Tên";
                if (dgvPlayers.Columns["Phone"] != null) dgvPlayers.Columns["Phone"].HeaderText = "Số điện thoại";
                if (dgvPlayers.Columns["Email"] != null) dgvPlayers.Columns["Email"].HeaderText = "Email";
                if (dgvPlayers.Columns["RankLevel"] != null) dgvPlayers.Columns["RankLevel"].HeaderText = "Hạng";
                if (dgvPlayers.Columns["Status"] != null) dgvPlayers.Columns["Status"].HeaderText = "Trạng thái";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách cơ thủ: {ex.Message}", "Lỗi Supabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPlayerTournamentsAsync(Guid playerId)
        {
            try
            {
                if (SupabaseClient.Instance == null) return;

                // 1. Truy vấn bảng tournament_participants để lấy danh sách ID giải đấu của cơ thủ này
                var partRes = await SupabaseClient.Instance
                    .From<TournamentParticipantModel>()
                    .Where(x => x.PlayerId == playerId)
                    .Get();

                var participantRecords = partRes.Models;

                // Nếu cơ thủ chưa tham gia giải nào -> Xóa bảng và cập nhật Label
                if (participantRecords == null || participantRecords.Count == 0)
                {
                    dgvTournaments.DataSource = null;
                    lblTotalTournaments.Text = "🏆 Tổng số giải đã tham gia: 0";
                    return;
                }

                // Lấy danh sách ID các giải đấu
                var tournamentIds = participantRecords.Select(x => x.TournamentId).ToList();

                // 2. Truy vấn bảng tournaments để lấy chi tiết thông tin các giải đấu
                var tourRes = await SupabaseClient.Instance
                    .From<TournamentModel>()
                    .Get();

                // Lọc theo các ID đã tham gia & Sắp xếp (Giải đang diễn ra/mới lên đầu)
                var matchingTournaments = tourRes.Models
                    .Where(t => tournamentIds.Contains(t.Id))
                    .OrderByDescending(t => t.Status == "ongoing")
                    .ThenByDescending(t => t.StartDate)
                    .ToList();

                // 3. Tắt AutoSize trước khi gán data để chống đơ UI
                dgvTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                // 4. Format dữ liệu hiển thị lên DataGridView
                dgvTournaments.DataSource = matchingTournaments.Select(t => new
                {
                    Title = t.Title,
                    StartDate = t.StartDate.ToString("dd/MM/yyyy"),
                    EndDate = t.EndDate.ToString("dd/MM/yyyy"),
                    StatusText = GetStatusDisplay(t.Status)
                }).ToList();

                // 5. Đặt tên cột tiếng Việt
                if (dgvTournaments.Columns["Title"] != null)
                {
                    dgvTournaments.Columns["Title"].HeaderText = "Tên giải đấu";
                    dgvTournaments.Columns["Title"].FillWeight = 200;
                }
                if (dgvTournaments.Columns["StartDate"] != null)
                    dgvTournaments.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
                if (dgvTournaments.Columns["EndDate"] != null)
                    dgvTournaments.Columns["EndDate"].HeaderText = "Ngày kết thúc";
                if (dgvTournaments.Columns["StatusText"] != null)
                    dgvTournaments.Columns["StatusText"].HeaderText = "Trạng thái";

                // Bật lại AutoSize
                dgvTournaments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 6. Cập nhật số lượng giải đấu
                int ongoingCount = matchingTournaments.Count(t => t.Status == "ongoing");
                int completedCount = matchingTournaments.Count(t => t.Status == "completed");

                lblTotalTournaments.Text = $"🏆 Tổng số giải: {matchingTournaments.Count} (Đang tham gia: {ongoingCount} | Đã xong: {completedCount})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách giải đấu: {ex.Message}", "Lỗi Supabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm hỗ trợ dịch trạng thái từ Database sang Tiếng Việt có Emoji sinh động
        private string GetStatusDisplay(string status)
        {
            return status switch
            {
                "ongoing" => "🔴 Đang diễn ra",
                "completed" => "✅ Đã kết thúc",
                "draft" => "⏳ Sắp diễn ra",
                "cancelled" => "❌ Đã hủy",
                _ => status
            };
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                string avatarUrl = await UploadAvatarToSupabaseAsync(_selectedLocalImagePath);

                var newPlayer = new PlayerModel
                {
                    FullName = txtFullName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    RankLevel = cbRankLevel.SelectedItem?.ToString(),
                    Status = cbStatus.SelectedItem?.ToString() ?? "active",
                    AvatarUrl = avatarUrl,
                    CreatedAt = DateTime.UtcNow
                };

                await SupabaseClient.Instance.From<PlayerModel>().Insert(newPlayer);

                MessageBox.Show("Thêm cơ thủ mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPlayerDataAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm cơ thủ: {ex.Message}", "Lỗi Supabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!_selectedPlayerId.HasValue)
            {
                MessageBox.Show("Vui lòng chọn cơ thủ cần cập nhật từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            try
            {
                string avatarUrl = await UploadAvatarToSupabaseAsync(_selectedLocalImagePath);

                await SupabaseClient.Instance.From<PlayerModel>()
                    .Where(x => x.Id == _selectedPlayerId.Value)
                    .Set(x => x.FullName, txtFullName.Text.Trim())
                    .Set(x => x.Phone, txtPhone.Text.Trim())
                    .Set(x => x.Email, txtEmail.Text.Trim())
                    .Set(x => x.RankLevel, cbRankLevel.SelectedItem?.ToString())
                    .Set(x => x.Status, cbStatus.SelectedItem?.ToString())
                    .Set(x => x.AvatarUrl, avatarUrl)
                    .Update();

                MessageBox.Show("Cập nhật thông tin cơ thủ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadPlayerDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật cơ thủ: {ex.Message}", "Lỗi Supabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Sự kiện Click vào Bảng & Đổ Dữ Liệu Lên Form


        private void DgvPlayers_SelectionChanged(object sender, EventArgs e)
        {
            PopulateSelectedRowData();
        }

        private async void PopulateSelectedRowData()
        {
            if (dgvPlayers.CurrentRow == null || dgvPlayers.CurrentRow.Cells["Id"].Value == null) return;

            var row = dgvPlayers.CurrentRow;

            if (row.Cells["Id"].Value is Guid playerGuid)
            {
                _selectedPlayerId = playerGuid;
            }
            else if (Guid.TryParse(row.Cells["Id"].Value?.ToString(), out Guid parsedGuid))
            {
                _selectedPlayerId = parsedGuid;
            }

            _selectedLocalImagePath = null;

            txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? string.Empty;
            txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
            cbRankLevel.SelectedItem = row.Cells["RankLevel"].Value?.ToString();
            cbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();

            string avatarUrl = row.Cells["AvatarUrl"].Value?.ToString() ?? string.Empty;
            txtAvatarUrl.Text = avatarUrl;

            // Nạp ảnh bằng HttpClient
            await LoadImageFromUrlAsync(avatarUrl);

            // Tải lịch sử giải đấu tương ứng
            if (_selectedPlayerId.HasValue)
            {
                await LoadPlayerTournamentsAsync(_selectedPlayerId.Value);
            }
        }

        #endregion

        #region Trợ lý & Kiểm tra Form

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedPlayerId = null;
            _selectedLocalImagePath = null;
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAvatarUrl.Clear();
            cbRankLevel.SelectedIndex = -1;
            cbStatus.SelectedIndex = 0;
            if (picAvatar.Image != null) picAvatar.Image.Dispose();
            picAvatar.Image = null;
            dgvTournaments.DataSource = null;
            lblTotalTournaments.Text = "Tổng số giải đã tham gia: 0";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên cơ thủ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }
            return true;
        }

        #endregion
    }
}