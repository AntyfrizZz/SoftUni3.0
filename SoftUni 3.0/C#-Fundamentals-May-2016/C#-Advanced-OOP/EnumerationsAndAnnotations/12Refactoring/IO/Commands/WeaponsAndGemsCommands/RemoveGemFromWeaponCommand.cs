namespace _12Refactoring.IO.Commands.WeaponsAndGemsCommands
{
    using Factories.GemFactory;
    using Factories.WeaponFactory;
    using Factories.WeaponFactory.Weapons;
    using Interfaces.IO;

    public class RemoveGemFromWeaponCommand : Command
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
}
