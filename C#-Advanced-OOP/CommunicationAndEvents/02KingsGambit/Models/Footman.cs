namespace _02KingsGambit.Models
{
    using System;

    public class Footman : Troop
    {
        public Footman(string name) 
            : base(name)
        {
        }

        public override void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
