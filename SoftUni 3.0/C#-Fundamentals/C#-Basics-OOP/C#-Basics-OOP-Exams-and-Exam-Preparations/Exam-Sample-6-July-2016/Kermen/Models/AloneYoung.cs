namespace Kermen
{
    public class AloneYoung : Single
    {
        #region Fields

        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 10;

        private decimal laptopElectricityCosts;

        #endregion Fields

        //===================================================================

        #region Constructors

        public AloneYoung(decimal income, decimal laptopElectricityCosts) 
            : base(NumberOfRooms, RoomElectricity, income)
        {
            this.laptopElectricityCosts = laptopElectricityCosts;
        }

        #endregion Constructors

        //===================================================================

        #region Methods

        public override decimal Consumption()
        {
            return base.Consumption() + this.laptopElectricityCosts;
        }

        #endregion Methods
    }
}