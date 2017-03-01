namespace AirConditionerTester.IO.Commands
{
    using Attributes;
    using Database;
    using Exceptions;
    using Tester;

    public class TestAirConditionerCommand : Command
    {
        private const int ExpectedArgumentsCount = 2;
        private const string Test = "Air Conditioner model {0} from {1} tested successfully.";

        [Inject]
        private IAirConditionerTester tester;

        public TestAirConditionerCommand(string[] arguments, IDatabase database) 
            : base(arguments, database, ExpectedArgumentsCount)
        {
        }

        public override string Execute()
        {
            var manufacturer = this.Arguments[0];
            var model = this.Arguments[1];

            if (this.Database.CheckReport(manufacturer, model))
            {
                throw new DuplicateEntryException();
            }

            if (!this.Database.CheckAirConditioner(manufacturer, model))
            {
                throw new NonExistantEntryException();
            }

            var airConditioner = this.Database.GetAirConditioner(manufacturer, model);
            var report = this.tester.TestAirConditioner(airConditioner);

            this.Database.AddReport(report);

            return string.Format(Test, model, manufacturer);
        }
    }
}
