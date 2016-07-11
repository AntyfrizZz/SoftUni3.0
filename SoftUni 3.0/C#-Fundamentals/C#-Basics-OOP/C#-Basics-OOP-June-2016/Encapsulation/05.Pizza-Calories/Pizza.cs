using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Pizza_Calories
{
    public class Pizza
    {
        #region Fields

        private string name;
        private int numberOfToppings;
        private List<Topping> topping;
        private Dough dough;

        #endregion Fields

        //===========================

        #region Constructors

        public Pizza(string name, int numberOfToppings)
        {
            this.Name = name;
            this.NumberOfToppings = numberOfToppings;

            this.topping = new List<Topping>();
        }
        #endregion Constructors

        //===========================

        #region Properties

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Dough cannot be null.");
                }

                this.dough = value;
            }
        }

        public int NumberOfToppings
        {
            get { return this.numberOfToppings; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                this.numberOfToppings = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        public void AddTopping(Topping topping)
        {
            this.topping.Add(topping);
        }

        public double TotalCalories()
        {
            var totalCalories = 0.0;

            foreach (var top in topping)
            {
                totalCalories += top.GetTotalCalories();
            }

            totalCalories += this.Dough.GetTotalCalories();

            return totalCalories;
        }

        #endregion Methods
    }
}
