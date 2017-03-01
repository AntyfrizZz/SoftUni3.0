namespace AirConditionerTester.Exceptions
{
    using System;

    public class NonExistantEntryException : InvalidOperationException
    {
        private const string InvalidEntry = "The specified entry does not exist.";

        public NonExistantEntryException(string message)
            : base(message)
        {
        }

        public NonExistantEntryException()
            : base(InvalidEntry)
        {
        }
    }
}
