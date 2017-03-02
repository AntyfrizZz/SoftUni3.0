namespace PizzaForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Topic
    {
        private ICollection<Reply> replies;

        public Topic()
        {
            this.replies = new HashSet<Reply>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual User Author { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        //[ForeignKey("Category")]
        //public int CategoryId { get; set; }

        //public virtual Category Category {get; set;}

        public virtual ICollection<Reply> Replies
        {
            get
            {
                return this.replies;
            }

            set
            {
                this.replies = value;
            }
        }
    }
}
