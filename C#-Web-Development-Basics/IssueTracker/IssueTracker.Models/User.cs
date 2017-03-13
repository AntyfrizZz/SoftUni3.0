using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Models.Enums;

namespace IssueTracker.Models
{
    public class User
    {
        private ICollection<Issue> issues;

        public User()
        {
            this.issues = new HashSet<Issue>();
        }

        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Fullname { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
