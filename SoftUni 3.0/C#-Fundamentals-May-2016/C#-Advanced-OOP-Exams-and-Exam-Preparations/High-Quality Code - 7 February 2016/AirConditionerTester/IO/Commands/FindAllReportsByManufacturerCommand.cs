namespace AirConditionerTester.IO.Commands
{
    using Database;

    public class FindAllReportsByManufacturerCommand : Command
    {
        private const int ExpectedArgumentsCount = 1;

        public FindAllReportsByManufacturerCommand(string[] arguments, IDatabase database) 
            : base(arguments, database, ExpectedArgumentsCount)
        {
        }

        public override string Execute()
        {
            return this.Database.GetReportsByManufacturer(this.Arguments[0]);
        }
    }
}
