namespace CarDealer.Models.BindingModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserBm
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        [Compare("Password")]        
        public string ConfirmPassword { get; set; }
    }
}
