namespace Kermen
{
    using Models;

    public class YoungCoupleWithChildren : YoungCouple
    {
        #region Fields

        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 30;

        private Child[] children;

        #endregion Fields

        //===================================================================

        #region Constructors

        public YoungCoupleWithChildren(
            decimal salariOne,
            decimal salariTwo,
            decimal tvElectricityCosts,
            decimal fridgeElectricityCosts,
            decimal laptopCosts,
            Child[] children)
            : base(NumberOfRooms, RoomElectricity, salariOne, salariTwo, tvElectricityCosts, fridgeElectricityCosts, laptopCosts)
        {
            this.children = children;
        }

        #endregion Constructors

        //===================================================================

        #region Methods

        public override decimal Consumption()
        {
            decimal consumption = base.Consumption();

            foreach (var child in children)
            {
                consumption += child.Consumption();
            }

            return consumption;
        }

        public override int NumberOfPeopleInHH()
        {
            return base.NumberOfPeopleInHH() + children.Length;
        }

        #endregion Methods
    }
}