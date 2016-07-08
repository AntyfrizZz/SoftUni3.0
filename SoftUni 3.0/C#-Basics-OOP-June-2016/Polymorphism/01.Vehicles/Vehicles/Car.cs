namespace Vehicles
{
    public class Car : Vehicle
    {
        #region Constructors

        private const double ACConsumation = 0.9;

        public Car(double fuelQuantity, double fuelConsumation)
            : base(fuelQuantity, fuelConsumation)
        {
        }

        #endregion Constructors

        //===========================

        #region Methods

        public void Drive(double distance)
        {
            base.Drive(distance, ACConsumation);
        }

        #endregion Methods
    }
}
