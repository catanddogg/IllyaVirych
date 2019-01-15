using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IllyaVirych.Core.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserId { get; set; }

        public User(string userId)
        {
            UserId = userId;
        }
        public User()
        {

        }
    }
}
