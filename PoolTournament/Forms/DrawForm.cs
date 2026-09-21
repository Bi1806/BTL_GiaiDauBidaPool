using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PoolTournament.Models;

namespace PoolTournament.Forms
{
    public partial class DrawForm : Form
    {
        // Danh sách cơ thủ lấy từ Supabase
        private List<PlayerModel> players = new List<PlayerModel>();

        private Random random = new Random();

        private bool hasDrawn = false;

        public DrawForm()
        {
            InitializeComponent();

            txtTournamentName.Text = "Giải Pool Tournament";

            lblPlayerCount.Text = "Số cơ thủ: 0";

            this.Load += DrawForm_Load;
        }

        // =========================================================
        // LOAD DANH SÁCH CƠ THỦ TỪ SUPABASE
        // =========================================================

        private async void DrawForm_Load(object sender, EventArgs e)
        {
            try
            {
                await SupabaseClient.InitializeAsync();

                await LoadPlayersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách cơ thủ!\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // LẤY CƠ THỦ TỪ BẢNG PLAYERS
        // =========================================================

        private async System.Threading.Tasks.Task LoadPlayersAsync()
        {
            try
            {
                if (SupabaseClient.Instance == null)
                {
                    MessageBox.Show(
                        "Supabase chưa được khởi tạo!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                var response =
                    await SupabaseClient.Instance
                    .From<PlayerModel>()
                    .Get();

                players = response.Models;

                lstPlayers.Items.Clear();

                foreach (var player in players)
                {
                    lstPlayers.Items.Add(
                        $"{player.FullName}  -  {player.RankLevel}"
                    );
                }

                UpdatePlayerCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tải danh sách cơ thủ:\n\n" + ex.Message,
                    "Lỗi Supabase",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================================================
        // CẬP NHẬT SỐ LƯỢNG
        // =========================================================

        private void UpdatePlayerCount()
        {
            lblPlayerCount.Text =
                $"Số cơ thủ: {players.Count}";
        }

        // =========================================================
        // BỐC THĂM
        // =========================================================

        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã bốc thăm chưa
            if (hasDrawn)
            {
                MessageBox.Show(
                    "Giải đấu đã được bốc thăm!\n\n" +
                    "Nếu muốn bốc lại, hãy nhấn nút BỐC LẠI.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            string tournamentName =
                txtTournamentName.Text.Trim();

            if (string.IsNullOrWhiteSpace(tournamentName))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên giải đấu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTournamentName.Focus();
                return;
            }

            if (players.Count < 2)
            {
                MessageBox.Show(
                    "Cần ít nhất 2 cơ thủ để bốc thăm!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Tạo bản sao để không thay đổi danh sách gốc
            List<PlayerModel> shuffledPlayers =
                new List<PlayerModel>(players);

            // Xáo trộn Fisher-Yates
            for (int i = shuffledPlayers.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                PlayerModel temp = shuffledPlayers[i];

                shuffledPlayers[i] =
                    shuffledPlayers[j];

                shuffledPlayers[j] = temp;
            }

            // Xóa kết quả cũ
            lstResult.Items.Clear();

            lstResult.Items.Add(
                "========================================"
            );

            lstResult.Items.Add(
                "          KẾT QUẢ BỐC THĂM"
            );

            lstResult.Items.Add(
                "========================================"
            );

            lstResult.Items.Add("");

            lstResult.Items.Add(
                "Giải đấu: " + tournamentName
            );

            lstResult.Items.Add(
                "Số cơ thủ: " + shuffledPlayers.Count
            );

            lstResult.Items.Add("");

            int matchNumber = 1;

            // Chia thành từng cặp
            for (int i = 0; i < shuffledPlayers.Count; i += 2)
            {
                PlayerModel player1 =
                    shuffledPlayers[i];

                if (i + 1 < shuffledPlayers.Count)
                {
                    PlayerModel player2 =
                        shuffledPlayers[i + 1];

                    lstResult.Items.Add(
                        $"TRẬN {matchNumber}: " +
                        $"{player1.FullName}  VS  {player2.FullName}"
                    );

                    matchNumber++;
                }
                else
                {
                    // Số cơ thủ lẻ
                    lstResult.Items.Add(
                        $"TRẬN {matchNumber}: " +
                        $"{player1.FullName}  →  BYE"
                    );
                }

                lstResult.Items.Add("");
            }

            // Đánh dấu đã bốc thăm
            hasDrawn = true;

            // Khóa nút BỐC THĂM
            btnDraw.Enabled = false;

            MessageBox.Show(
                "Bốc thăm hoàn tất!",
                "Bốc thăm",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // =========================================================
        // BỐC THĂM LẠI
        // =========================================================

        private void btnRedraw_Click(object sender, EventArgs e)
        {
            if (players.Count < 2)
            {
                MessageBox.Show(
                    "Cần ít nhất 2 cơ thủ để bốc thăm!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Cho phép bốc lại
            hasDrawn = false;

            // Mở lại nút BỐC THĂM
            btnDraw.Enabled = true;

            // Bốc thăm lại
            btnDraw_Click(sender, e);
        }

        // =========================================================
        // TẢI LẠI DANH SÁCH
        // =========================================================

        private async void btnClear_Click(object sender, EventArgs e)
        {
            await LoadPlayersAsync();

            lstResult.Items.Clear();
        }
    }
}