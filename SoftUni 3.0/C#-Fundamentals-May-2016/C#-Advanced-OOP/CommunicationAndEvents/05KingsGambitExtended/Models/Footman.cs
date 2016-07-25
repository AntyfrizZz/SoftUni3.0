namespace _05KingsGambitExtended.Models
{
    using System;

    public class Footman : Troop
    {
        private const int Healthpoints = 2;

        public Footman(string name) 
            : base(name, Healthpoints)
        {
        }

        public override void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
