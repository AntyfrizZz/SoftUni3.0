namespace _12Refactoring
{
    using Factories.GemFactory;
    using Factories.WeaponFactory;
    using IO;
    using Repository;

    public class Startup
    {
        public static void Main()
        {
            var weaponRepository = new WeaponRepository();
            var weaponFactory = new WeaponFactory();
            var gemFactory = new GemFactory();
            var commandInterpreter = new CommandInterpreter(weaponRepository, weaponFactory, gemFactory);

            var inputReader = new InputReader(commandInterpreter);
            inputReader.StartReadingCommands();
        }
    }
}
