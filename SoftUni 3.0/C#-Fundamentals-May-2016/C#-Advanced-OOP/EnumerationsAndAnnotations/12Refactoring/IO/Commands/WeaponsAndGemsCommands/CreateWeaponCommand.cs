namespace _12Refactoring.IO.Commands.WeaponsAndGemsCommands
{
    using Enumerations;
    using Factories.GemFactory;
    using Factories.WeaponFactory;
    using Factories.WeaponFactory.Weapons;
    using Interfaces.IO;

    public class CreateWeaponCommand : Command
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
}
