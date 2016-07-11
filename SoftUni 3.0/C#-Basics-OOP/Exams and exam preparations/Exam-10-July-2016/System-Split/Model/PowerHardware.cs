using System;

namespace SystemSplit
{
    public class PowerHardware : Hardware
    {
        #region Fields

        private const double capacityRatio = 0.75;
        private const double memoryRatio = 0.75;

        #endregion Fields

        //===================================================================

        #region Constructors

        public PowerHardware(string name, int maximumCapacity, int maximumMemory)
            : base(
                  name, 
                  maximumCapacity - (int)(maximumCapacity * capacityRatio), 
                  maximumMemory + (int)(maximumMemory * memoryRatio))
        {
            base.Type = "Power";
        }

        #endregion Constructors
    }
}