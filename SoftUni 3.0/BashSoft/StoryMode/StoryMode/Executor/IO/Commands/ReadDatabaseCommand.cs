namespace Executor.IO.Commands
{
    using Exceptions;
    using Interfaces;

    public class ReadDatabaseCommand : Command, IExecutable
    {
        public ReadDatabaseCommand(
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

            this.Repository.LoadData(fileName);
        }
    }
}
