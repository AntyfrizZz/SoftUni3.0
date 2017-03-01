namespace Buhtig.Core.Commands
{
    using System.Collections.Generic;
    using Data;

    public abstract class Command : IExecutable
    {
        protected const string UsernameKey = "username";
        protected const string PasswordKey = "password";
        protected const string ConfrimPasswordKey = "confirmPassword";
        protected const string TitleKey = "title";
        protected const string DescriptionKey = "description";
        protected const string PriorityKey = "priority";
        protected const string TagsKey = "tags";
        protected const string IDKey = "id";
        protected const string TextKey = "text";

        protected Command(Dictionary<string, string> parameters, IIssueTrackerData data)
        {
            this.Parameters = parameters;
            this.Data = data;
        }

        protected Dictionary<string, string> Parameters { get; }

        protected IIssueTrackerData Data { get; }

        public abstract string Execute();
    }
}
