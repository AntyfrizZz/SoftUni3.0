namespace Buhtig.Tests
{
    using System;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterUserTests
    {
        private const string Username = "admin";
        private const string Password = "123456";

        private IIssueTrackerData tracker;

        [TestInitialize]
        public void Setup()
        {
            this.tracker = new IssueTrackerData();
        }

        [TestMethod]
        public void Register_ValidParameters_ShoudRegisterUser()
        {
            var exepectedResult = $"User {Username} registered successfully";

            var expectedResult = this.tracker.RegisterUser(Username, Password, Password);

            Assert.AreEqual(exepectedResult, expectedResult, "Register user didn't register correctly");
            Assert.AreEqual(1, this.tracker.RegisteredUsersCount(), "Registered user didn't add correctly in one of the data dictionaries (users, commentsByUser) in IssueTrackerData");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "The provided passwords do not match")]
        public void Register_InvalidConfirmPassword_ShoudNotRegister()
        {
            var confirmPassword = "1234567";

            var user = this.tracker.RegisterUser(Username, Password, confirmPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There is already a logged in user")]
        public void Register_AttemptToRegisterWithAlreadyLoggedUser_ShoudFail()
        {
            var user = this.tracker.RegisterUser(Username, Password, Password);

            this.tracker.LoginUser(Username, Password);

            var userName2 = "admin2";
            var password2 = "1234567";

            var user2 = this.tracker.RegisterUser(userName2, password2, password2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "A user with username admin already exists")]
        public void Register_AttemptToRegisterWithExistingUsername_ShoudFail()
        {
            var password2 = "1234562";

            var user = this.tracker.RegisterUser(Username, Password, Password);
            var user2 = this.tracker.RegisterUser(Username, password2, password2);
        }
    }
}
