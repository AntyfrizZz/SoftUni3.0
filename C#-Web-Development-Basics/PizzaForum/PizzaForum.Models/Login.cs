using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaForum.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string SessionId { get; set; }

        public bool IsActive { get; set; }
    }
}
