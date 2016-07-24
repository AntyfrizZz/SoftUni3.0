namespace _12Refactoring.Repository
{
    using System.Collections.Generic;
    using Factories.WeaponFactory.Weapons;
    using Interfaces.IO;

    public class WeaponRepository : IDatabase<Weapon>
    {
        private readonly Dictionary<string, Weapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new Dictionary<string, Weapon>();
        }

        public void Add(Weapon weapon)
        {
            this.weapons.Add(weapon.Name, weapon);
        }

        public Weapon Get(string name)
        {
            return this.weapons[name];
        }
    }
}
