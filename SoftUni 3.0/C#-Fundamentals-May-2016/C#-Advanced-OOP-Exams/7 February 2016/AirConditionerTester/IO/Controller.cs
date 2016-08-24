namespace AirConditionerTester.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using Commands;
    using Database;
    using Utilities;

    public class Controller : IController
    {
        private readonly IDatabase database;
        private readonly IInjector injector;
        private readonly IDictionary<string, Type> commands;

        public Controller(IDatabase database, IInjector injector)
        {
            this.database = database;
            this.injector = injector;
            this.commands = new Dictionary<string, Type>();
            this.FillCommands();
        }

        public Controller()
            : this(new Database(), new Injector())
        {
        }

        public IExecutable InterpretCommand(string commandName, string[] commandArgs)
        {
            if (!this.commands.ContainsKey(commandName))
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }

            var type = this.commands[commandName];

            var args = new object[] { commandArgs, this.database };

            IExecutable command = (IExecutable)Activator.CreateInstance(type, args);

            this.injector.Inject(command);

            return command;
        }

        private void FillCommands()
        {
            var types = Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(t => t.FullName.Contains("Command") && !t.IsAbstract);

            foreach (var type in types)
            {
                var indexOfLastDot = type.FullName.LastIndexOf('.');
                var name = type.FullName.Substring(indexOfLastDot + 1);
                var key = name.Replace("Command", string.Empty);

                this.commands.Add(key, type);
            }
        }
    }
}
