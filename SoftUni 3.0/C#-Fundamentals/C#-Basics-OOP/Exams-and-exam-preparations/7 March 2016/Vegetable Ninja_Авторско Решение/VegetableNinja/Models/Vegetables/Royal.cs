namespace VegetableNinja.Models.Vegetables
{
    using VegetableNinja.Interfaces;

    public class Royal : Vegetable
    {
        private const char DefaultRoyalCharValue = 'R';

        private const int DefaultRoyalPowerBonus = 20;

        private const int DefaultRoyalStaminaBonus = 10;

        private const int DefaultRoyalTimeToGrow = 10;

        public Royal(IMatrixPosition position)
            : base(position, DefaultRoyalCharValue, DefaultRoyalPowerBonus, DefaultRoyalStaminaBonus, DefaultRoyalTimeToGrow)
        {
        }
    }
}
