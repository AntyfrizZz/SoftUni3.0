namespace Buhtig.Core.Commands
{
    using System.Collections.Generic;
    using Data;

    public class RemoveIssueCommand : Command
    {
        public RemoveIssueCommand(Dictionary<string, string> parameters, IIssueTrackerData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            var id = this.Parameters[IDKey];

            return this.Data.RemoveIssue(id);
        }
    }
}
