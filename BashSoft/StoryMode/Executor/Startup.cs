namespace Executor
{
    using Contracts.IO;
    using Contracts.Judge;
    using Contracts.Network;
    using Contracts.Repository;
    using IO;
    using Judge;
    using Network;
    using Repository;

    public class Startup
    {
        public static void Main()
        {                  
            IContentComparer tester = new Tester();
            IDownloadManager downloadManager = new DownloadManager();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositorySorter(), new RepositioryFilter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, downloadManager, ioManager);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}