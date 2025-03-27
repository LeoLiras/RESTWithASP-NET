using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTWithASP_NET.Model
{
    [Table("users")]
    public class users
    {
        [Key]
        [Column("id")]
        public long id { get; set; }

        [Column("user_name")]
        public string user_name { get; set; }

        [Column("full_name")]
        public string full_name { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("refresh_token")]
        public string? refresh_token { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime refresh_token_expiry_time { get; set; }
    }
}
