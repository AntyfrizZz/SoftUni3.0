namespace _10InfernoInfinity.Weapons
{
    public class AxeWeapon : Weapon
    {
        private const int PureMinDamage = 5;
        private const int PureMaxDamage = 10;
        private const int NumberOfSockets = 4;

        public AxeWeapon(
            WeaponRarity rarity, 
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