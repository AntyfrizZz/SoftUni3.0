namespace _12Refactoring.IO
{
    using System;
    using Enumerations;
    using Interfaces.IO;

    public class InputReader : IReader
    {
        private const string EndCommand = "END";

        private readonly CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            var input = Console.ReadLine();

            while (!input.Equals(EndCommand))
            {
                var inputArgs = input
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                switch (inputArgs[0])
                {
                    case "Create":
                        {
                            var weaponArgs = inputArgs[1]
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            var weaponRarity = (WeaponRarities)Enum.Parse(typeof(WeaponRarities), weaponArgs[0]);
                            var weaponType = (WeaponTypes)Enum.Parse(typeof(WeaponTypes), weaponArgs[1]);

                            this.interpreter.WeaponRarity = weaponRarity;
                            this.interpreter.WeaponType = weaponType;
                            this.interpreter.WeaponName = inputArgs[2];
                        }

                        break;
                    case "Add":
                        {
                            var gemArgs = inputArgs[3]
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            var gemClarity = (GemClarities)Enum.Parse(typeof(GemClarities), gemArgs[0]);
                            var gemType = (GemTypes)Enum.Parse(typeof(GemTypes), gemArgs[1]);

                            this.interpreter.WeaponName = inputArgs[1];
                            this.interpreter.GemIndex = int.Parse(inputArgs[2]);
                            this.interpreter.GemClarity = gemClarity;
                            this.interpreter.GemType = gemType;
                        }

                        break;
                    case "Remove":
                        this.interpreter.WeaponName = inputArgs[1];
                        this.interpreter.GemIndex = int.Parse(inputArgs[2]);
                        break;
                    case "Print":
                        this.interpreter.WeaponName = inputArgs[1];
                        break;
                }

                this.interpreter.InterpretCommand(inputArgs[0]);

                input = Console.ReadLine();
            }
        }
    }
}
