namespace Buhtig.Core.Commands
{
    using System.Collections.Generic;
    using Data;

    public class MyCommentsCommand : Command
    {
        public MyCommentsCommand(Dictionary<string, string> parameters, IIssueTrackerData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            return this.Data.MyComments();
        }
    }
}
