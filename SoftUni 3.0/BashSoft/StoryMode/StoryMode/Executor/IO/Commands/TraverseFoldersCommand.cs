﻿namespace Executor.IO.Commands
{
    using Attributes;
    using Contracts.IO;
    using Exceptions;

    [Alias("ls")]
    public class TraverseFoldersCommand : Command
    {
        [Inject] private IDirectoryManager inputOutputManager;

        public TraverseFoldersCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 1)
            {
                this.inputOutputManager.TraverseDirectory(0);
            }
            else if (this.Data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(this.Data[1], out depth);

                if (hasParsed)
                {
                    this.inputOutputManager.TraverseDirectory(depth);
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
