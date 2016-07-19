namespace Kermen.Models
{
    public class Child
    {
        #region Fields

        private decimal[] consumptions;

        #endregion Fields

        //===================================================================

        #region Constructors

        public Child(decimal[] consumptions)
        {
            this.consumptions = consumptions;
        }

        #endregion Constructors

        //===================================================================

        #region Methods

        public decimal Consumption()
        {
            decimal consumptionSum = 0;

            foreach (var consumption in consumptions)
            {
                consumptionSum += consumption;
            }

            return consumptionSum;
        }

        #endregion Methods
    }
}
