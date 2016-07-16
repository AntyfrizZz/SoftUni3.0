namespace SystemSplit
{
    public class HeavyHardware : Hardware
    {
        #region Fields

        private const int CapacityRatio = 2;
        private const double MemoriRatio = 0.25;

        #endregion Fields

        #region Constructors

        public HeavyHardware(string name, int maximumCapacity, int maximumMemory) 
            : base(
                  name, 
                  CapacityRatio * maximumCapacity, 
                  maximumMemory - (int)(maximumMemory * MemoriRatio))
        {
            base.Type = "Heavy";
        }

        #endregion Constructors
    }
}