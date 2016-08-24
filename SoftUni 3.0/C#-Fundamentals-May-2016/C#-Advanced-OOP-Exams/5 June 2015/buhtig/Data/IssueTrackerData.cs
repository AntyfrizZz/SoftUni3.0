namespace Buhtig.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Models;

    public class IssueTrackerData : IIssueTrackerData
    {
        private const string UserSuccessfulRegisteredMessage = "User {0} registered successfully";
        private const string AlreadyLoggedUserMessage = "There is already a logged in user";
        private const string PasswordsDontMatchMessage = "The provided passwords do not match";
        private const string UsernameAlreadyExistMessage = "A user with username {0} already exists";
        private const string UserLoggedSuccessfulMessage = "User {0} logged in successfully";
        private const string NonExistingUserMessage = "A user with username {0} does not exist";
        private const string InvalidPasswordMessage = "The password is invalid for user {0}";
        private const string UserSuccessfulLogoutMessage = "User {0} logged out successfully";
        private const string NoCurrentlyLoggedUserMessage = "There is no currently logged in user";
        private const string IssueSuccessfulCreatedMessage = "Issue {0} created successfully";
        private const string IssueSuccessfulRemovedMessage = "Issue {0} removed";
        private const string InvalidIssueIDMessage = "There is no issue with ID {0}";
        private const string IssueNotBelongToUserMessage = "The issue with ID {0} does not belong to user {1}";
        private const string CommentSuccessfulAdded = "Comment added successfully to issue {0}";
        private const string NoIssuesMessage = "No issues";
        private const string NoCommentsMessage = "No comments";
        private const string NoTagsProvided = "There are no tags provided";
        private const string NoIssuesMatch = "There are no issues matching the tags provided";

        private static int idCounter = 1;

        private IUser activeUser;
        private Dictionary<string, IUser> users;
        private Dictionary<int, IIssue> issues;

        //private Dictionary<string, Dictionary<int, IIssue>> issuesByUser;
        //private Dictionary<string, Dictionary<int, IIssue>> issuesByTag;
        private Dictionary<string, IList<IComment>> commentsByUser;

        public IssueTrackerData()
        {
            this.users = new Dictionary<string, IUser>();
            this.issues = new Dictionary<int, IIssue>();
            //this.issuesByUser = new Dictionary<string, Dictionary<int, IIssue>>();
            //this.issuesByTag = new Dictionary<string, Dictionary<int, IIssue>>();
            this.commentsByUser = new Dictionary<string, IList<IComment>>();
        }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.CheckActiveUser())
            {
                throw new InvalidOperationException(AlreadyLoggedUserMessage);
            }

            if (!this.CheckPasswordMatch(password, confirmPassword))
            {
                throw new InvalidOperationException(PasswordsDontMatchMessage);
            }

            if (this.CheckIfUserExists(username))
            {
                throw new InvalidOperationException(string.Format(UsernameAlreadyExistMessage, username));
            }

            var hasshedPassword = this.HashPassword(password);
            var currentUser = new User(username, hasshedPassword);

            this.users.Add(username, currentUser);
            //this.issuesByUser.Add(username, new Dictionary<int, IIssue>());
            this.commentsByUser.Add(username, new List<IComment>());

            return string.Format(UserSuccessfulRegisteredMessage, username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.CheckActiveUser())
            {
                throw new InvalidOperationException(AlreadyLoggedUserMessage);
            }

            if (!this.CheckIfUserExists(username))
            {
                throw new InvalidOperationException(string.Format(NonExistingUserMessage, username));
            }

            var hashedPassword = this.HashPassword(password);

            if (!this.CheckPasswordMatch(this.users[username].Password, hashedPassword))
            {
                throw new InvalidOperationException(string.Format(InvalidPasswordMessage, username));
            }

            this.activeUser = this.users[username];

            return string.Format(UserLoggedSuccessfulMessage, username);
        }

        public string LogoutUser()
        {
            if (!this.CheckActiveUser())
            {
                throw new InvalidOperationException(NoCurrentlyLoggedUserMessage);
            }

            var currentUsername = this.activeUser.Username;
            this.activeUser = null;
            return string.Format(UserSuccessfulLogoutMessage, currentUsername);
        }

        public string CreateIssue(string title, string description, string priority, string[] tags)
        {
            if (!this.CheckActiveUser())
            {
                throw new InvalidOperationException(NoCurrentlyLoggedUserMessage);
            }

            var currentID = idCounter;
            var issue = new Issue(title, description, priority, tags, currentID, this.activeUser);
            this.issues.Add(currentID, issue);
            //this.issuesByUser[this.activeUser.Username].Add(issue.Id, issue);

            //foreach (var tag in tags)
            //{
            //    if (!this.issuesByTag.ContainsKey(tag))
            //    {
            //        this.issuesByTag.Add(tag, new Dictionary<int, IIssue>());
            //    }

            //    if (!this.issuesByTag[tag].ContainsKey(issue.Id))
            //    {
            //        this.issuesByTag[tag].Add(issue.Id, issue);
            //    }
            //}

            idCounter++;
            return string.Format(IssueSuccessfulCreatedMessage, currentID);
        }

        public string RemoveIssue(string id)
        {
            if (!this.CheckActiveUser())
            {
                throw new InvalidOperationException(NoCurrentlyLoggedUserMessage);
            }

            var currentId = int.Parse(id);

            if (!this.CheckIfIssueExists(currentId))
            {
                throw new InvalidOperationException(string.Format(InvalidIssueIDMessage, currentId));
            }

            if (!this.CheckIssuesAuthor(this.issues[currentId].Author.Username, this.activeUser.Username))
            {
                throw new InvalidOperationException(string.Format(IssueNotBelongToUserMessage, currentId, this.activeUser.Username));
            }

            //foreach (var tag in this.issues[currentId].GetTags())
            //{
            //    this.issuesByTag[tag].Remove(this.issues[currentId].Id);
            //}

            this.issues.Remove(currentId);
            //this.issuesByUser[this.activeUser.Username].Remove(currentId);

            return string.Format(IssueSuccessfulRemovedMessage, id);
        }

        public string AddComment(string id, string text)
        {
            if (!this.CheckActiveUser())
            {
                throw new InvalidOperationException(NoCurrentlyLoggedUserMessage);
            }

            var currentId = int.Parse(id);

            if (!this.CheckIfIssueExists(currentId))
            {
                throw new InvalidOperationException(string.Format(InvalidIssueIDMessage, currentId));
            }

            var comment = new Comment(this.activeUser, text);

            this.issues[currentId].AddComment(comment);
            this.commentsByUser[this.activeUser.Username].Add(comment);

            return string.Format(CommentSuccessfulAdded, currentId);
        }

        public string MyIssues()
        {
            if (!this.CheckActiveUser())
            {
                throw new InvalidOperationException(NoCurrentlyLoggedUserMessage);
            }

            //if (this.issuesByUser[this.activeUser.Username].Count == 0)
            //{
            //    return NoIssuesMessage;
            //}

            var ordered = this.issues
                .Where(i => i.Value.Author.Username.Equals(this.activeUser.Username))
                .OrderByDescending(i => (int)i.Value.Priority)
                .ThenBy(t => t.Value.Title)
                .Select(i => i.Value)
                .ToArray();

            if (!ordered.Any())
            {
                return NoIssuesMessage;
            }

            var result = new StringBuilder();

            foreach (var issue in ordered)
            {
                result.AppendLine(issue.ToString());
            }

            return result.ToString().Trim();
        }

        public string MyComments()
        {
            if (!this.CheckActiveUser())
            {
                throw new InvalidOperationException(NoCurrentlyLoggedUserMessage);
            }

            if (this.commentsByUser[this.activeUser.Username].Count == 0)
            {
                return NoCommentsMessage;
            }

            var result = new StringBuilder();

            foreach (var comment in this.commentsByUser[this.activeUser.Username])
            {
                result
                    .AppendLine(comment.Text)
                    .AppendLine($"-- {this.activeUser.Username}");
            }

            return result.ToString().Trim();
        }

        public string Search(IEnumerable<string> tags)
        {
            if (!tags.Any())
            {
                return NoTagsProvided;
            }

            var ordered = this.issues
                .OrderByDescending(i => (int)i.Value.Priority)
                .ThenBy(i => i.Value.Title)
                .Select(i => i.Value);

            var result = new StringBuilder();
            var foundMatch = false;

            foreach (var issue in ordered)
            {
                if (issue.GetTags().Any(tags.Contains))
                {
                    result.AppendLine(issue.ToString());
                    foundMatch = true;
                }
            }

            //foreach (var tag in tags)
            //{
            //    if (!this.issuesByTag.ContainsKey(tag))
            //    {
            //        continue;
            //    }

            //    foreach (var issue in this.issuesByTag[tag])
            //    {
            //        if (!issuesForPrint.ContainsKey(issue.Key))
            //        {
            //            issuesForPrint.Add(issue.Key, issue.Value);
            //        }
            //    }
            //}

            //if (issuesForPrint.Count == 0)
            //{
            //    return NoIssuesMatch;
            //}

            return foundMatch ? result.ToString().Trim() : NoIssuesMatch;

            //foreach (var issue in ordered)
            //{
            //    result.AppendLine(issue.ToString());
            //}
        }

        private bool CheckActiveUser()
        {
            return this.activeUser != null;
        }

        private bool CheckPasswordMatch(string password, string confirmPassword)
        {
            return password.Equals(confirmPassword);
        }

        private bool CheckIfUserExists(string username)
        {
            return this.users.ContainsKey(username);
        }

        private bool CheckIfIssueExists(int id)
        {
            return this.issues.ContainsKey(id);
        }

        private bool CheckIssuesAuthor(string issueAuthor, string activeAuthor)
        {
            return issueAuthor.Equals(activeAuthor);
        }

        private string HashPassword(string pass)
        {
            return string.Join(string.Empty, SHA1.Create().ComputeHash(Encoding.Default.GetBytes(pass)).Select(x => x.ToString()));
        }
    }
}