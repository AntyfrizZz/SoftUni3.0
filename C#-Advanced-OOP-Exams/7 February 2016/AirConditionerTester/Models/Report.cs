namespace AirConditionerTester.Models
{
    using System.Text;

    public class Report : IReport
    {
        private string mark;

        public Report(string manufacturer, string model, string mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.mark = mark;
        }

        public string Manufacturer { get; }

        public string Model { get; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine("Report")
                .AppendLine("====================")
                .AppendLine($"Manufacturer: {this.Manufacturer}")
                .AppendLine($"Model: {this.Model}")
                .AppendLine($"Mark: {this.mark}")
                .AppendLine("====================");

            return result.ToString().Trim();
        }
    }
}
