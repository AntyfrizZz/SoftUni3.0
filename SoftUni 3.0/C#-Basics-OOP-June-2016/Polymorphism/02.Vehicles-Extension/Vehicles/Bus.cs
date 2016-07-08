using System.Configuration;

namespace VehiclesExtension
{
    using System;

    class Bus : Vehicle
    {
        #region Fields

        private const double ACConsumation = 1.4;

        #endregion Fields

        //===========================

        #region Constructors

        public Bus(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
        {
        }

        #endregion Constructors

        //===========================

        #region Methods

        public void Drive(double distance, bool isEmpty)
        {
            if (!isEmpty)
            {
                if (distance <= this.FuelQuantity / this.FuelConsumptionPerKilometer)
                {
                    Console.WriteLine($"Bus travelled {distance} km");
                    this.FuelQuantity -= distance * this.FuelConsumptionPerKilometer;
                }
                else
                {
                    Console.WriteLine("Bus needs refueling");
                }
            }
            else
            {
                base.Drive(distance, ACConsumation);
            }
        }

        public override void Refuel(double liters)
        {
            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                Console.WriteLine("Cannot fit fuel in tank");
            }
            else
            {
                base.Refuel(liters);
            }
        }

        #endregion Methods
    }
}
