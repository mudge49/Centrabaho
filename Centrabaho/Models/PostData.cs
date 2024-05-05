using Centrabaho.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrabaho.Models
{
    [Table("PostData")]
    public class PostData
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("postId")]
        public int PostId { get; set; }

        [Column("userId")]
        public int UserId { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        public string Username {  get; set; }
    }
}
