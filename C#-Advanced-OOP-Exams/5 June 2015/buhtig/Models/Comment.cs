namespace Buhtig.Models
{
    using System;
    using System.Text;
    using Utilities;

    public class Comment : IComment
    {
        private const int MinTextLength = 2;

        private string text;

        public Comment(IUser author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public IUser Author { get; }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinTextLength)
                {
                    throw new ArgumentException(string.Format(Constants.InvalidParametersCountMessage, nameof(this.text), MinTextLength));
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine(this.text)
                .AppendLine($"-- {this.Author.Username}");

            return result.ToString().Trim();
        }
    }
}
