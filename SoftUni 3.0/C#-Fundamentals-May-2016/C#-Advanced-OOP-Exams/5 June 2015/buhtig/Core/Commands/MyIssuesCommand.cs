namespace Buhtig.Core.Commands
{
    using System.Collections.Generic;
    using Data;

    public class MyIssuesCommand : Command
    {
        public MyIssuesCommand(Dictionary<string, string> parameters, IIssueTrackerData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            return this.Data.MyIssues();
        }
    }
}
