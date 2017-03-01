namespace LambdaCore_Skeleton.Contracts.Core
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string commandName, string[] commandArgs);
    }
}