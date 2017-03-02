namespace PizzaForum.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reply
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual User Author { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImageURL { get; set; }

        //[ForeignKey("Topic")]
        //public int TopicId { get; set; }

        //public virtual Topic Topic { get; set; }
    }
}
