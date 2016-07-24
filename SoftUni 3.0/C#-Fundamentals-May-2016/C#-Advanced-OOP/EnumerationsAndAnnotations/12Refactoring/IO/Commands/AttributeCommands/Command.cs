namespace _12Refactoring.IO.Commands.AttributeCommands
{
    using Interfaces.IO;

    public abstract class Command : IExecutable
    {
        public abstract void Execute();
    }
}
