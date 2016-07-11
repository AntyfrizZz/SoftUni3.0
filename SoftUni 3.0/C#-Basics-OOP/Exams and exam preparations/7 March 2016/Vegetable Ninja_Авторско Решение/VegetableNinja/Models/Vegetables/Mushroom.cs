namespace VegetableNinja.Models.Vegetables
{
    using VegetableNinja.Interfaces;

    public class Mushroom : Vegetable
    {
        private const char DefaultMushroomCharValue = 'M';

        private const int DefaultMushroomPowerBonus = -10;

        private const int DefaultMushroomStaminaBonus = -10;

        private const int DefaultMushroomTimeToGrow = 5;

        public Mushroom(IMatrixPosition position)
            : base(position, DefaultMushroomCharValue, DefaultMushroomPowerBonus, DefaultMushroomStaminaBonus, DefaultMushroomTimeToGrow)
        {
        }
    }
}
