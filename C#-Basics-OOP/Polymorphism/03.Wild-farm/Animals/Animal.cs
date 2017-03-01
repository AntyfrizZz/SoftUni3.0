namespace WildFarm.Animals
{
    using Foods;

    public abstract class Animal
    {
        #region Constructors

        public Animal(string animalName, double animalWeight)
        {
            AnimalName = animalName;
            AnimalWeight = animalWeight;
        }
        #endregion Constructors

        //===========================

        #region Properties

        public string AnimalName { get; private set; }
        public double AnimalWeight { get; private set; }
        public int FoodEaten { get; protected set; }

        #endregion Properties

        //===========================

        #region Methods

        public abstract void MakeSound();

        public abstract void Eat(Food food);

        #endregion Methods
    }
}
