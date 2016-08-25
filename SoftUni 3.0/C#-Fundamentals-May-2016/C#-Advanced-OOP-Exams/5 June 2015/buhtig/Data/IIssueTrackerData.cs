namespace Buhtig.Data
{
    using System.Collections.Generic;

    public interface IIssueTrackerData
    {
        string RegisterUser(string username, string password, string confirmPassword);

        string LoginUser(string username, string password);

        string LogoutUser();

        string CreateIssue(string title, string description, string priority, string[] tags);

        string RemoveIssue(string id);

        string AddComment(string id, string text);

        string MyIssues();

        string MyComments();

        string Search(IEnumerable<string> tags);

        int RegisteredUsersCount();

        int IssuesCount();
    }
}
