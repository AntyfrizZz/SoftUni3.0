namespace LambdaCore_Skeleton.Core.Commands
{
    using Contracts.Core;

    public abstract class Command : IExecutable
    {
        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get; private set; }

        public abstract string Execute();
    }
}