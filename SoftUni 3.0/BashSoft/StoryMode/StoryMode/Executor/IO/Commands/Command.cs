namespace Executor.IO.Commands
{
    using Exceptions;
    using Interfaces;

    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;

        protected Command(
            string input,
            string[] data,
            IContentComparer tester,
            IDatabase repository,
            IDownloadManager downloadManager,
            IDirectoryManager ioManager)
        {
            this.Input = input;
            this.Data = data;
            this.Tester = tester;
            this.Repository = repository;
            this.DownloadManager = downloadManager;
            this.InputOutputManager = ioManager;
        }

        public string Input
        {
            get
            {
                return this.input;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException(value);
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get
            {
                return this.data;
            }

            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new InvalidCommandException(this.Input);
                }

                this.data = value;
            }
        }

        protected IDatabase Repository { get; }

        protected IContentComparer Tester { get; }

        protected IDirectoryManager InputOutputManager { get; }

        protected IDownloadManager DownloadManager { get; }

        public abstract void Execute();
    }
}
