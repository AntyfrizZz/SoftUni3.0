namespace WildFarm.Animals
{
    public abstract class Mammal : Animal
    {
        #region Constructors

        public Mammal(string animalName, double animalWeight, string livingRegion)
            : base(animalName, animalWeight)
        {
            this.LivingRegion = livingRegion;
        }

        #endregion Constructors

        //===========================

        #region Properties

        public string LivingRegion { get; private set; }

        #endregion Properties
    }
}
