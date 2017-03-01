namespace Buhtig.Core.Commands
{
    using System.Collections.Generic;
    using Data;

    public class LoginUserCommand : Command
    {
        public LoginUserCommand(Dictionary<string, string> parameters, IIssueTrackerData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            var username = this.Parameters[UsernameKey];
            var password = this.Parameters[PasswordKey];

            return this.Data.LoginUser(username, password);
        }
    }
}
