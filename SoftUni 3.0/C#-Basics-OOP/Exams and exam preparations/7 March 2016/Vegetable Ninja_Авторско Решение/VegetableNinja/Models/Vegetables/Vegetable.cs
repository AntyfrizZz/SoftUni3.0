namespace VegetableNinja.Models.Vegetables
{
    using VegetableNinja.Interfaces;

    public class Vegetable : GameObject, IVegetable
    {
        private int powerBonus;

        private int staminaBonus;

        private int timeToGrow;

        protected Vegetable(IMatrixPosition position, char charValue, int powerBonus, int staminaBonus, int timeToGrow)
            : base(position, charValue)
        {
            this.PowerBonus = powerBonus;
            this.StaminaBonus = staminaBonus;
            this.TimeToGrow = timeToGrow;
        }

        public int PowerBonus
        {
            get
            {
                return this.powerBonus;
            }

            protected set
            {
                this.powerBonus = value;
            }
        }

        public int StaminaBonus
        {
            get
            {
                return this.staminaBonus;
            }

            protected set
            {
                this.staminaBonus = value;
            }
        }

        public int TimeToGrow
        {
            get
            {
                return this.timeToGrow;
            }

            protected set
            {
                this.timeToGrow = value;
            }
        }
    }
}
