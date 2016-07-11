using System;

namespace SystemSplit
{
    public class LightSoftware : Software
    {
        #region Fields

        private const double capacityRatio = 0.5;
        private const double memoriRatio = 0.5;

        #endregion Fields

        //===================================================================

        #region Constructors

        public LightSoftware(string hardwareComponentName, string name, int capacityConsumption, int memoryConsumption) 
            : base(
                  hardwareComponentName, 
                  name, 
                  capacityConsumption + (int)(capacityConsumption * capacityRatio), 
                  memoryConsumption - (int)(memoryConsumption * memoriRatio))
        {
            base.Type = "Light";
        }

        #endregion Constructors
    }
}