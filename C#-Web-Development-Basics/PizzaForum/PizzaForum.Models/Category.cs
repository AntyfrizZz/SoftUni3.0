namespace PizzaForum.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Topic> topics;

        public Category()
        {
            this.topics = new HashSet<Topic>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Topic> Topics
        {
            get
            {
                return this.topics;
            }

            set
            {
                this.topics = value;
            }
        }
    }
}
