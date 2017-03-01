namespace _05KingsGambitExtended.Models
{
    using System;

    public class RoyalGuard : Troop
    {
        private const int Healthpoints = 3;

        public RoyalGuard(string name) 
            : base(name, Healthpoints)
        {
        }

        public override void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
