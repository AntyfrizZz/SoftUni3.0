namespace LambdaCore_Skeleton
{
    using Contracts.Core;
    using Contracts.Repositories;
    using Core;
    using Core.Factories;
    using Repositories;

    public class Startup
    {
        public static void Main()
        {
            ICoreFactory coreFactory = new CoreFactory();
            IFragmentFactory fragmentFactory = new FragmentFactory();
            IRepository powerPlantRepository = new PowerPlantRepository();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(coreFactory, fragmentFactory, powerPlantRepository);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
