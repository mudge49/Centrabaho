using SQLite;
using ColumnAttribute = SQLite.ColumnAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace Centrabaho.Models
{
    [Table("user")]
    public class UserData
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("userId")]
        public int UserId { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
