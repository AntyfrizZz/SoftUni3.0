namespace _02KingsGambit.Models
{
    using System;

    public delegate void KingUnderAttackEventHandler(object sender, EventArgs args);

    public class King
    {
        private string name;

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
    }
}
