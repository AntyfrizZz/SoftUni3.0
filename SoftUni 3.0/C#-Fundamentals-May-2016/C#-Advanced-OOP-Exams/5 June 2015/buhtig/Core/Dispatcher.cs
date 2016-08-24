namespace Buhtig.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Commands;
    using Data;

    public class Dispatcher : IDispatcher
    {
        private readonly IIssueTrackerData data;
        private Dictionary<string, Type> commands;

        public Dispatcher(IIssueTrackerData data)
        {
            this.data = data;
            this.FindCommands();
        }

        public Dispatcher()
            : this(new IssueTrackerData())
        {
        }

        public string DispatchAction(IEndpoint endpoint)
        {
            if (!this.commands.ContainsKey(endpoint.ActionName))
            {
                throw new InvalidOperationException();
            }

            var parameters = new object[] { endpoint.ActionParameters, this.data };
            IExecutable commandToExecute = (IExecutable)Activator.CreateInstance(this.commands[endpoint.ActionName], parameters);
            return commandToExecute.Execute();
        }

        private void FindCommands()
        {
            this.commands = new Dictionary<string, Type>();

            var types =
                Assembly.GetEntryAssembly().GetTypes()
                    .Where(t =>
                        t.FullName.Contains("Command") &&
                        !t.IsAbstract);

            foreach (var type in types)
            {
                var key = type.Name.Replace("Command", string.Empty);

                this.commands.Add(key, type);
            }
        }
    }
}
