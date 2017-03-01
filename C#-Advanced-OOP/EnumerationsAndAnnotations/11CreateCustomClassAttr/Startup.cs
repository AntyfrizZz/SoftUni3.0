namespace _11CreateCustomClassAttr
{
    // See 12Refractoring. Thes ize of the fail is too big for this task

    using System;
    using System.Collections.Generic;

    public class WeaponRepository : IDatabase<Weapon>
    {private readonly Dictionary<string, Weapon> weapons;public WeaponRepository(){this.weapons = new Dictionary<string, Weapon>();}public void Add(Weapon weapon){this.weapons.Add(weapon.Name, weapon);}public Weapon Get(string name){return this.weapons[name];}}
    public static class OutputWriter{public static void WriteMessage(string message){Console.Write(message);}
        public static void WriteMessageOnNewLine(string message){Console.WriteLine(message);}
        public static void WriteEmptyLine(){Console.WriteLine();}}public class InputReader : IReader{private const string EndCommand = "END";
        private readonly CommandInterpreter interpreter;public InputReader(CommandInterpreter interpreter){this.interpreter = interpreter;}public void StartReadingCommands(){
            var input = Console.ReadLine();while (!input.Equals(EndCommand)){var inputArgs = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                switch (inputArgs[0]){case "Create":{var weaponArgs = inputArgs[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);var weaponRarity = (WeaponRarities)Enum.Parse(typeof(WeaponRarities), weaponArgs[0]);var weaponType = (WeaponTypes)Enum.Parse(typeof(WeaponTypes), weaponArgs[1]);this.interpreter.WeaponRarity = weaponRarity;this.interpreter.WeaponType = weaponType;this.interpreter.WeaponName = inputArgs[2];}break;case "Add":{
                            var gemArgs = inputArgs[3].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);var gemClarity = (GemClarities)Enum.Parse(typeof(GemClarities), gemArgs[0]);var gemType = (GemTypes)Enum.Parse(typeof(GemTypes), gemArgs[1]);

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
    public class RemoveGemFromWeaponCommand : WeaponAndGemsCommand
    {
        private int socketIndex;

        public RemoveGemFromWeaponCommand(
            IDatabase<Weapon> repository,
            WeaponFactory weaponFactory,
            GemFactory gemFactory,
            string weaponName,
            int socketIndex)
            : base(repository, weaponFactory, gemFactory, weaponName)
        {
            this.socketIndex = socketIndex;
        }

        public override void Execute()
        {
            Weapon currentWeapon = this.Repository.Get(this.WeaponName);

            currentWeapon.RemoveGem(this.socketIndex);
        }
    }
    public class PrintCommand : WeaponAndGemsCommand
    {
        public PrintCommand(
            IDatabase<Weapon> repository,
            WeaponFactory weaponFactory,
            GemFactory gemFactory,
            string weaponName)
            : base(repository, weaponFactory, gemFactory, weaponName)
        {
        }

        public override void Execute()
        {
            Weapon currentWeapon = this.Repository.Get(this.WeaponName);

            OutputWriter.WriteMessageOnNewLine(currentWeapon.ToString());
        }
    }
    public class CreateWeaponCommand : WeaponAndGemsCommand
    {
        private readonly WeaponRarities weaponRarity;
        private readonly WeaponTypes weaponType;

        public CreateWeaponCommand(
            IDatabase<Weapon> repository,
            WeaponFactory weaponFactory,
            GemFactory gemFactory,
            string weaponName,
            WeaponRarities weaponRarity,
            WeaponTypes weaponType)
            : base(repository, weaponFactory, gemFactory, weaponName)
        {
            this.weaponRarity = weaponRarity;
            this.weaponType = weaponType;
        }

        public override void Execute()
        {
            Weapon weapon = this.WeaponFactory.CreateWeapon(this.weaponRarity, this.weaponType, this.WeaponName);
            this.Repository.Add(weapon);
        }
    }
    
    public class AddGemToSocketCommand : WeaponAndGemsCommand
    {
        private readonly int socketIndex;
        private readonly GemClarities gemClarity;
        private readonly GemTypes gemType;

        public AddGemToSocketCommand(
            IDatabase<Weapon> repository,
            WeaponFactory weaponFactory,
            GemFactory gemFactory,
            string weaponName,
            int socketIndex,
            GemClarities gemClarity,
            GemTypes gemType)
            : base(repository, weaponFactory, gemFactory, weaponName)
        {
            this.socketIndex = socketIndex;
            this.gemClarity = gemClarity;
            this.gemType = gemType;
        }

        public override void Execute()
        {
            Gem gem = this.GemFactory.CreateGem(this.gemType, this.gemClarity);
            var currentWeapon = this.Repository.Get(this.WeaponName);

            currentWeapon.AddGem(this.socketIndex, gem);
        }
    }
    public class RevisionCommand : AttributeCommand
    {
        public override void Execute()
        {
            var attributes = typeof(Weapon).GetCustomAttributes(false);

            foreach (ClassInfoAttribute info in attributes)
            {
                OutputWriter.WriteMessageOnNewLine($"Revision: {info.Revision}");
            }
        }
    }
    public class ReviewersCommand : AttributeCommand
    {
        public override void Execute()
        {
            var attributes = typeof(Weapon).GetCustomAttributes(false);

            foreach (ClassInfoAttribute info in attributes)
            {
                OutputWriter.WriteMessageOnNewLine($"Reviewers: {string.Join(", ", info.Reviewers)}");
            }
        }
    }
    public class DescriptionCommand : AttributeCommand
    {
        public override void Execute()
        {
            var attributes = typeof(Weapon).GetCustomAttributes(false);

            foreach (ClassInfoAttribute info in attributes)
            {
                OutputWriter.WriteMessageOnNewLine($"Class description: {info.Description}");
            }
        }
    }
    public abstract class WeaponAndGemsCommand : IExecutable
    {
        protected WeaponAndGemsCommand(
            IDatabase<Weapon> repository,
            WeaponFactory weaponFactory,
            GemFactory gemFactory,
            string weaponName)
        {
            this.Repository = repository;
            this.WeaponFactory = weaponFactory;
            this.GemFactory = gemFactory;
            this.WeaponName = weaponName;
        }

        protected IDatabase<Weapon> Repository { get; }

        protected WeaponFactory WeaponFactory { get; }

        protected GemFactory GemFactory { get; }

        protected string WeaponName { get; }

        public abstract void Execute();
    }
    public abstract class AttributeCommand : IExecutable
    {
        public abstract void Execute();
    }
    public class AuthorCommand : AttributeCommand
    {
        public override void Execute()
        {
            var attributes = typeof(Weapon).GetCustomAttributes(false);

            foreach (ClassInfoAttribute info in attributes)
            {
                OutputWriter.WriteMessageOnNewLine($"Author: {info.Author}");
            }
        }
    }
    public interface IReader
    {
        void StartReadingCommands();
    }
    public interface IInterpreter
    {
        void InterpretCommand(string command);
    }
    public interface IExecutable
    {
        void Execute();
    }
    public interface IDatabase<T>
    {
        void Add(T weapon);

        T Get(string name);
    }
    [ClassInfo("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", new string[] { "Pesho", "Svetlio" })]
    public abstract class Weapon
    {
        private WeaponTypes type;
        private WeaponRarities rarity;

        private int minDamage;
        private int maxDamage;

        private Gem[] sockets;

        private int strengthBonus;
        private int agilityBonus;
        private int vitalityBonus;

        protected Weapon(
            WeaponRarities rarity,
            WeaponTypes type,
            string name,
            int minDamage,
            int maxDamage,
            int numberOfSockets)
        {
            this.rarity = rarity;
            this.type = type;
            this.Name = name;

            this.minDamage = minDamage * (int)rarity;
            this.maxDamage = maxDamage * (int)rarity;

            this.sockets = new Gem[numberOfSockets];
        }

        public string Name { get; }

        public virtual void AddGem(int index, Gem gem)
        {
            if (index < 0 || index >= this.sockets.Length)
            {
                return;
            }

            if (this.sockets[index] != null)
            {
                this.RemoveGem(index);
            }

            this.strengthBonus += gem.StrengthIncrease;
            this.agilityBonus += gem.AgilityIncrease;
            this.vitalityBonus += gem.VitalityIncrease;

            this.minDamage += gem.MinDamageIncrease;
            this.maxDamage += gem.MaxDamageIncrease;

            this.sockets[index] = gem;
        }

        public virtual void RemoveGem(int index)
        {
            if (index < 0 || index > this.sockets.Length)
            {
                return;
            }

            if (this.sockets[index] == null)
            {
                return;
            }

            this.strengthBonus -= this.sockets[index].StrengthIncrease;
            this.agilityBonus -= this.sockets[index].AgilityIncrease;
            this.vitalityBonus -= this.sockets[index].VitalityIncrease;

            this.minDamage -= this.sockets[index].MinDamageIncrease;
            this.maxDamage -= this.sockets[index].MaxDamageIncrease;

            this.sockets[index] = null;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.minDamage}-{this.maxDamage} Damage, +{this.strengthBonus} Strength, +{this.agilityBonus} Agility, +{this.vitalityBonus} Vitality";
        }
    }
    public class SwordWeapon : Weapon
    {
        private const int PureMinDamage = 4;
        private const int PureMaxDamage = 6;
        private const int NumberOfSockets = 3;

        public SwordWeapon(
            WeaponRarities rarity,
            WeaponTypes type,
            string name)
            : base(
                  rarity,
                  type,
                  name,
                  PureMinDamage,
                  PureMaxDamage,
                  NumberOfSockets)
        {
        }
    }
    public class KnifeWeapon : Weapon
    {
        private const int PureMinDamage = 3;
        private const int PureMaxDamage = 4;
        private const int NumberOfSockets = 2;

        public KnifeWeapon(
            WeaponRarities rarity,
            WeaponTypes type,
            string name)
            : base(
                  rarity,
                  type,
                  name,
                  PureMinDamage,
                  PureMaxDamage,
                  NumberOfSockets)
        {
        }
    }
    public class AxeWeapon : Weapon
    {
        private const int PureMinDamage = 5;
        private const int PureMaxDamage = 10;
        private const int NumberOfSockets = 4;

        public AxeWeapon(
            WeaponRarities rarity,
            WeaponTypes type,
            string name)
            : base(
                  rarity,
                  type,
                  name,
                  PureMinDamage,
                  PureMaxDamage,
                  NumberOfSockets)
        {
        }
    }
    public class WeaponFactory
    {
        public Weapon CreateWeapon(WeaponRarities weaponRarity, WeaponTypes weaponType, string weaponName)
        {
            Weapon weapon = null;

            switch (weaponType)
            {
                case WeaponTypes.Axe:
                    weapon = new AxeWeapon(weaponRarity, weaponType, weaponName);
                    break;
                case WeaponTypes.Knife:
                    weapon = new KnifeWeapon(weaponRarity, weaponType, weaponName);
                    break;
                case WeaponTypes.Sword:
                    weapon = new SwordWeapon(weaponRarity, weaponType, weaponName);
                    break;
            }

            return weapon;
        }
    }
    public class RubyGem : Gem
    {
        private const int Strength = 7;
        private const int Agility = 2;
        private const int Vitality = 5;

        public RubyGem(
            GemTypes gemType,
            GemClarities gemClarity)
            : base(
                  gemType,
                  gemClarity,
                  Strength,
                  Agility,
                  Vitality)
        {
        }
    }
    public class Gem
    {
        private const int StrengthMinDamageIncrease = 2;
        private const int StrengthMaxDamageIncrease = 3;
        private const int AgilityhMinDamageIncrease = 1;
        private const int AgilityhMaxDamageIncrease = 4;

        private GemTypes gemType;
        private GemClarities gemClarity;

        public Gem(
            GemTypes gemType,
            GemClarities gemClarity,
            int strengthIncrease,
            int agilityIncrease,
            int vitalityIncrease)
        {
            this.gemType = gemType;
            this.gemClarity = gemClarity;

            this.StrengthIncrease = (int)gemClarity + strengthIncrease;
            this.AgilityIncrease = (int)gemClarity + agilityIncrease;
            this.VitalityIncrease = (int)gemClarity + vitalityIncrease;

            this.MinDamageIncrease =
                (StrengthMinDamageIncrease * this.StrengthIncrease) +
                (AgilityhMinDamageIncrease * this.AgilityIncrease);

            this.MaxDamageIncrease =
                (StrengthMaxDamageIncrease * this.StrengthIncrease) +
                (AgilityhMaxDamageIncrease * this.AgilityIncrease);
        }

        public int StrengthIncrease { get; }

        public int AgilityIncrease { get; }

        public int VitalityIncrease { get; }

        public int MinDamageIncrease { get; }

        public int MaxDamageIncrease { get; }
    }
    public class EmeraldGem : Gem
    {
        private const int Strength = 1;
        private const int Agility = 4;
        private const int Vitality = 9;

        public EmeraldGem(
            GemTypes gemType,
            GemClarities gemClarity)
            : base(
                  gemType,
                  gemClarity,
                  Strength,
                  Agility,
                  Vitality)
        {
        }
    }
    public class AmethystGem : Gem
    {
        private const int Strength = 2;
        private const int Agility = 8;
        private const int Vitality = 4;

        public AmethystGem(
            GemTypes gemType,
            GemClarities gemClarity)
            : base(
                  gemType,
                  gemClarity,
                  Strength,
                  Agility,
                  Vitality)
        {
        }
    }
    public class GemFactory
    {
        public Gem CreateGem(GemTypes gemType, GemClarities gemClarity)
        {
            Gem gem = null;

            switch (gemType)
            {
                case GemTypes.Amethyst:
                    gem = new AmethystGem(gemType, gemClarity);
                    break;
                case GemTypes.Emerald:
                    gem = new EmeraldGem(gemType, gemClarity);
                    break;
                case GemTypes.Ruby:
                    gem = new RubyGem(gemType, gemClarity);
                    break;
            }

            return gem;
        }
    }
    public enum WeaponTypes
    {
        Axe,
        Sword,
        Knife
    }
    public enum WeaponRarities
    {
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 5
    }
    public enum Stats
    {
        Strength,
        Agility,
        Vitality
    }
    public enum GemTypes
    {
        Ruby,
        Emerald,
        Amethyst
    }
    public enum GemClarities
    {
        Chipped = 1,
        Regular = 2,
        Perfect = 5,
        Flawless = 10
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassInfoAttribute : Attribute
    {
        public ClassInfoAttribute(string author, int revision, string description, string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; }

        public int Revision { get; }

        public string Description { get; }

        public string[] Reviewers { get; }
    }

    public class Startup
    {
        public static void Main()
        {
            var weaponRepository = new WeaponRepository();
            var weaponFactory = new WeaponFactory();
            var gemFactory = new GemFactory();
            var commandInterpreter = new CommandInterpreter(weaponRepository, weaponFactory, gemFactory);

            var inputReader = new InputReader(commandInterpreter);
            inputReader.StartReadingCommands();
        }
    }
}
