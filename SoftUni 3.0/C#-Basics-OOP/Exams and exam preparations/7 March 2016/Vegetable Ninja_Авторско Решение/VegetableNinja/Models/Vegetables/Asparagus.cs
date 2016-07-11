namespace VegetableNinja.Models.Vegetables
{
    using VegetableNinja.Interfaces;

    public class Asparagus : Vegetable
    {
        private const char DefaultAsparagusCharValue = 'A';

        private const int DefaultAsparagusPowerBonus = 5;

        private const int DefaultAsparagusStaminaBonus = -5;

        private const int DefaultAsparagusTimeToGrow = 2;

        public Asparagus(IMatrixPosition position)
            : base(position, DefaultAsparagusCharValue, DefaultAsparagusPowerBonus, DefaultAsparagusStaminaBonus, DefaultAsparagusTimeToGrow)
        {
        }
    }
}
