namespace Vehicles
{
    using System;

    public abstract class Vehicle
    {
        #region Constructors

        public Vehicle(double fuelQuantity, double fuelConsumation)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumation = fuelConsumation;
        }

        #endregion Constructors

        //===========================

        #region Properties

        public double FuelQuantity { get; protected set; }

        public virtual double FuelConsumation { get; protected set; }

        #endregion Properties

        //===========================

        #region Methods

        public virtual void Drive(double distance, double ACConsum)
        {
            if (distance <= this.FuelQuantity / (this.FuelConsumation + ACConsum))
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                this.FuelQuantity -= distance * (this.FuelConsumation + ACConsum);
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refueled(double liters)
        {
            this.FuelQuantity += liters;
        }

        #endregion Methods
    }
}
