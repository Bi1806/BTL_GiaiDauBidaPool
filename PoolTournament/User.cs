using System;
using Postgrest.Attributes;
using Postgrest.Models;

namespace PoolTournament
{
    [Table("users")]
    public class User : BaseModel
    {
        [PrimaryKey("id", false)]
        public string Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("role")]
        public string Role { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}