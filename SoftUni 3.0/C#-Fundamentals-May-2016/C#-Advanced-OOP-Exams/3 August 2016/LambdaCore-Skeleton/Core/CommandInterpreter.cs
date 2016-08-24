namespace LambdaCore_Skeleton.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Commands;
    using Contracts.Core;
    using Contracts.Repositories;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandsNamespacePath = "LambdaCore_Skeleton.Core.Commands.";
        private const string CommandSuffix = "Command";

        private ICoreFactory coreFactory;
        private IFragmentFactory fragmentFactory;
        private IRepository powerPlantRepository;

        public CommandInterpreter(ICoreFactory coreFactory, IFragmentFactory fragmentFactory, IRepository powerPlantRepository)
        {
            this.coreFactory = coreFactory;
            this.fragmentFactory = fragmentFactory;
            this.powerPlantRepository = powerPlantRepository;
        }

        public IExecutable InterpretCommand(string commandName, string[] commandArgs)
        {
            var commandFullName =
                CommandsNamespacePath +
                commandName +
                CommandSuffix;

            Type t = Type.GetType(commandFullName);
            object[] commandParameters = new object[] { commandArgs };

            IExecutable command = null;

            try
            {
                command = (Command)Activator.CreateInstance(t, commandParameters);
            }
            catch
            {
                throw new InvalidOperationException("Invalid command!!!");
            }

            command = this.InjectDependencies(command);
            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] fieldsOfCommand = command.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] fieldsOfInterpreter = typeof(CommandInterpreter)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));

                if (fieldAttribute == null)
                {
                    continue;
                }

                var firstOrDefault = fieldsOfInterpreter.FirstOrDefault(x => x.FieldType == field.FieldType);

                if (firstOrDefault != null)
                {
                    var setField = firstOrDefault
                        .GetValue(this);

                    field.SetValue(command, setField);
                }
            }

            return command;
        }
    }
}