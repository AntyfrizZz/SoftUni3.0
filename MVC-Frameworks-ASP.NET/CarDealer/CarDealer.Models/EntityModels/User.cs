namespace CarDealer.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<Login> logins;

        public User()
        {
            this.logins = new HashSet<Login>();
        }

        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Login> Logins { get; set; }
    }
}
