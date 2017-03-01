namespace AirConditionerTester.Tests
{
    using Database;
    using IO;
    using IO.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindAllReportsByManufacturerTests
    {
        private IController controller;
        private IDatabase database;

        [TestInitialize]
        public void Setup()
        {
            this.controller = new Controller();
            this.database = new Database();
        }

        [TestMethod]
        public void FindAllReportsByManufacturer_WithowAnyExistingReports_ShoudReturnCorrectMessage()
        {
            var args = new string[] { "Toshiba" };
            var command = new FindAllReportsByManufacturerCommand(args, this.database);
            var result = command.Execute();

            var expectedResult = "No reports.";

            Assert.AreEqual(expectedResult, result, "Expected message did not match!");
        }
    }
}
