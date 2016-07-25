namespace _05KingsGambitExtended.Models
{
    using System;
    using EventsArguments;

    public delegate void KingUnderAttackEventHandler(object sender, EventArgs args);

    public class King
    {
        private readonly string name;

        public King(string name)
        {
            this.name = name;
        }

        public event KingUnderAttackEventHandler KingAttacked;

        public void RespondToAttack()
        {
            Console.WriteLine($"King {this.name} is under attack!");
            this.OnKingAttack(new EventArgs());
        }

        public void OnKingAttack(EventArgs args)
        {
            this.KingAttacked?.Invoke(this, args);
        }

        public void OnTroopDeath(object sender, TroopDeathEventArgs args)
        {
            this.KingAttacked -= args.Respond;
        }
    }
}
