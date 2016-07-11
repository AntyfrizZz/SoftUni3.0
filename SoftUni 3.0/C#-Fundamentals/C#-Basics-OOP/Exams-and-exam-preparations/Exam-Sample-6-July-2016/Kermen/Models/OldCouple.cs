namespace Kermen
{
    public class OldCouple : Couple
    {
        #region Fields

        private const int NumberOfRooms = 3;
        private const decimal RoomElectricity = 15;

        private decimal stoveCosts;

        #endregion Fields

        //===================================================================

        #region Constructors

        public OldCouple(
            decimal incomeOne,
            decimal incomeTwo,
            decimal tvElectricityCosts,
            decimal fridgeElectricityCosts,
            decimal stoveCosts)
            : base(NumberOfRooms, RoomElectricity, incomeOne, incomeTwo, tvElectricityCosts, fridgeElectricityCosts)
        {
            this.stoveCosts = stoveCosts;
        }

        #endregion Constructors

        //===================================================================

        #region Methods

        public override decimal Consumption()
        {
            return base.Consumption() + stoveCosts;
        }

        #endregion Methods
    }
}