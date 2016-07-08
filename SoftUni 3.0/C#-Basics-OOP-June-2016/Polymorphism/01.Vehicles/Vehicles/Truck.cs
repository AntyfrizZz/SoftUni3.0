namespace Vehicles
{
    public class Truck : Vehicle
    {
        #region Constructors

        private const double ACConsumation = 1.6;

        public Truck(double fuelQuantity, double fuelConsumation) : base(fuelQuantity, fuelConsumation)
        {
        }

        #endregion Constructors

        //===========================

        #region Methods

        public void Drive(double distance)
        {
            base.Drive(distance, ACConsumation);
        }

        public override void Refueled(double liters)
        {
            base.FuelQuantity += 0.95*liters;
        }

        #endregion Methods
    }
}
