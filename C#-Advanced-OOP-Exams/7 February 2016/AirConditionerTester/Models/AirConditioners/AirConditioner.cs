// ReSharper disable All
namespace AirConditionerTester.Models.AirConditioners
{
    using System;
    using System.Text;

    public abstract class AirConditioner : IAirConditioner
    {
        private const string IncorrectPropertyLength = "{0}'s name must be at least {1} symbols long.";
        private const int ModelNameMinLength = 2;
        private const int ManufacturerNameMinLength = 4;

        private string manufacturer;
        private string model;

        protected AirConditioner(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                if (value.Length < ManufacturerNameMinLength)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            IncorrectPropertyLength,
                            nameof(this.Manufacturer),
                            ManufacturerNameMinLength));
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (value.Length < ModelNameMinLength)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            IncorrectPropertyLength,
                            nameof(this.Model),
                            ModelNameMinLength));
                }

                this.model = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine("Air Conditioner")
                .AppendLine("====================")
                .AppendLine($"Manufacturer: {this.manufacturer}")
                .AppendLine($"Model: {this.model}");

            return result.ToString().Trim();
        }
    }
}