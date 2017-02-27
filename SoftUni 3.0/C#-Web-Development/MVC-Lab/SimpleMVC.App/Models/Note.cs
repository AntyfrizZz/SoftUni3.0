namespace SimpleMVC.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Note
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual User Owner { get; set; }
    }
}