using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = SQLite.TableAttribute;

namespace Centrabaho.Models
{
    [Table("PostImages")]
    public class PostImage
    {
        [PrimaryKey, AutoIncrement]
        public int ImageId { get; set; }

        [Indexed]
        public int PostId { get; set; }

        public string ImageUrl { get; set; }
    }
}
