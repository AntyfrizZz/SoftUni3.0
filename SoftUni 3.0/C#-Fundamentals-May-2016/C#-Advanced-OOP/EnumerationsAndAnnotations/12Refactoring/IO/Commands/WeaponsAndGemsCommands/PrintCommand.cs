namespace _12Refactoring.IO.Commands.WeaponsAndGemsCommands
{
    using Factories.GemFactory;
    using Factories.WeaponFactory;
    using Factories.WeaponFactory.Weapons;
    using Interfaces.IO;

    public class PrintCommand : Command
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
}
