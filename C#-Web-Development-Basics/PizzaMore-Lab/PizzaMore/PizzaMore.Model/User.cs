using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaMore.Model
{
    public class User
    {
        private ICollection<Pizza> suggestions;

        public User()
        {
            this.suggestions = new HashSet<Pizza>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Pizza> Suggestions
        {
            get { return this.suggestions; }
            set { this.suggestions = value; }
        }
    }
}
