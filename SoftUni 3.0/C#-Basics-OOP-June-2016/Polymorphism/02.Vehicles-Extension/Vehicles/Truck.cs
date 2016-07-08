namespace VehiclesExtension
{
    using System;

    public class Truck : Vehicle
    {
        #region Fields

        private const double ACConsumation = 1.6;

        #endregion Fields

        //===========================

        #region Constructors

        public Truck(double fuelQuantity, double fuelConsumptionPerKilometer, double tankCapacity)
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
            base.Refuel(liters * 0.95);
        }

        #endregion Methods
    }
}