namespace AirConditionerTester.IO
{
    using Commands;

    public interface IController
    {
        IExecutable InterpretCommand(string commandName, string[] commandArgs);
    }
}
