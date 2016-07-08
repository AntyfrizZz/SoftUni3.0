namespace VehiclesExtension
{
    using System;

    public class Car : Vehicle
    {
        #region Fields

        private const double ACConsumation = 0.9;

        #endregion Fields

        //===========================

        #region Constructors

        public Car(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKilometer, tankCapacity)
        {
        }

        #endregion Constructors

        //===========================

        #region Methods

        public void Drive(double distance)
        {
            base.Drive(distance, ACConsumation);
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