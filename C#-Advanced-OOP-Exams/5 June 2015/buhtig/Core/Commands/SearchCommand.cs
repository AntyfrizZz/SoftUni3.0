namespace Buhtig.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class SearchCommand : Command
    {
        public SearchCommand(Dictionary<string, string> parameters, IIssueTrackerData data)
            : base(parameters, data)
        {
        }

        public override string Execute()
        {
            IEnumerable<string> tags = this.Parameters[TagsKey]
                .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .Distinct();

            return this.Data.Search(tags);
        }
    }
}
