using System;

namespace _05.Pizza_Calories
{
    public class Topping
    {
        #region Fields

        private string type;
        private double weight;

        #endregion Fields

        //===========================

        #region Constructors

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        #endregion Constructors

        //===========================

        #region Properties

        private string Type
        {
            get { return this.type; }
            set
            {
                if (!value.ToLowerInvariant().Equals("meat")
                    && !value.ToLowerInvariant().Equals("veggies")
                    && !value.ToLowerInvariant().Equals("cheese")
                    && !value.ToLowerInvariant().Equals("sauce"))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        private double GetTypeMod()
        {
            switch (this.Type.ToLowerInvariant())
            {
                case "meat":
                    return 1.2;
                case "veggies":
                    return 0.8;
                case "cheese":
                    return 1.1;
                case "sauce":
                    return 0.9;
                default:
                    return 0.0;
            }
        }

        public double GetTotalCalories()
        {
            return (2 * this.Weight) * this.GetTypeMod();
        }

        #endregion Methods
    }
}
