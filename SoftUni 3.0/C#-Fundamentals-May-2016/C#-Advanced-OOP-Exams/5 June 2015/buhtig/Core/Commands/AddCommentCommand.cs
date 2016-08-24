namespace Buhtig.Core.Commands
{
    using System.Collections.Generic;
    using Data;

    public class AddCommentCommand : Command
    {
        public AddCommentCommand(Dictionary<string, string> parameters, IIssueTrackerData data) 
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            var id = this.Parameters[IDKey];
            var text = this.Parameters[TextKey];
            return this.Data.AddComment(id, text);
        }
    }
}
