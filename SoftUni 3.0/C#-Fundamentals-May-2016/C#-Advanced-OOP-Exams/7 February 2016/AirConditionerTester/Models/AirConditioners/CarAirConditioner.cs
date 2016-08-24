namespace AirConditionerTester.Models.AirConditioners
{
    using System;
    using System.Text;
    using Utilities;

    public class CarAirConditioner : AirConditioner
    {
        private const int MinCarVolume = 1;
        private const string VolumeCoveredVariablePassedToError = "Volume Covered";

        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model, int volumeCovered) 
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value < MinCarVolume)
                {
                    throw new ArgumentException(
                        string.Format(
                            Constants.NonPositive,
                            VolumeCoveredVariablePassedToError));
                }

                this.volumeCovered = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine(base.ToString())
                .AppendLine($"Volume Covered: {this.VolumeCovered}")
                .AppendLine("====================");

            return result.ToString().Trim();
        }
    }
}
