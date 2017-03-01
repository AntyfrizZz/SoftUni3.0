namespace SimpleMVC.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Session
    {
        [Key]
        public string Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
