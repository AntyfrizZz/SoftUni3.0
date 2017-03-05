using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniStore.Models
{
    public class User
    {
        private ICollection<Game> games;

        public User()
        {
            this.games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Fullname { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public bool IsAdmin { get; set; }
    }
}
