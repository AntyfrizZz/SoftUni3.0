namespace _12Refactoring.Factories.WeaponFactory.Weapons
{
    using Enumerations;

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
}