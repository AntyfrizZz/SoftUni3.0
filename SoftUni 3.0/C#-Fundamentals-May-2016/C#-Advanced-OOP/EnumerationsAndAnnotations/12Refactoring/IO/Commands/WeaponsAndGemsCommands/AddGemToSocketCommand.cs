namespace _12Refactoring.IO.Commands.WeaponsAndGemsCommands
{
    using Enumerations;
    using Factories.GemFactory;
    using Factories.GemFactory.Gems;
    using Factories.WeaponFactory;
    using Factories.WeaponFactory.Weapons;
    using Interfaces.IO;

    public class AddGemToSocketCommand : Command
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
}
