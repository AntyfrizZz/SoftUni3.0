namespace Kermen
{
    public abstract class Couple : Household
    {
        #region Fields

        protected decimal tvElectricityCosts;
        protected decimal fridgeElectricityCosts;

        #endregion Fields

        //===================================================================

        #region Constructors
        protected Couple(
            int numberOfRooms, 
            decimal roomElectricityCost, 
            decimal incomeOne, 
            decimal incomeTwo, 
            decimal tvElectricityCosts,
            decimal fridgeElectricityCosts) 
            : base(numberOfRooms, roomElectricityCost, incomeOne + incomeTwo)
        {
            this.tvElectricityCosts = tvElectricityCosts;
            this.fridgeElectricityCosts = fridgeElectricityCosts;
        }

        #endregion Constructors

        //===================================================================

        #region Methods

        public override decimal Consumption()
        {
            return base.Consumption() + tvElectricityCosts + fridgeElectricityCosts;
        }

        public override int NumberOfPeopleInHH()
        {
            return base.NumberOfPeopleInHH() + 1;
        }

        #endregion Methods
    }
}