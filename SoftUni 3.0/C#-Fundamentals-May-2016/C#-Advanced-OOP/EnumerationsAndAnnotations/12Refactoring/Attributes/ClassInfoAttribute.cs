namespace _12Refactoring.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class ClassInfoAttribute : Attribute
    {
        public ClassInfoAttribute(string author, int revision, string description, string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; }

        public int Revision { get; }

        public string Description { get; }

        public string[] Reviewers { get; }
    }
}
