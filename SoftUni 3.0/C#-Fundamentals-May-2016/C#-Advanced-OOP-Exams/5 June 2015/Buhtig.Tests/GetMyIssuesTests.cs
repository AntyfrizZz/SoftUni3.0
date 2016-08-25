namespace Buhtig.Tests
{
    using System;

    using Data;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetMyIssuesTests
    {
        private const string Username = "user";
        private const string Password = "1234566";
        private const string Title = "Test Title";
        private const string Description = "Test Description";
        private const string Priority = "Medium";

        private static readonly string[] Tags = new string[] { "tag1", "Tag2" };

        private IIssueTrackerData tracker;

        [TestInitialize]
        public void Setup()
        {
            this.tracker = new IssueTrackerData();
        }

        [TestMethod]
        public void GetMyIssues_AllValid_ShouldPass()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);
            this.tracker.CreateIssue(Title, Description, Priority, Tags);

            var expectedResult =
                $"{Title}{Environment.NewLine}Priority: **{Environment.NewLine}{Description}{Environment.NewLine}Tags: {string.Join(",", Tags)}";
            var actualResult = this.tracker.MyIssues();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "No issues")]
        public void GetMyIssues_AllValidNoCurrentIssues_ShouldFail()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);
   
            this.tracker.MyIssues();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There is no currently logged in user")]
        public void GetMyIssues_NoCurrentlyLoggedUser_ShouldFail()
        {
            this.tracker.RegisterUser(Username, Password, Password);

            this.tracker.MyIssues();
        }

        public void GetMyIssues_AreIssuesOrdered_ShouldPass()
        {
            
        }

        [TestMethod]
        public void GetMyIssues_PickCorrectIssuesFromAllUsers_ShouldPass()
        {
            
        }


    }
}
