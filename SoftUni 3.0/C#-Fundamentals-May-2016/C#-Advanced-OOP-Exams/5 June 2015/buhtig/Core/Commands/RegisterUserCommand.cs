namespace Buhtig.Core.Commands
{
    using System.Collections.Generic;
    using Data;

    public class RegisterUserCommand : Command
    {
        public RegisterUserCommand(Dictionary<string, string> parameters, IIssueTrackerData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            var username = this.Parameters[UsernameKey];
            var password = this.Parameters[PasswordKey];
            var confirmPassword = this.Parameters[ConfrimPasswordKey];

            return this.Data.RegisterUser(username, password, confirmPassword);
        }
    }
}
