using System;

namespace SystemSplit
{
    public class HeavyHardware : Hardware
    {
        #region Fields

        private const int capacityRatio = 2;
        private const double memoriRatio = 0.25;

        #endregion Fields

        //===================================================================

        #region Constructors

        public HeavyHardware(string name, int maximumCapacity, int maximumMemory) 
            : base(
                  name, 
                  capacityRatio * maximumCapacity, 
                  maximumMemory - (int)(maximumMemory * memoriRatio))
        {
            base.Type = "Heavy";
        }

        #endregion Constructors
    }
}