namespace _10InfernoInfinity.Weapons
{
    using Gems;

    public abstract class Weapon
    {
        private WeaponTypes type;
        private WeaponRarity rarity;
        private string name;

        private int minDamage;
        private int maxDamage;

        private int numberOfSockets;
        private Gem[] sockets;

        private int strengthBonus;
        private int agilityBonus;
        private int vitalityBonus;

        protected Weapon(
            WeaponRarity rarity,
            WeaponTypes type,
            string name,
            int minDamage,
            int maxDamage,
            int numberOfSockets)
        {
            this.rarity = rarity;
            this.type = type;
            this.name = name;

            this.minDamage = minDamage * (int)rarity;
            this.maxDamage = maxDamage * (int)rarity;

            this.numberOfSockets = numberOfSockets;
            this.sockets = new Gem[numberOfSockets];
        }

        public virtual void AddGem(int index, Gem gem)
        {
            if (index < 0 || index >= this.sockets.Length)
            {
                return;
            }

            if (this.sockets[index] != null)
            {
                this.RemoveGem(index);
            }

            this.strengthBonus += gem.StrengthIncrease;
            this.agilityBonus += gem.AgilityIncrease;
            this.vitalityBonus += gem.VitalityIncrease;

            this.minDamage += gem.MinDamageIncrease;
            this.maxDamage += gem.MaxDamageIncrease;

            this.sockets[index] = gem;
        }

        public virtual void RemoveGem(int index)
        {
            if (index < 0 || index > this.sockets.Length)
            {
                return;
            }

            if (this.sockets[index] == null)
            {
                return;
            }

            this.strengthBonus -= this.sockets[index].StrengthIncrease;
            this.agilityBonus -= this.sockets[index].AgilityIncrease;
            this.vitalityBonus -= this.sockets[index].VitalityIncrease;

            this.minDamage -= this.sockets[index].MinDamageIncrease;
            this.maxDamage -= this.sockets[index].MaxDamageIncrease;

            this.sockets[index] = null;
        }

        public override string ToString()
        {
            return $"{this.name}: {this.minDamage}-{this.maxDamage} Damage, +{this.strengthBonus} Strength, +{this.agilityBonus} Agility, +{this.vitalityBonus} Vitality";
        }
    }
}