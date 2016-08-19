namespace AirConditionerTester.Core
{
    using System;
    using System.Reflection;
    using IO;
    using IO.Commands;
    using IO.UI;

    public class Engine : IEngine
    {
        private readonly IUserInterface userInterface;
        private readonly IController controller;

        public Engine(IUserInterface userInterface, IController controller)
        {
            this.userInterface = userInterface;
            this.controller = controller;
        }

        public Engine()
            : this(new ConsoleUserInterface(), new Controller())
        {
        }

        public void Run()
        {
            while (true)
            {
                string line = this.userInterface.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();

                try
                {
                    var commandInfo = line.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    var commandName = commandInfo[0].Trim();
                    string[] commandArgs = new string[0];

                    if (commandInfo.Length > 1)
                    {
                        commandArgs = commandInfo[1].Split(',');
                    }

                    IExecutable command = this.controller.InterpretCommand(commandName, commandArgs);
                    this.userInterface.WriteLine(command.Execute());
                }
                catch (InvalidOperationException ioe)
                {
                    this.userInterface.WriteLine(ioe.Message);
                }
                catch (ArgumentException ae)
                {
                    this.userInterface.WriteLine(ae.Message);
                }
                catch (TargetInvocationException tie)
                {
                    this.userInterface.WriteLine(tie.InnerException.Message);
                }
            }
        }
    }
}
