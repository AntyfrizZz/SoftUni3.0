namespace VegetableNinja.Models.Vegetables
{
    using VegetableNinja.Interfaces;

    public class CherryBerry : Vegetable
    {
        private const char DefaultCherryBerryCharValue = 'C';

        private const int DefaultCherryBerryPowerBonus = 0;

        private const int DefaultCherryBerryStaminaBonus = 10;

        private const int DefaultCherryBerryTimeToGrow = 5;

        public CherryBerry(IMatrixPosition position)
            : base(position, DefaultCherryBerryCharValue, DefaultCherryBerryPowerBonus, DefaultCherryBerryStaminaBonus, DefaultCherryBerryTimeToGrow)
        {
        }
    }
}
