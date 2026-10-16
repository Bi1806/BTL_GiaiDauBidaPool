using System;
using Postgrest.Attributes;
using Postgrest.Models;

namespace PoolTournament.Models
{
    [Table("group_players")]
    public class GroupPlayerModel : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("group_id")]
        public Guid GroupId { get; set; }

        [Column("player_id")]
        public Guid PlayerId { get; set; }

        [Column("matches_played")]
        public int MatchesPlayed { get; set; }

        [Column("matches_won")]
        public int MatchesWon { get; set; }

        [Column("matches_lost")]
        public int MatchesLost { get; set; }

        [Column("points")]
        public int Points { get; set; }
    }
}
