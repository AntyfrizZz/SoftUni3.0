namespace AirConditionerTester.IO.Commands
{
    using Database;

    public class StatusCommand : Command
    {
        private const int ExpectedArgumentsCount = 0;

        public StatusCommand(string[] arguments, IDatabase database) 
            : base(arguments, database, ExpectedArgumentsCount)
        {
        }

        public override string Execute()
        {
            return this.Database.Status();
        }
    }
}
