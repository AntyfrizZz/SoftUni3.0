namespace _12Refactoring.IO
{
    using Commands.AttributeCommands;
    using Commands.WeaponsAndGemsCommands;
    using Enumerations;
    using Factories.GemFactory;
    using Factories.WeaponFactory;
    using Factories.WeaponFactory.Weapons;
    using Interfaces.IO;

    public class CommandInterpreter : IInterpreter
    {
        private readonly IDatabase<Weapon> repository;
        private readonly WeaponFactory weaponFactory;
        private readonly GemFactory gemFactory;

        public CommandInterpreter(
            IDatabase<Weapon> repository,
            WeaponFactory weaponFactory,
            GemFactory gemFactory)
        {
            this.repository = repository;
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
        }

        public WeaponRarities WeaponRarity { private get; set; }

        public WeaponTypes WeaponType { private get; set; }

        public string WeaponName { private get; set; }

        public int GemIndex { private get; set; }

        public GemClarities GemClarity { private get; set; }

        public GemTypes GemType { private get; set; }

        public void InterpretCommand(string commandName)
        {
            IExecutable command = this.ParseCommand(commandName);
            command.Execute();
        }

        private IExecutable ParseCommand(string commandName)
        {
            switch (commandName)
            {
                case "Create":
                    return new CreateWeaponCommand(
                        this.repository,
                        this.weaponFactory,
                        this.gemFactory,
                        this.WeaponName,
                        this.WeaponRarity,
                        this.WeaponType);
                case "Add":
                    return new AddGemToSocketCommand(
                        this.repository,
                        this.weaponFactory,
                        this.gemFactory,
                        this.WeaponName,
                        this.GemIndex,
                        this.GemClarity,
                        this.GemType);
                case "Remove":
                    return new RemoveGemFromWeaponCommand(
                        this.repository,
                        this.weaponFactory,
                        this.gemFactory,
                        this.WeaponName,
                        this.GemIndex);
                case "Print":
                    return new PrintCommand(
                        this.repository,
                        this.weaponFactory,
                        this.gemFactory,
                        this.WeaponName);
                case "Author":
                    return new AuthorCommand();
                case "Revision":
                    return new RevisionCommand();
                case "Description":
                    return new DescriptionCommand();
                case "Reviewers":
                    return new ReviewersCommand();
                default:
                    return null; // ????????????
            }
        }
    }
}
