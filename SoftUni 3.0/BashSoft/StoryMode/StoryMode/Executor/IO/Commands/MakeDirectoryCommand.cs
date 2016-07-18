namespace Executor.IO.Commands
{
    using Exceptions;
    using Interfaces;

    public class MakeDirectoryCommand : Command, IExecutable
    {
        public MakeDirectoryCommand(
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

            string folderName = this.Data[1];

            this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}
