namespace _05KingsGambitExtended.Models
{
    using System;
    using EventsArguments;

    public delegate void TroopDeathEventHandler(object sender, TroopDeathEventArgs args);

    public abstract class Troop
    {
        private int health;

        protected Troop(string name, int health)
        {
            this.Name = name;
            this.health = health;
        }

        public event TroopDeathEventHandler TroopDeath;

        public string Name { get; }

        public void RespondToAttack()
        {
            this.health--;
            if (this.health == 0)
            {
                this.OnTroopDeath(new TroopDeathEventArgs(this.Name, this.OnKingAttack));
            }
        }

        public abstract void OnKingAttack(object sender, EventArgs args);

        private void OnTroopDeath(TroopDeathEventArgs args)
        {
            this.TroopDeath?.Invoke(this, args);
        }
    }
}
