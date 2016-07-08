namespace WildFarm.Foods
{
    public abstract class Food
    {
        #region Constructors

        public Food(int quantity)
        {
            Quantity = quantity;
        }

        #endregion Constructors

        //===========================

        #region Properties

        public int Quantity { get; private set; }

        #endregion Properties
    }
}
