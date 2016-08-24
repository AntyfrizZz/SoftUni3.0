namespace Buhtig.Models
{
    using System.Linq;
    using Enumeratins;

    public interface IIssue
    {
        int Id { get; }

        string Title { get; }

        IssuePriority Priority { get; }

        string Description { get; }

        IUser Author { get; }

        IOrderedEnumerable<string> GetTags();

        void AddComment(IComment comment);
    }
}
