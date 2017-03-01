namespace _12Refactoring.Factories.WeaponFactory.Weapons
{
    using Enumerations;

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
}