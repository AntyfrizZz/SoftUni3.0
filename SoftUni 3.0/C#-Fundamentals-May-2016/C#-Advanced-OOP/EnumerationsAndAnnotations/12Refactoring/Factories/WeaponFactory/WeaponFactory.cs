namespace _12Refactoring.Factories.WeaponFactory
{
    using Enumerations;
    using Weapons;

    public class WeaponFactory
    {
        public Weapon CreateWeapon(WeaponRarities weaponRarity, WeaponTypes weaponType, string weaponName)
        {
            Weapon weapon = null;

            switch (weaponType)
            {
                case WeaponTypes.Axe:
                    weapon = new AxeWeapon(weaponRarity, weaponType, weaponName);
                    break;
                case WeaponTypes.Knife:
                    weapon = new KnifeWeapon(weaponRarity, weaponType, weaponName);
                    break;
                case WeaponTypes.Sword:
                    weapon = new SwordWeapon(weaponRarity, weaponType, weaponName);
                    break;
            }

            return weapon;
        }
    }
}
