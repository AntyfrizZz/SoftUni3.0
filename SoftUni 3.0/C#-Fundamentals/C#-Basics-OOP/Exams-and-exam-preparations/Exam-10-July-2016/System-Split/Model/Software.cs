namespace SystemSplit
{
    public abstract class Software : Component
    {
        #region Constructors

        protected Software(string hardwareComponentName, string name, int capacityConsumption, int memoryConsumption)
            : base(name)
        {
            this.HardwareComponentName = hardwareComponentName;
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }

        #endregion Constructors

        //===================================================================

        #region Properties

        public string HardwareComponentName { get; }
        public int CapacityConsumption { get; }
        public int MemoryConsumption { get; }

        #endregion Properties
    }
}