namespace Buhtig.Core.Commands
{
    using System.Collections.Generic;
    using Data;

    public class LogoutUserCommand : Command
    {
        public LogoutUserCommand(Dictionary<string, string> parameters, IIssueTrackerData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            return this.Data.LogoutUser();
        }
    }
}
