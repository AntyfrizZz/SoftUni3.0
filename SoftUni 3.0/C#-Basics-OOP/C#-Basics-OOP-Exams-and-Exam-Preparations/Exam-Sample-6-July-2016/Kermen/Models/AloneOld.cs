namespace Kermen
{
    public class AloneOld : Single
    {
        #region Fields

        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 15;

        #endregion Fields

        //===================================================================

        #region Constructors

        public AloneOld(decimal income) 
            : base(NumberOfRooms, RoomElectricity, income)
        {
        }

        #endregion Constructors
    }
}