namespace Buhtig.Models
{ 
    public class User : IUser
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; }

        public string Password { get; }
    }
}
