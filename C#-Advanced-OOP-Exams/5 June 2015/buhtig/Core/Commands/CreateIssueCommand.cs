namespace Buhtig.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Data;

    public class CreateIssueCommand : Command
    {
        public CreateIssueCommand(Dictionary<string, string> parameters, IIssueTrackerData data)
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            var title = this.Parameters[TitleKey];
            var description = this.Parameters[DescriptionKey];
            var priority = this.Parameters[PriorityKey];
            var tags = this.Parameters[TagsKey].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            return this.Data.CreateIssue(title, description, priority, tags);
        }
    }
}
