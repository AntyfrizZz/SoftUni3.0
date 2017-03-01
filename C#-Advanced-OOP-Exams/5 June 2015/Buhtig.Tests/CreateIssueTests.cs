namespace Buhtig.Tests
{
    using System;

    using Buhtig.Data;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CreateIssueTests
    {
        private const string Username = "username";
        private const string Password = "passss";
        private const string Title = "Test Title";
        private const string Description = "Test Description";
        private const string Priority = "Medium";
        private const int MinTitleLength = 3;
        private const int MinDescriptionLength = 5;

        private static readonly string[] Tags = new string[] {"tag1", "Tag2"};

        private IIssueTrackerData tracker;

        [TestInitialize]
        public void Setup()
        {
            this.tracker = new IssueTrackerData();    
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.tracker = new IssueTrackerData();
        }

        [TestMethod]
        public void CreateIssue_AllValid_ShouldPass()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);

            var expectedMessage = "Issue 1 created successfully";
            var actualMessage = this.tracker.CreateIssue(Title, Description, Priority, Tags);

            Assert.AreEqual(expectedMessage, actualMessage, "Creating issue doesn't return the correct message");
            Assert.AreEqual(1, this.tracker.IssuesCount(), "Issue doesn't added properly to issues data in IssueTrackerData");
        }

        [TestMethod]
        public void CreateIssue_ChechIsGivenIDsAreValid_ShouldPass()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);

            var expectedMessage = "Issue {0} created successfully";

            for (int i = 1; i <= 20; i++)
            {
                var actualMessage = this.tracker.CreateIssue(Title, Description, Priority, Tags);
                Assert.AreEqual(string.Format(expectedMessage, i), actualMessage, "Creating issue doesn't return the correct message");
                Assert.AreEqual(i, this.tracker.IssuesCount(), "Issue doesn't added properly to issues data in IssueTrackerData");
            }
        }

        [TestMethod]
        public void CreateIssue_ChechIsIssuesAreAddetToTheData_ShouldPass()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);

            for (int i = 1; i <= 20; i++)
            {
                this.tracker.CreateIssue(Title, Description, Priority, Tags);
                Assert.AreEqual(i, this.tracker.IssuesCount(), "Issue doesn't added properly to issues data in IssueTrackerData");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There is no currently logged in user")]
        public void CreateIssue_WithoutCurrentlyLoggedUser_ShouldFail()
        {
            this.tracker.CreateIssue(Title, Description, Priority, Tags);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The title must be at least 3 symbols long")]
        public void CreateIssue_WithInvvalidLessThen3CharactersLengthTitle_ShoudFail()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);

            var invalidTitle = new string('t', MinTitleLength - 1);

            this.tracker.CreateIssue(invalidTitle, Description, Priority, Tags);
        }

        [TestMethod]
        public void CreateIssue_WithValidBoundCharactersLengthTitle_ShoulPass()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);

            var validTitle = new string('t', MinTitleLength);

            var expectedResult = "Issue 1 created successfully";
            var actualResult = this.tracker.CreateIssue(validTitle, Description, Priority, Tags);

            Assert.AreEqual(expectedResult, actualResult, "Wrong min length for issue title");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The title must be at least 3 symbols long")]
        public void CreateIssue_WithInvalidNullTitle_ShoudFail()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);

            this.tracker.CreateIssue(null, Description, Priority, Tags);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The description must be at least 5 symbols long")]
        public void CreateIssue_WithInvalidLessThen5CharactersLengthDescription_ShoudFail()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);

            var invalidDescription = new string('t', MinDescriptionLength - 1);

            this.tracker.CreateIssue(Title, invalidDescription, Priority, Tags);
        }

        [TestMethod]
        public void CreateIssue_WithValidBoundCharactersLengthDescription_ShouldPass()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);

            var invalidDescription = new string('t', MinDescriptionLength);

            var expectedResult = "Issue 1 created successfully";
            var actualResult = this.tracker.CreateIssue(Title, invalidDescription, Priority, Tags);

            Assert.AreEqual(expectedResult, actualResult, "Wrong min length for issue description");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The description must be at least 5 symbols long")]
        public void CreateIssue_WithInvvalidNullDescription_ShoudFail()
        {
            this.tracker.RegisterUser(Username, Password, Password);
            this.tracker.LoginUser(Username, Password);

            string invalidDescription = null;

            this.tracker.CreateIssue(Title, invalidDescription, Priority, Tags);
        }
    }
}
