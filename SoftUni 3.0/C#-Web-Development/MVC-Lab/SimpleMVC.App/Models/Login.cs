namespace SimpleMVC.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Login
    {
        [Key]
        public int Id { get; set; }

        public string SessionId { get; set; }

        public User User { get; set; }

        public bool IsActive { get; set; }
    }
}