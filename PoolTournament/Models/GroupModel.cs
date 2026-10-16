using System;
using Postgrest.Attributes;
using Postgrest.Models;

namespace PoolTournament.Models
{
    [Table("groups")]
    public class GroupModel : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("tournament_id")]
        public Guid TournamentId { get; set; }

        [Column("group_name")]
        public string GroupName { get; set; } = "";
    }
}
