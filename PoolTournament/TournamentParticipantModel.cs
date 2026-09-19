using Postgrest.Attributes;
using Postgrest.Models;
using System;

namespace PoolTournament
{
    [Table("tournament_participants")]
    public class TournamentParticipantModel : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("tournament_id")]
        public Guid TournamentId { get; set; }

        [Column("player_id")]
        public Guid PlayerId { get; set; }

        [Column("registered_at")]
        public DateTime RegisteredAt { get; set; }
    }
}