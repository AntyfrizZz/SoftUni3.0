namespace Kermen
{
    public abstract class Household
    {
        #region Fields

        private int numberOfRooms;
        private decimal roomElectricityCost;
        private decimal moneyInStock;

        protected decimal income;

        #endregion Fields

        //===================================================================

        #region Constructors

        protected Household(int numberOfRooms, decimal roomElectricityCost, decimal income)
        {
            this.numberOfRooms = numberOfRooms;
            this.roomElectricityCost = roomElectricityCost;
            this.income = income;
        }

        #endregion Constructors

        //===================================================================

        #region Methods

        public virtual int NumberOfPeopleInHH()
        {
            return 1;
        }

        public bool PayBills()
        {
            if (Consumption() <= this.moneyInStock)
            {
                this.moneyInStock -= Consumption();
                return true;
            }

            return false;
        }

        public virtual decimal Consumption()
        {
            return numberOfRooms * roomElectricityCost;
        }

        public void GetSalary()
        {
            this.moneyInStock += income;
        }

        #endregion Methods
    }
}