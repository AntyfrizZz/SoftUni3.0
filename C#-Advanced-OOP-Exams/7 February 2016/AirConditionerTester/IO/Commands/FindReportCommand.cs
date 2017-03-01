namespace AirConditionerTester.IO.Commands
{
    using Database;
    using Exceptions;

    public class FindReportCommand : Command
    {
        private const int ExpectedArgumentsCount = 2;

        public FindReportCommand(string[] arguments, IDatabase database) 
            : base(arguments, database, ExpectedArgumentsCount)
        {
        }

        public override string Execute()
        {
            var manufacturer = this.Arguments[0];
            var model = this.Arguments[1];

            if (!this.Database.CheckReport(manufacturer, model))
            {
                throw new NonExistantEntryException();
            }

            var report = this.Database.GetReport(manufacturer, model);

            return report.ToString();
        }
    }
}
