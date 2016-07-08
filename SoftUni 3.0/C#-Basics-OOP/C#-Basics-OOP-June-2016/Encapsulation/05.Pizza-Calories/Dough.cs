using System;

namespace _05.Pizza_Calories
{
    public class Dough
    {
        #region Fields

        private string flourType;
        private string bakingTechnique;
        private double weight;

        #endregion Fields

        //===========================

        #region Constructors

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        #endregion Constructors

        //===========================

        #region Properties

        private string FlourType
        {
            get { return this.flourType; }
            set
            {
                if (!value.ToLowerInvariant().Equals("white") &&
                    !value.ToLowerInvariant().Equals("wholegrain"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            get { return this.bakingTechnique; }
            set
            {
                if (!value.ToLowerInvariant().Equals("crispy") &&
                    !value.ToLowerInvariant().Equals("chewy") &&
                    !value.ToLowerInvariant().Equals("homemade"))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        private double GetBakingTechniqueMod()
        {
            switch (this.FlourType.ToLowerInvariant())
            {
                case "white":
                    return 1.5;
                case "wholegrain":
                    return 1.0;
                default:
                    return 1.0;
            }
        }

        private double GetFlourMod()
        {
            switch (this.BakingTechnique.ToLowerInvariant())
            {
                case "crispy":
                    return 0.9;
                case "chewy":
                    return 1.1;
                case "homemade":
                    return 1.0;
                default:
                    return 0.0;
            }
        }

        public double GetTotalCalories()
        {
            double result = (2 * this.weight) * this.GetFlourMod() * this.GetBakingTechniqueMod();
            return result;
        }

        #endregion Methods
    }
}
