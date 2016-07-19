namespace SystemSplit
{
    public class ExpressSoftware : Software
    {
        #region Fields

        private const int MemoriRatio = 2;

        #endregion Fields

        #region Constructors

        public ExpressSoftware(string hardwareComponentName, string name, int capacityConsumption, int memoryConsumption) 
            : base(
                  hardwareComponentName, 
                  name, 
                  capacityConsumption, 
                  MemoriRatio * memoryConsumption)
        {
            base.Type = "Express";
        }

        #endregion Constructors
    }
}