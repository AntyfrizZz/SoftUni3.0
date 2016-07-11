namespace VegetableNinja.Models
{
    using VegetableNinja.Enumerations;
    using VegetableNinja.Interfaces;

    public class BlankSpace : GameObject, IBlankSpace
    {
        private const char DefaultBlankSpaceCharValue = '-';

        private int growthTime;

        private VegetableType vegetableHolder;

        public BlankSpace(IMatrixPosition position, int growthTime, VegetableType vegetableType)
            : base(position, DefaultBlankSpaceCharValue)
        {
            this.GrowthTime = growthTime;
            this.VegetableHolder = vegetableType;
        }

        public int GrowthTime
        {
            get
            {
                return this.growthTime;
            }

            private set
            {
                this.growthTime = value;
            }
        }

        public VegetableType VegetableHolder
        {
            get
            {
                return this.vegetableHolder;
            }

            private set
            {
                this.vegetableHolder = value;
            }
        }

        public void Grow()
        {
            if (this.GrowthTime != -1)
            {
                this.GrowthTime--;
            }
        }
    }
}
