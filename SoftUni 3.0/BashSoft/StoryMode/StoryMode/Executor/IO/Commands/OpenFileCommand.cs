namespace Executor.IO.Commands
{
    using System.Diagnostics;

    using Exceptions;
    using Interfaces;

    public class OpenFileCommand : Command, IExecutable
    {
        public OpenFileCommand(
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

            string fileName = this.Data[1];

            Process.Start(SessionData.CurrentPath + "\\" + fileName);
        }
    }
}
