namespace AirConditionerTester.Models.AirConditioners
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Utilities;

    public class StationaryAirConditioner : AirConditioner
    {
        private const string IncorrectRating = "Energy efficiency rating must be between \"{0}\" and \"{1}\".";
        private const int MinPowerUsage = 1;
        private const string PowerUsageVariablePassedToError = "Power Usage";
        private static readonly List<string> EnergyEfficiencyRating = new List<string>() { "A", "B", "C", "D", "E" };

        private int powerUsage;
        private string requiredEnergyEfficiencyRating;

        public StationaryAirConditioner(string manufacturer, string model, string requiredEnergyEfficiencyRating, int powerUsage)
            : base(manufacturer, model)
        {
            this.PowerUsage = powerUsage;
            this.RequiredEnergyEfficiencyRating = requiredEnergyEfficiencyRating;
        }

        public string RequiredEnergyEfficiencyRating
        {
            get
            {
                return this.requiredEnergyEfficiencyRating;
            }

            set
            {
                if (!EnergyEfficiencyRating.Contains(value))
                {
                    throw new ArgumentException(
                        string.Format(
                            IncorrectRating,
                            EnergyEfficiencyRating[0],
                            EnergyEfficiencyRating[EnergyEfficiencyRating.Count - 1]));
                }

                this.requiredEnergyEfficiencyRating = value;
            }
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            set
            {
                if (value < MinPowerUsage)
                {
                    throw new ArgumentException(
                        string.Format(
                            Constants.NonPositive,
                            PowerUsageVariablePassedToError));
                }

                this.powerUsage = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine(base.ToString())
                .AppendLine($"Required energy efficiency rating: {this.RequiredEnergyEfficiencyRating}")
                .AppendLine($"Power Usage(KW / h): {this.PowerUsage}")
                .AppendLine("====================");

            return result.ToString().Trim();
        }
    }
}
