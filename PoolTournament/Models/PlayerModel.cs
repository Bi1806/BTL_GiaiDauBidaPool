using System;
using Postgrest.Attributes; // Sửa từ Supabase.Postgrest.Attributes
using Postgrest.Models;     // Sửa từ Supabase.Postgrest.Models

namespace PoolTournament.Models
{
    [Table("players")]
    public class PlayerModel : BaseModel
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("rank_level")]
        public string RankLevel { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("avatar_url")]
        public string AvatarUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}