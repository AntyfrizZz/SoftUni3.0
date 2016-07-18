namespace Executor.IO.Commands
{
    using Exceptions;
    using Interfaces;

    public class TraverseFoldersCommand : Command, IExecutable
    {
        public TraverseFoldersCommand(
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
            if (this.Data.Length == 1)
            {
                this.InputOutputManager.TraverseDirectory(0);
            }
            else if (this.Data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(this.Data[1], out depth);

                if (hasParsed)
                {
                    this.InputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new InvalidCommandException(this.Input);
                }
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
