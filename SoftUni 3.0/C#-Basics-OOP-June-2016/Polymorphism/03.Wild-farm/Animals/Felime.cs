namespace WildFarm.Animals
{
    public abstract class Felime : Mammal
    {
        #region Constructors

        public Felime(string animalName, double animalWeight, string livingRegion) 
            : base(animalName, animalWeight, livingRegion)
        {
        }

        #endregion Constructors
    }
}
