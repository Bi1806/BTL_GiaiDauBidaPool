using System;
using Newtonsoft.Json;
using Postgrest.Attributes;
using Postgrest.Models;

namespace PoolTournament.Models
{
    [Table("matches")]
    public class MatchModel : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("tournament_id")]
        public Guid TournamentId { get; set; }

        // Trận vòng bảng có group_id; trận loại trực tiếp để null
        [Column("group_id", NullValueHandling = NullValueHandling.Include)]
        public Guid? GroupId { get; set; }

        // "GROUP" hoặc "KO_16", "KO_8", "KO_4", "KO_2" (xem RoundCode)
        [Column("round_name")]
        public string RoundName { get; set; } = "";

        [Column("match_number")]
        public int MatchNumber { get; set; }

        [Column("player1_id", NullValueHandling = NullValueHandling.Include)]
        public Guid? Player1Id { get; set; }

        [Column("player2_id", NullValueHandling = NullValueHandling.Include)]
        public Guid? Player2Id { get; set; }

        [Column("winner_id", NullValueHandling = NullValueHandling.Include)]
        public Guid? WinnerId { get; set; }

        [Column("table_id", NullValueHandling = NullValueHandling.Include)]
        public Guid? TableId { get; set; }

        [Column("score_player1")]
        public int ScorePlayer1 { get; set; }

        [Column("score_player2")]
        public int ScorePlayer2 { get; set; }

        // pending | ongoing | completed
        [Column("status")]
        public string Status { get; set; } = "pending";

        [Column("scheduled_time")]
        public DateTime? ScheduledTime { get; set; }
    }
}
