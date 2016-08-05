namespace Executor.IO
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Commands;
    using Contracts.IO;
    using Contracts.Judge;
    using Contracts.Network;
    using Contracts.Repository;
    using Exceptions;

    public class CommandInterpreter : IInterpreter
    {
        private readonly IDownloadManager downloadManager;
        private readonly IDirectoryManager inputOutputManager;
        private readonly IContentComparer judge;
        private readonly IDatabase repository;

        public CommandInterpreter(
            IContentComparer judge,
            IDatabase repository,
            IDownloadManager downloadManager,
            IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.downloadManager = downloadManager;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            var data = input.Split(' ');
            var commandName = data[0].ToLower();

            try
            {
                var command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstruction = {input, data};

            var typeOfCommand = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(
                    t => t.GetCustomAttributes(typeof(AliasAttribute))
                        .Where(atr => atr.Equals(command))
                        .ToArray()
                        .Length > 0);

            var typeOfInterpreter = typeof(CommandInterpreter);

            var fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var fieldsOfInterpreter = typeOfInterpreter
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atr = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atr != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand
                            .SetValue(
                                exe, 
                                fieldsOfInterpreter
                                    .First(x => x.FieldType == fieldOfCommand.FieldType)
                                    .GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}