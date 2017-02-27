namespace SimpleMVC.App.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<Note> notes;

        public User()
        {
            this.notes = new HashSet<Note>();
        }

        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Passsword { get; set; }

        public virtual ICollection<Note> Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                this.notes = value;
            }
        }
    }
}