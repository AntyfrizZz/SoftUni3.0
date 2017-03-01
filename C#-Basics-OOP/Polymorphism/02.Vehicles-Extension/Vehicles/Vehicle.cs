using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        #region Fields

        private double fuelQuantity;

        #endregion Fields

        //===========================

        #region Constructors

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TankCapacity = tankCapacity;
        }

        #endregion Constructors

        //===========================

        #region Properties
        public virtual double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                this.fuelQuantity = value;
            }
        }

        public double FuelConsumptionPerKilometer { get; private set; }
        public double TankCapacity { get; private set; }

        #endregion Properties

        //===========================

        #region Methods

        public virtual void Drive(double distance, double ACConsum)
        {
            if (distance <= this.FuelQuantity / (this.FuelConsumptionPerKilometer + ACConsum))
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                this.FuelQuantity -= distance * (this.FuelConsumptionPerKilometer + ACConsum);
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (this.FuelQuantity + liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }

        #endregion Methods
    }
}
