namespace Executor.IO.Commands
{
    using Exceptions;
    using Interfaces;

    public class ChangeAbsolutePathCommand : Command, IExecutable
    {
        public ChangeAbsolutePathCommand(
            string input, 
            string[] data, 
            IContentComparer tester,
            IDatabase repository, 
            IDownloadManager downloadManager,
            IDirectoryManager ioManager)
            : base(input, data, tester, repository, downloadManager, ioManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string absolutePath = this.Data[1];

            this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absolutePath);
        }
    }
}
