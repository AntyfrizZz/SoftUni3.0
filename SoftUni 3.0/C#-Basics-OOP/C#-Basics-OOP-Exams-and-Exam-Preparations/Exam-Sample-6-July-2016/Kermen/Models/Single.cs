namespace Kermen
{
    public abstract class Single : Household
    {
        protected Single(int numberOfRooms, decimal roomElectricityCost, decimal income) 
            : base(numberOfRooms, roomElectricityCost, income)
        {
        }
    }
}