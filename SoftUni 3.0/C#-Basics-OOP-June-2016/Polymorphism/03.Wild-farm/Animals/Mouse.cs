namespace WildFarm.Animals
{
    using System;

    using Foods;

    public class Mouse : Mammal
    {
        #region Constructors

        public Mouse(string animalName, double animalWeight, string livingRegion)
            : base(animalName, animalWeight, livingRegion)
        {
        }

        #endregion Constructors

        //===========================

        #region Methods

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
            }
            else
            {
                this.FoodEaten += food.Quantity;
            }
        }

        public override string ToString()
        {
            return
                $"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

        #endregion Methods
    }
}
