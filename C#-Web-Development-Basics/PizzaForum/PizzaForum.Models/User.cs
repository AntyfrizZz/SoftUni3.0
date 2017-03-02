namespace PizzaForum.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using PizzaForum.Common;

    public class User
    {
        private ICollection<Reply> replies;
        private ICollection<Topic> topics;
        private ICollection<Login> logins;

        public User()
        {
            this.replies = new HashSet<Reply>();
            this.topics = new HashSet<Topic>();
            this.logins = new HashSet<Login>();
        }

        [Key]
        public int Id { get; set; }

        [Index("Username", IsUnique = true)]
        [MinLength(GlobalConstants.UsernameMinLength)]
        [MaxLength(GlobalConstants.StringMaxLength)]
        [RegularExpression(GlobalConstants.UsernamePattern)]
        public string Username { get; set; }

        [Index("Email", IsUnique = true)]
        [MaxLength(GlobalConstants.StringMaxLength)]
        //[RegularExpression(GlobalConstants.EmailPattern)]
        public string Email { get; set; }

        [MinLength(GlobalConstants.PasswordLength)]
        [MaxLength(GlobalConstants.PasswordLength)]
        [RegularExpression(GlobalConstants.PasswordPattern)]
        public string Password { get; set; }

        //public virtual ICollection<Reply> Replies
        //{
        //    get
        //    {
        //        return this.replies;
        //    }

        //    set
        //    {
        //        this.replies = value;
        //    }
        //}

        //public virtual ICollection<Topic> Topics
        //{
        //    get
        //    {
        //        return this.topics;
        //    }

        //    set
        //    {
        //        this.topics = value;
        //    }
        //}
        
        //public virtual ICollection<Login> Logins
        //{
        //    get
        //    {
        //        return this.logins;
        //    }

        //    set
        //    {
        //        this.logins = value;
        //    }
        //}

        public bool IsAdmin { get; set; }
    }
}
