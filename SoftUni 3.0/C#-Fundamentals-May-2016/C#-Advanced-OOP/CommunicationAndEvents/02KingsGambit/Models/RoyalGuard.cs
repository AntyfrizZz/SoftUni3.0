namespace _02KingsGambit.Models
{
    using System;

    public class RoyalGuard : Troop
    {
        public RoyalGuard(string name) 
            : base(name)
        {
        }

        public override void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
