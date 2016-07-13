using System;

namespace _07.Food_Shortage.Models
{
    public class Citizen : Human
    {
        public Citizen(string name, int age, string id, string birthdate) 
            : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Id { get; }

        public string Birthdate { get; }

        public override void BuyFood()
        {
            base.Food += 10;
        }
    }
}
