namespace Executor.IO.Commands
{
    using Exceptions;
    using Interfaces;

    public class CompareFilesCommand : Command, IExecutable
    {
        public CompareFilesCommand(
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
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string firstPath = this.Data[1];
            string secondPath = this.Data[2];

            this.Tester.CompareContent(firstPath, secondPath);
        }
    }
}
