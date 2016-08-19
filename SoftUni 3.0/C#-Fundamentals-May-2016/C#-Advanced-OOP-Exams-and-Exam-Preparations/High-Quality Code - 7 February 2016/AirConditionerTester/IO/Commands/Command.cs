namespace AirConditionerTester.IO.Commands
{
    using System;
    using Database;
    using Utilities;

    public abstract class Command : IExecutable
    {
        protected Command(string[] arguments, IDatabase database, int expectedParamethersCount)
        {
            this.Arguments = arguments;
            this.Database = database;
            this.ExpectedParamethersCount = expectedParamethersCount;
        }

        protected string[] Arguments { get; }

        protected IDatabase Database { get; }

        private int ExpectedParamethersCount
        {
            set
            {
                if (this.Arguments.Length != value)
                {
                    throw new InvalidOperationException(Constants.InvalidCommand);
                }
            }
        }

        public abstract string Execute();
    }
}
