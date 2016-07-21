namespace _10InfernoInfinity.Weapons
{
    public class KnifeWeapon : Weapon
    {
        private const int PureMinDamage = 3;
        private const int PureMaxDamage = 4;
        private const int NumberOfSockets = 2;

        public KnifeWeapon(
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