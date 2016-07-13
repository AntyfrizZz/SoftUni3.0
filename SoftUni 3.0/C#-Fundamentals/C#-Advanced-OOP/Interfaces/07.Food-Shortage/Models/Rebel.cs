using System;

namespace _07.Food_Shortage.Models
{
    public class Rebel : Human
    {
        public Rebel(string name, int age, string group) 
            : base(name, age)
        {
            this.Group = group;
            this.Food = 0;
        }

        public string Group { get; }

        public override void BuyFood()
        {
            base.Food += 5;
        }
    }
}
