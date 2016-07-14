using System;
using Executor.Network;
using Executor.IO;
using Executor.Judge;
using Executor.Repository;

namespace Executor
{
    class Program
    {
        static void Main()
        {                  
            Tester tester = new Tester();
            DownloadManager downloadManager = new DownloadManager();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositorySorter(), new RepositioryFilter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, downloadManager, ioManager);
            InputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}