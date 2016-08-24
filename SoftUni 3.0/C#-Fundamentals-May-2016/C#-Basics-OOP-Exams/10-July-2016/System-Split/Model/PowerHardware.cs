namespace SystemSplit
{
    public class PowerHardware : Hardware
    {
        #region Fields

        private const double CapacityRatio = 0.75;
        private const double MemoryRatio = 0.75;

        #endregion Fields

        #region Constructors

        public PowerHardware(string name, int maximumCapacity, int maximumMemory)
            : base(
                  name, 
                  maximumCapacity - (int)(maximumCapacity * CapacityRatio), 
                  maximumMemory + (int)(maximumMemory * MemoryRatio))
        {
            base.Type = "Power";
        }

        #endregion Constructors
    }
}