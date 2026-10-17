using PoolTournament.Models;

namespace PoolTournament.Services
{
    // ==========================================
    // HẰNG SỐ
    // ==========================================
    public static class MatchStatus
    {
        public const string Pending = "pending";
        public const string Ongoing = "ongoing";
        public const string Completed = "completed";
    }

    public static class TableStatus
    {
        // Sửa lại cho khớp giá trị bạn đang dùng trong bảng "tables"
        public const string Available = "available";
        public const string InUse = "in_use";
    }

    public static class TournamentStatus
    {
        public const string Draft = "draft";
        public const string Ongoing = "ongoing";
        public const string Completed = "completed";
        public const string Cancelled = "cancelled";
    }

    public static class RoundCode
    {
        public const string Group = "GROUP";

        public static string Knockout(int players) => $"KO_{players}";

        public static bool IsKnockout(string? round) =>
            round != null && round.StartsWith("KO_", StringComparison.Ordinal);

        public static int KnockoutSize(string round) => int.Parse(round.Substring(3));

        public static string Display(string? round)
        {
            if (round == Group) return "Vòng bảng";
            if (!IsKnockout(round)) return round ?? "";

            return KnockoutSize(round!) switch
            {
                2 => "Chung kết",
                4 => "Bán kết",
                8 => "Tứ kết",
                var n => $"Vòng 1/{n / 2}"
            };
        }
    }

    // ==========================================
    // DTO BẢNG XẾP HẠNG
    // ==========================================
    public record StandingRow(
        PlayerModel Player, int Played, int Won, int Lost,
        int Points, int ScoreDiff, int Rank);

    public record GroupStanding(GroupModel Group, List<StandingRow> Rows);

    // ==========================================
    // SERVICE
    // ==========================================
    public static class TournamentService
    {
        private const int PointsPerWin = 3;

        private static Supabase.Client Db =>
            SupabaseClient.Instance
            ?? throw new InvalidOperationException("Supabase chưa được khởi tạo.");

        // ---------- ĐỌC DỮ LIỆU ----------

        public static async Task<TournamentModel> GetTournamentAsync(Guid tournamentId)
        {
            var t = await Db.From<TournamentModel>()
                .Where(x => x.Id == tournamentId)
                .Single();

            return t ?? throw new InvalidOperationException("Không tìm thấy giải đấu.");
        }

        public static async Task<List<MatchModel>> GetMatchesAsync(Guid tournamentId)
        {
            var res = await Db.From<MatchModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Get();

            return res.Models
                .OrderBy(m => m.RoundName == RoundCode.Group ? 0 : 1)
                .ThenByDescending(m => RoundCode.IsKnockout(m.RoundName)
                    ? RoundCode.KnockoutSize(m.RoundName) : 0)
                .ThenBy(m => m.MatchNumber)
                .ToList();
        }

        public static async Task<bool> HasDrawAsync(Guid tournamentId)
        {
            var matches = await Db.From<MatchModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Get();
            if (matches.Models.Count > 0) return true;

            var groups = await Db.From<GroupModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Get();
            return groups.Models.Count > 0;
        }

        private static async Task<List<PlayerModel>> GetParticipantsAsync(Guid tournamentId)
        {
            var parts = await Db.From<TournamentParticipantModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Get();

            var ids = parts.Models.Select(p => p.PlayerId).ToHashSet();
            var players = await Db.From<PlayerModel>().Get();

            return players.Models.Where(p => ids.Contains(p.Id)).ToList();
        }

        // ---------- BỐC THĂM VÒNG BẢNG ----------

        /// <summary>
        /// Chia cơ thủ đã đăng ký vào các bảng (snake), tạo lịch vòng tròn một lượt.
        /// </summary>
        public static async Task DrawGroupStageAsync(Guid tournamentId, int groupCount)
        {
            if (groupCount < 1 || groupCount > 26)
                throw new ArgumentException("Số bảng phải từ 1 đến 26.");

            var tournament = await GetTournamentAsync(tournamentId);
            EnsureNotClosed(tournament);

            if (await HasDrawAsync(tournamentId))
                throw new InvalidOperationException(
                    "Giải đã được bốc thăm. Hãy hủy bốc thăm trước khi bốc lại.");

            var players = await GetParticipantsAsync(tournamentId);
            if (players.Count < groupCount * 2)
                throw new InvalidOperationException(
                    $"Cần ít nhất {groupCount * 2} cơ thủ để chia {groupCount} bảng " +
                    $"(hiện có {players.Count}).");

            Shuffle(players);

            // 1. Tạo bảng
            var groupModels = Enumerable.Range(0, groupCount)
                .Select(i => new GroupModel
                {
                    TournamentId = tournamentId,
                    GroupName = ((char)('A' + i)).ToString()
                })
                .ToList();

            var groupRes = await Db.From<GroupModel>().Insert(groupModels);
            var groupByName = groupRes.Models.ToDictionary(g => g.GroupName);

            // 2. Chia cơ thủ kiểu snake: A B C D | D C B A | A B C D ...
            var membership = Enumerable.Range(0, groupCount)
                .ToDictionary(i => i, _ => new List<Guid>());

            for (int i = 0; i < players.Count; i++)
            {
                int row = i / groupCount;
                int col = i % groupCount;
                if (row % 2 == 1) col = groupCount - 1 - col;
                membership[col].Add(players[i].Id);
            }

            var groupPlayers = new List<GroupPlayerModel>();
            for (int g = 0; g < groupCount; g++)
            {
                var group = groupByName[((char)('A' + g)).ToString()];
                foreach (var pid in membership[g])
                    groupPlayers.Add(new GroupPlayerModel { GroupId = group.Id, PlayerId = pid });
            }

            await Db.From<GroupPlayerModel>().Insert(groupPlayers);

            // 3. Lịch vòng tròn
            var matches = new List<MatchModel>();
            int number = 1;
            for (int g = 0; g < groupCount; g++)
            {
                var group = groupByName[((char)('A' + g)).ToString()];
                foreach (var (a, b) in RoundRobinPairs(membership[g]))
                {
                    matches.Add(new MatchModel
                    {
                        TournamentId = tournamentId,
                        GroupId = group.Id,
                        RoundName = RoundCode.Group,
                        MatchNumber = number++,
                        Player1Id = a,
                        Player2Id = b,
                        Status = MatchStatus.Pending
                    });
                }
            }

            await Db.From<MatchModel>().Insert(matches);
            await SetTournamentStatusAsync(tournamentId, TournamentStatus.Ongoing);
        }

        // ---------- NHÁNH LOẠI TRỰC TIẾP ----------

        /// <summary>
        /// Giải chỉ đấu loại trực tiếp (không có vòng bảng): bốc thăm thẳng vào nhánh.
        /// </summary>
        public static async Task DrawKnockoutOnlyAsync(Guid tournamentId)
        {
            var tournament = await GetTournamentAsync(tournamentId);
            EnsureNotClosed(tournament);

            if (await HasDrawAsync(tournamentId))
                throw new InvalidOperationException(
                    "Giải đã được bốc thăm. Hãy hủy bốc thăm trước khi bốc lại.");

            var players = await GetParticipantsAsync(tournamentId);
            if (players.Count < 2)
                throw new InvalidOperationException("Cần ít nhất 2 cơ thủ để bốc thăm.");

            Shuffle(players);

            var matches = BuildKnockout(tournamentId, players);
            await Db.From<MatchModel>().Insert(matches);
            await SetTournamentStatusAsync(tournamentId, TournamentStatus.Ongoing);
        }

        /// <summary>
        /// Sau khi xong vòng bảng: lấy top N mỗi bảng và dựng nhánh loại trực tiếp.
        /// </summary>
        public static async Task GenerateKnockoutFromGroupsAsync(Guid tournamentId, int advancePerGroup = 2)
        {
            if (advancePerGroup < 1)
                throw new ArgumentException("Số cơ thủ đi tiếp mỗi bảng phải >= 1.");

            var tournament = await GetTournamentAsync(tournamentId);
            EnsureNotClosed(tournament);

            var matches = await GetMatchesAsync(tournamentId);
            var groupMatches = matches.Where(m => m.RoundName == RoundCode.Group).ToList();

            if (groupMatches.Count == 0)
                throw new InvalidOperationException("Giải chưa có vòng bảng.");

            if (groupMatches.Any(m => m.Status != MatchStatus.Completed))
                throw new InvalidOperationException(
                    "Vẫn còn trận vòng bảng chưa có kết quả.");

            if (matches.Any(m => RoundCode.IsKnockout(m.RoundName)))
                throw new InvalidOperationException("Nhánh đấu đã được tạo.");

            var standings = await GetStandingsAsync(tournamentId);

            // Hạt giống: nhất các bảng, rồi nhì các bảng, ...
            // (A1 B1 A2 B2 -> A1 gặp B2, B1 gặp A2: tránh gặp lại cùng bảng ở vòng đầu)
            var seeded = new List<PlayerModel>();
            for (int rank = 1; rank <= advancePerGroup; rank++)
            {
                foreach (var gs in standings)
                {
                    var row = gs.Rows.FirstOrDefault(r => r.Rank == rank);
                    if (row != null) seeded.Add(row.Player);
                }
            }

            if (seeded.Count < 2)
                throw new InvalidOperationException("Không đủ cơ thủ để lập nhánh đấu.");

            var ko = BuildKnockout(tournamentId, seeded);
            await Db.From<MatchModel>().Insert(ko);
        }

        private static List<MatchModel> BuildKnockout(Guid tournamentId, List<PlayerModel> seeded)
        {
            int q = seeded.Count;
            int size = 1;
            while (size < q) size *= 2;

            var order = SeedOrder(size);

            var rounds = new List<List<MatchModel>>();
            for (int n = size; n >= 2; n /= 2)
            {
                var list = new List<MatchModel>();
                for (int i = 0; i < n / 2; i++)
                {
                    list.Add(new MatchModel
                    {
                        TournamentId = tournamentId,
                        RoundName = RoundCode.Knockout(n),
                        MatchNumber = i + 1,
                        Status = MatchStatus.Pending
                    });
                }
                rounds.Add(list);
            }

            var first = rounds[0];
            for (int i = 0; i < first.Count; i++)
            {
                int s1 = order[2 * i];
                int s2 = order[2 * i + 1];
                first[i].Player1Id = s1 <= q ? seeded[s1 - 1].Id : null;
                first[i].Player2Id = s2 <= q ? seeded[s2 - 1].Id : null;
            }

            // BYE: cơ thủ không có đối thủ đi thẳng vào vòng sau
            if (rounds.Count > 1)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    var m = first[i];
                    bool hasP1 = m.Player1Id.HasValue;
                    bool hasP2 = m.Player2Id.HasValue;
                    if (hasP1 == hasP2) continue;

                    Guid winner = hasP1 ? m.Player1Id!.Value : m.Player2Id!.Value;
                    m.WinnerId = winner;
                    m.Status = MatchStatus.Completed;
                    PutInSlot(rounds[1][i / 2], m.MatchNumber, winner);
                }
            }

            return rounds.SelectMany(r => r).ToList();
        }

        // Thứ tự hạt giống trong nhánh chuẩn: 1v8, 4v5, 2v7, 3v6 ...
        private static List<int> SeedOrder(int size)
        {
            var order = new List<int> { 1 };
            while (order.Count < size)
            {
                int next = order.Count * 2;
                order = order.SelectMany(s => new[] { s, next + 1 - s }).ToList();
            }
            return order;
        }

        private static void PutInSlot(MatchModel next, int fromMatchNumber, Guid playerId)
        {
            if (fromMatchNumber % 2 == 1) next.Player1Id = playerId;
            else next.Player2Id = playerId;
        }

        // ---------- KẾT QUẢ TRẬN ĐẤU ----------

        public static async Task UpdateMatchResultAsync(Guid matchId, int score1, int score2)
        {
            var match = await Db.From<MatchModel>()
                .Where(x => x.Id == matchId)
                .Single()
                ?? throw new InvalidOperationException("Không tìm thấy trận đấu.");

            if (!match.Player1Id.HasValue || !match.Player2Id.HasValue)
                throw new InvalidOperationException("Trận đấu chưa đủ 2 cơ thủ.");

            if (score1 < 0 || score2 < 0)
                throw new ArgumentException("Tỉ số không được âm.");

            if (score1 == score2)
                throw new ArgumentException("Trận Pool không có kết quả hòa.");

            var tournament = await GetTournamentAsync(match.TournamentId);
            if (tournament.Status != TournamentStatus.Ongoing)
                throw new InvalidOperationException("Giải đấu không ở trạng thái đang diễn ra.");

            Guid winner = score1 > score2 ? match.Player1Id.Value : match.Player2Id.Value;
            bool isKnockout = RoundCode.IsKnockout(match.RoundName);

            // Đã có nhánh loại trực tiếp thì không cho sửa kết quả vòng bảng (vì nhánh đã dựng từ kết quả đó)
            if (match.RoundName == RoundCode.Group)
            {
                var existing = await GetMatchesAsync(match.TournamentId);
                if (existing.Any(m => RoundCode.IsKnockout(m.RoundName)))
                    throw new InvalidOperationException(
                        "Đã tạo nhánh loại trực tiếp, không thể sửa kết quả vòng bảng.");
            }

            // Tìm trận vòng sau (nếu có) và chặn sửa nếu vòng sau đã bắt đầu
            MatchModel? next = null;
            int size = isKnockout ? RoundCode.KnockoutSize(match.RoundName) : 0;
            if (isKnockout && size > 2)
            {
                var all = await GetMatchesAsync(match.TournamentId);
                string nextRound = RoundCode.Knockout(size / 2);
                int nextNumber = (match.MatchNumber + 1) / 2;
                next = all.FirstOrDefault(m => m.RoundName == nextRound && m.MatchNumber == nextNumber);

                if (next != null && next.Status != MatchStatus.Pending)
                    throw new InvalidOperationException(
                        "Trận vòng sau đã bắt đầu, không thể sửa kết quả trận này.");
            }

            // 1. Lưu kết quả
            await Db.From<MatchModel>()
                .Where(x => x.Id == matchId)
                .Set(x => x.ScorePlayer1, score1)
                .Set(x => x.ScorePlayer2, score2)
                .Set(x => x.WinnerId, (Guid?)winner)
                .Set(x => x.Status, MatchStatus.Completed)
                .Update();

            // 2. Trả bàn
            if (match.TableId.HasValue)
                await ReleaseTableAsync(match.TableId.Value);

            // 3. Hệ quả theo loại trận
            if (match.RoundName == RoundCode.Group && match.GroupId.HasValue)
            {
                await SyncGroupStatsAsync(match.TournamentId, match.GroupId.Value);
            }
            else if (next != null)
            {
                Guid nextId = next.Id;
                if (match.MatchNumber % 2 == 1)
                    await Db.From<MatchModel>().Where(x => x.Id == nextId)
                        .Set(x => x.Player1Id, (Guid?)winner).Update();
                else
                    await Db.From<MatchModel>().Where(x => x.Id == nextId)
                        .Set(x => x.Player2Id, (Guid?)winner).Update();
            }
            else if (isKnockout && size == 2)
            {
                // Chung kết xong -> giải kết thúc
                await SetTournamentStatusAsync(match.TournamentId, TournamentStatus.Completed);
            }
        }

        // ---------- BẢNG XẾP HẠNG ----------

        public static async Task<List<GroupStanding>> GetStandingsAsync(Guid tournamentId)
        {
            var groupRes = await Db.From<GroupModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Get();
            var groups = groupRes.Models.OrderBy(g => g.GroupName).ToList();

            var matches = await GetMatchesAsync(tournamentId);
            var playerRes = await Db.From<PlayerModel>().Get();
            var players = playerRes.Models.ToDictionary(p => p.Id);

            var result = new List<GroupStanding>();

            foreach (var g in groups)
            {
                var gpRes = await Db.From<GroupPlayerModel>()
                    .Where(x => x.GroupId == g.Id)
                    .Get();

                var done = matches
                    .Where(m => m.GroupId == g.Id && m.Status == MatchStatus.Completed)
                    .ToList();

                var rows = new List<StandingRow>();
                foreach (var gp in gpRes.Models)
                {
                    if (!players.TryGetValue(gp.PlayerId, out var player)) continue;

                    var games = done
                        .Where(m => m.Player1Id == gp.PlayerId || m.Player2Id == gp.PlayerId)
                        .ToList();

                    int won = games.Count(m => m.WinnerId == gp.PlayerId);
                    int diff = games.Sum(m => m.Player1Id == gp.PlayerId
                        ? m.ScorePlayer1 - m.ScorePlayer2
                        : m.ScorePlayer2 - m.ScorePlayer1);

                    rows.Add(new StandingRow(player, games.Count, won, games.Count - won,
                        won * PointsPerWin, diff, 0));
                }

                // Điểm -> hiệu số -> số trận thắng -> tên
                var ranked = rows
                    .OrderByDescending(r => r.Points)
                    .ThenByDescending(r => r.ScoreDiff)
                    .ThenByDescending(r => r.Won)
                    .ThenBy(r => r.Player.FullName)
                    .Select((r, i) => r with { Rank = i + 1 })
                    .ToList();

                result.Add(new GroupStanding(g, ranked));
            }

            return result;
        }

        // Đồng bộ cột thống kê trong group_players theo kết quả thực tế
        private static async Task SyncGroupStatsAsync(Guid tournamentId, Guid groupId)
        {
            var standings = await GetStandingsAsync(tournamentId);
            var gs = standings.FirstOrDefault(s => s.Group.Id == groupId);
            if (gs == null) return;

            var gpRes = await Db.From<GroupPlayerModel>()
                .Where(x => x.GroupId == groupId)
                .Get();

            foreach (var gp in gpRes.Models)
            {
                var row = gs.Rows.FirstOrDefault(r => r.Player.Id == gp.PlayerId);
                if (row == null) continue;

                Guid id = gp.Id;
                await Db.From<GroupPlayerModel>()
                    .Where(x => x.Id == id)
                    .Set(x => x.MatchesPlayed, row.Played)
                    .Set(x => x.MatchesWon, row.Won)
                    .Set(x => x.MatchesLost, row.Lost)
                    .Set(x => x.Points, row.Points)
                    .Update();
            }
        }

        // ---------- BÀN BIDA ----------

        public static async Task AssignTableAsync(Guid matchId, Guid tableId)
        {
            var match = await Db.From<MatchModel>()
                .Where(x => x.Id == matchId)
                .Single()
                ?? throw new InvalidOperationException("Không tìm thấy trận đấu.");

            if (match.Status == MatchStatus.Completed)
                throw new InvalidOperationException("Trận đấu đã kết thúc.");

            if (!match.Player1Id.HasValue || !match.Player2Id.HasValue)
                throw new InvalidOperationException("Trận đấu chưa đủ 2 cơ thủ.");

            var table = await Db.From<TournamentTable>()
                .Where(x => x.Id == tableId)
                .Single()
                ?? throw new InvalidOperationException("Không tìm thấy bàn.");

            if (!table.IsActive)
                throw new InvalidOperationException("Bàn này đang ngưng hoạt động.");

            bool sameTable = match.TableId == tableId;
            if (!sameTable && table.Status != TableStatus.Available)
                throw new InvalidOperationException($"Bàn \"{table.TableName}\" đang không trống.");

            // Đổi bàn: trả bàn cũ
            if (match.TableId.HasValue && !sameTable)
                await ReleaseTableAsync(match.TableId.Value);

            table.Status = TableStatus.InUse;
            table.CurrentMatchId = matchId;
            table.UpdatedAt = DateTime.UtcNow;
            await Db.From<TournamentTable>().Update(table);

            await Db.From<MatchModel>()
                .Where(x => x.Id == matchId)
                .Set(x => x.TableId, (Guid?)tableId)
                .Set(x => x.Status, MatchStatus.Ongoing)
                .Update();
        }

        public static async Task ReleaseTableAsync(Guid tableId)
        {
            var table = await Db.From<TournamentTable>()
                .Where(x => x.Id == tableId)
                .Single();
            if (table == null) return;

            table.Status = TableStatus.Available;
            table.CurrentMatchId = null; // cần NullValueHandling.Include trên model (xem hướng dẫn)
            table.UpdatedAt = DateTime.UtcNow;
            await Db.From<TournamentTable>().Update(table);
        }

        // ---------- HỦY BỐC THĂM / XÓA GIẢI ----------

        public static async Task ResetDrawAsync(Guid tournamentId)
        {
            var matches = await GetMatchesAsync(tournamentId);

            // Trả các bàn đang gắn với trận của giải này (tránh vướng khóa ngoại)
            var matchIds = matches.Select(m => m.Id).ToHashSet();
            var tablesRes = await Db.From<TournamentTable>().Get();
            foreach (var t in tablesRes.Models)
            {
                if (t.CurrentMatchId.HasValue && matchIds.Contains(t.CurrentMatchId.Value))
                    await ReleaseTableAsync(t.Id);
            }

            await Db.From<MatchModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Delete();

            var groups = await Db.From<GroupModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Get();

            foreach (var g in groups.Models)
            {
                Guid gid = g.Id;
                await Db.From<GroupPlayerModel>().Where(x => x.GroupId == gid).Delete();
            }

            await Db.From<GroupModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Delete();

            await SetTournamentStatusAsync(tournamentId, TournamentStatus.Draft);
        }

        public static async Task DeleteTournamentAsync(Guid tournamentId)
        {
            await ResetDrawAsync(tournamentId);

            await Db.From<TournamentParticipantModel>()
                .Where(x => x.TournamentId == tournamentId)
                .Delete();

            await Db.From<TournamentModel>()
                .Where(x => x.Id == tournamentId)
                .Delete();
        }

        // ---------- HELPER ----------

        private static async Task SetTournamentStatusAsync(Guid tournamentId, string status)
        {
            await Db.From<TournamentModel>()
                .Where(x => x.Id == tournamentId)
                .Set(x => x.Status, status)
                .Update();
        }

        private static void EnsureNotClosed(TournamentModel t)
        {
            if (t.Status == TournamentStatus.Completed || t.Status == TournamentStatus.Cancelled)
                throw new InvalidOperationException("Giải đấu đã kết thúc hoặc đã hủy.");
        }

        private static void Shuffle<T>(IList<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Shared.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        // Thuật toán vòng tròn (circle method): mọi cặp gặp nhau đúng 1 lần
        private static IEnumerable<(Guid a, Guid b)> RoundRobinPairs(List<Guid> ids)
        {
            var list = ids.Select(i => (Guid?)i).ToList();
            if (list.Count % 2 == 1) list.Add(null);

            int n = list.Count;
            for (int round = 0; round < n - 1; round++)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    var a = list[i];
                    var b = list[n - 1 - i];
                    if (a.HasValue && b.HasValue)
                        yield return (a.Value, b.Value);
                }

                // Giữ nguyên phần tử đầu, xoay phần còn lại
                var last = list[n - 1];
                list.RemoveAt(n - 1);
                list.Insert(1, last);
            }
        }
    }
}
