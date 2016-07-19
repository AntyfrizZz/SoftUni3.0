namespace SystemSplit
{
    public class LightSoftware : Software
    {
        #region Fields

        private const double CapacityRatio = 0.5;
        private const double MemoriRatio = 0.5;

        #endregion Fields

        #region Constructors

        public LightSoftware(string hardwareComponentName, string name, int capacityConsumption, int memoryConsumption) 
            : base(
                  hardwareComponentName, 
                  name, 
                  capacityConsumption + (int)(capacityConsumption * CapacityRatio), 
                  memoryConsumption - (int)(memoryConsumption * MemoriRatio))
        {
            base.Type = "Light";
        }

        #endregion Constructors
    }
}