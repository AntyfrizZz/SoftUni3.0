using System;
using Executor.Exceptions;
using Executor.Network;
using Executor.Repository;
using Executor.Judge;

namespace Executor.IO.Commands
{
    using Contracts;
    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;

        private Tester tester;
        private StudentsRepository repository;
        private DownloadManager downloadManager;
        private IOManager inputOutputManager;

        public Command(string input, string[] data, Tester tester, StudentsRepository repository,
            DownloadManager downloadManager, IOManager ioManager)
        {
            this.Input = input;
            this.Data = data;
            this.tester = tester;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.inputOutputManager = ioManager;
        }

        public string Input
        {
            get { return this.input; }

            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException(value);
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get { return this.data; }

            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new InvalidCommandException(this.Input);
                }

                this.data = value;
            }
        }

        protected StudentsRepository Repository
        {
            get { return this.repository; }
        }

        protected Tester Tester
        {
            get { return this.tester; }
        }

        protected IOManager InputOutputManager
        {
            get { return this.inputOutputManager; }
        }

        protected DownloadManager DownloadManager
        {
            get { return this.downloadManager; }
        }

        public abstract void Execute();
    }
}
