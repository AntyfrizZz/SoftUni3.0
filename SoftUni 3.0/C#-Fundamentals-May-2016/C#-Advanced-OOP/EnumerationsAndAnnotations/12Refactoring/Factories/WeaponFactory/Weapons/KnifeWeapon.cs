namespace _12Refactoring.Factories.WeaponFactory.Weapons
{
    using Enumerations;

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
}