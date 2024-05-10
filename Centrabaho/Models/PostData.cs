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

        [Column("payamount")]
        public int PayAmount { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Username {  get; set; }

        [Column("serializedImagePaths")]
        public string SerializedImagePaths { get; set; }

        [Ignore]
        public List<string> ImagePaths
        {
            get => !string.IsNullOrWhiteSpace(SerializedImagePaths)
                ? SerializedImagePaths.Split(';').ToList()
                : new List<string>();
            set => SerializedImagePaths = string.Join(";", value);
        }
    }
}
