namespace _10InfernoInfinity.Weapons
{
    public class SwordWeapon : Weapon
    {
        private const int PureMinDamage = 4;
        private const int PureMaxDamage = 6;
        private const int NumberOfSockets = 3;

        public SwordWeapon(
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