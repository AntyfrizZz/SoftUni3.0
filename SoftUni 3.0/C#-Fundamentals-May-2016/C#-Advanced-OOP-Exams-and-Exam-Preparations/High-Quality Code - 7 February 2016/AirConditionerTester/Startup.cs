namespace AirConditionerTester
{
    using Core;

    public class Startup
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
