namespace WildFarm.Animals
{
    using System;

    using Foods;

    public class Cat : Felime
    {
        #region Constructors

        public Cat(string animalName, double animalWeight, string livingRegion, string breed)
            : base(animalName, animalWeight, livingRegion)
        {
            this.Breed = breed;
        }

        #endregion Constructors

        //===========================

        #region Properties

        public string Breed { get; private set; }

        #endregion Properties

        //===========================

        #region Methods

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return
                $"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

        #endregion Methods
    }
}
