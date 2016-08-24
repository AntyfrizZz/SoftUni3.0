namespace AirConditionerTester.Exceptions
{
    using System;

    public class DuplicateEntryException : InvalidOperationException
    {
        private const string DuplicateEntry = "An entry for the given model already exists.";

        public DuplicateEntryException(string message)
            : base(message)
        {
        }

        public DuplicateEntryException()
            : base(DuplicateEntry)
        {
        }
    }
}
