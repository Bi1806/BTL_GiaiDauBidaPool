using System;
using Postgrest.Attributes;
using Postgrest.Models;

namespace PoolTournament.Models
{
    [Table("tables")]
    public class TournamentTable : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("table_name")]
        public string TableName { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("table_type")]
        public string TableType { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("sort_order")]
        public int SortOrder { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("current_match_id")]
        public Guid? CurrentMatchId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}