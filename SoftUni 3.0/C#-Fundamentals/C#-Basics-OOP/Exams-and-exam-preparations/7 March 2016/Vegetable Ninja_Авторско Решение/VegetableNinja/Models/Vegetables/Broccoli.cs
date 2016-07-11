namespace VegetableNinja.Models.Vegetables
{
    using VegetableNinja.Interfaces;

    public class Broccoli : Vegetable
    {
        private const char DefaultBroccoliCharValue = 'B';

        private const int DefaultBroccoliPowerBonus = 10;

        private const int DefaultBroccoliStaminaBonus = 0;

        private const int DefaultBroccoliTimeToGrow = 3;

        public Broccoli(IMatrixPosition position)
            : base(position, DefaultBroccoliCharValue, DefaultBroccoliPowerBonus, DefaultBroccoliStaminaBonus, DefaultBroccoliTimeToGrow)
        {
        }
    }
}
