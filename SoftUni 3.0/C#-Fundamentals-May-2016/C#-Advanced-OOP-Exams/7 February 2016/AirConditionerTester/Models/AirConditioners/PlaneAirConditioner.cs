namespace AirConditionerTester.Models.AirConditioners
{
    using System;
    using System.Text;
    using Utilities;

    public class PlaneAirConditioner : AirConditioner
    {
        private const int MinPlaneElectricity = 1;
        private const string VolumeCoveredVariablePassedToError = "Volume Covered";
        private const string ElectricityUsedVariablePassedToError = "Electricity Used";

        private int volumeCovered;
        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCovered, int electricityUsed) 
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
            this.ElectricityUsed = electricityUsed;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value < MinPlaneElectricity)
                {
                    throw new ArgumentException(
                        string.Format(
                            Constants.NonPositive,
                            VolumeCoveredVariablePassedToError));
                }

                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value < MinPlaneElectricity)
                {
                    throw new ArgumentException(
                        string.Format(
                            Constants.NonPositive,
                            ElectricityUsedVariablePassedToError));
                }

                this.electricityUsed = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine(base.ToString())
                .AppendLine($"Volume Covered: {this.VolumeCovered}")
                .AppendLine($"Electricity Used: {this.ElectricityUsed}")
                .AppendLine("====================");

            return result.ToString().Trim();
        }
    }
}
