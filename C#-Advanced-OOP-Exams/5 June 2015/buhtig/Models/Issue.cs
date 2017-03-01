namespace Buhtig.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enumeratins;
    using Utilities;

    public class Issue : IIssue
    {
        private const int MinTitleLenght = 3;
        private const int MinDescriptionLength = 5;

        private string title;
        private string description;
        private HashSet<string> tags;
        private IList<IComment> comments;

        public Issue(string title, string description, string priority, string[] tags, int id, IUser author)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = this.SetPriority(priority);
            this.tags = this.SetTags(tags);
            this.Id = id;
            this.Author = author;
            this.comments = new List<IComment>();
        }

        public int Id { get; }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinTitleLenght)
                {
                    throw new ArgumentException(string.Format(Constants.InvalidParametersCountMessage, nameof(this.title), MinTitleLenght));
                }

                this.title = value;
            }
        }

        public IssuePriority Priority { get; }

        public string Description
        {
            get
            {
                return this.description;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinDescriptionLength)
                {
                    throw new ArgumentException(string.Format(Constants.InvalidParametersCountMessage, nameof(this.description), MinDescriptionLength));
                }

                this.description = value;
            }
        }

        public IUser Author { get; }

        public IOrderedEnumerable<string> GetTags()
        {
            var ordered = this.tags.OrderBy(t => t);

            return ordered;
        }

        public void AddComment(IComment comment)
        {
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine(this.Title)
                .AppendLine($"Priority: {new string('*', (int)this.Priority)}")
                .AppendLine(this.Description)
                .AppendLine($"Tags: {string.Join(",", this.GetTags())}");

            if (this.comments.Count == 0)
            {
                return result.ToString().Trim();
            }

            result.AppendLine("Comments:");

            foreach (var comment in this.comments)
            {
                result.AppendLine(comment.ToString());
            }

            return result.ToString().Trim();
        }

        private IssuePriority SetPriority(string currentPriority)
        {
            var tempPriority = char.ToUpper(currentPriority[0]) + currentPriority.Substring(1).ToLower();

            return (IssuePriority)Enum.Parse(typeof(IssuePriority), tempPriority);
        }

        private HashSet<string> SetTags(string[] allTags)
        {
            var currentTags = new HashSet<string>();

            foreach (var tag in allTags)
            {
                currentTags.Add(tag);
            }

            return currentTags;
        }
    }
}