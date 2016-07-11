namespace SystemSplit
{
    public class ExpressSoftware : Software
    {
        #region Fields

        private const int memoriRatio = 2;

        #endregion Fields

        //===================================================================

        #region Constructors

        public ExpressSoftware(string hardwareComponentName, string name, int capacityConsumption, int memoryConsumption) 
            : base(
                  hardwareComponentName, 
                  name, 
                  capacityConsumption, 
                  memoriRatio * memoryConsumption)
        {
            base.Type = "Express";
        }

        #endregion Constructors
    }
}