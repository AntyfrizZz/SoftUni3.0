namespace SystemSplit.IO
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Commands;

    public class CommandInterpreter
    {
        public void InterpredCommand(string input)
        {
            Command command = this.ParseCommand(input);
            command.Execute();
        }

        private Command ParseCommand(string command)
        {
            string pattern = @"([a-zA-Z0-9]+)\(([a-zA-Z0-9,\s]*)\)";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(command);

            string commandName = string.Empty;

            if (matches.Count != 0)
            {
                commandName = matches[0].Groups[1].Value;
            }
            else
            {
                commandName = "System Split";
            }

            string[] args = null;

            if (!commandName.Equals("System Split"))
            {
                args = matches[0].Groups[2].Value
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            switch (commandName)
            {
                case "RegisterPowerHardware":
                    {
                        var powerHardwareName = args[0];
                        var powerHardwareCapacity = int.Parse(args[1]);
                        var powerHardwareMemory = int.Parse(args[2]);

                        return new RegisterPowerHardwareCommand(powerHardwareName, powerHardwareCapacity, powerHardwareMemory);
                    }

                case "RegisterHeavyHardware":
                    {
                        var heavyHardwareName = args[0];
                        var heavyHardwareCapacity = int.Parse(args[1]);
                        var heavyHardwareMemory = int.Parse(args[2]);

                        return new RegisterHeavyHardwareCommand(heavyHardwareName, heavyHardwareCapacity, heavyHardwareMemory);
                    }


                case "RegisterExpressSoftware":
                    {
                        var hardwareName = args[0];
                        var expressSoftwareName = args[1];
                        var expressSoftwareCapacity = int.Parse(args[2]);
                        var expressSoftwareMemory = int.Parse(args[3]);

                        return new RegisterExpressSoftwareCommand(hardwareName, expressSoftwareName, expressSoftwareCapacity, expressSoftwareMemory);
                    }

                case "RegisterLightSoftware":
                    {
                        var hardware = args[0];
                        var lightSoftwareName = args[1];
                        var lightSoftwareCapacity = int.Parse(args[2]);
                        var lightSoftwareMemory = int.Parse(args[3]);

                        return new RegisterLightSoftwareCommand(hardware, lightSoftwareName, lightSoftwareCapacity, lightSoftwareMemory);
                    }

                case "ReleaseSoftwareComponent":
                    {
                        var hardwareComponentName = args[0];
                        var softwareName = args[1];

                        return new ReleaseSoftwareComponentCommand(hardwareComponentName, softwareName);
                    }

                case "Analyze":
                    return new AnalyzeCommand();

                case "System Split":
                    return new SystemSplitCommand();

                case "Dump":
                    {
                        var hardwareForDump = args[0];

                        return new DumpCommand(hardwareForDump);
                    }

                case "Restore":
                    {
                        var hardwareForRestore = args[0];

                        return new RestoreCommand(hardwareForRestore);
                    }

                case "Destroy":
                    {
                        var hardwareForDestroy = args[0];

                        return new DestroyCommand(hardwareForDestroy);
                    }

                case "DumpAnalyze":
                    return new DumpAnalyzeCommand();

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
