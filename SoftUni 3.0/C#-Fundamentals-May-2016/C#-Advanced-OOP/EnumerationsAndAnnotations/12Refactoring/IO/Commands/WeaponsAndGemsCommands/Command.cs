namespace _12Refactoring.IO.Commands.WeaponsAndGemsCommands
{
    using Factories.GemFactory;
    using Factories.WeaponFactory;
    using Factories.WeaponFactory.Weapons;
    using Interfaces.IO;

    public abstract class Command : IExecutable
    {
        protected Command(
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
}
