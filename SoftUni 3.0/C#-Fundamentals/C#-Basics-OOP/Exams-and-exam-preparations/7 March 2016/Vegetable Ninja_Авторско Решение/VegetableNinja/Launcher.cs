namespace VegetableNinja
{
    using VegetableNinja.Core;
    using VegetableNinja.Data;
    using VegetableNinja.Interfaces;
    using VegetableNinja.IO;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            IInputReader consoleReader = new ConsoleReader();
            
            IOutputWriter consoleWriter = new ConsoleWriter();

            IDatabase database = new Database();

            IGameController gameController = new GameController(database);

            IEngine engine = new Engine(consoleReader, consoleWriter, gameController);
            engine.Run();
        }
    }
}
