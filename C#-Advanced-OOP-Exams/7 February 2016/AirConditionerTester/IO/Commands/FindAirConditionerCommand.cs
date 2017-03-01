namespace AirConditionerTester.IO.Commands
{
    using Database;

    public class FindAirConditionerCommand : Command
    {
        private const int ExpectedArgumentsCount = 2;

        public FindAirConditionerCommand(string[] arguments, IDatabase database) 
            : base(arguments, database, ExpectedArgumentsCount)
        {
        }

        public override string Execute()
        {
            var manufacturer = this.Arguments[0];
            var model = this.Arguments[1];

            var airConditioner = this.Database.GetAirConditioner(manufacturer, model);

            return airConditioner.ToString();
        }
    }
}
