namespace AirConditionerTester.Database
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Exceptions;
    using Models;
    using Models.AirConditioners;

    public class Database : IDatabase
    {
        private const string NoReports = "No reports.";
        private const string StatusOutput = "Jobs complete: {0:F2}%";

        private readonly IDictionary<string, IAirConditioner> airConditioners;
        private IDictionary<string, IReport> reportsByManufacturerModel;
        private IDictionary<string, List<IReport>> reportsByManufacturer;

        public Database(Dictionary<string, IAirConditioner> airConditioners, Dictionary<string, IReport> reportsByManufacturerModel, Dictionary<string, List<IReport>> reportsByManufacturer)
        {
            this.airConditioners = airConditioners;
            this.reportsByManufacturerModel = reportsByManufacturerModel;
            this.reportsByManufacturer = reportsByManufacturer;
        }

        public Database()
            : this(new Dictionary<string, IAirConditioner>(), new Dictionary<string, IReport>(), new Dictionary<string, List<IReport>>())
        {
        }

        public void AddAirConditioner(IAirConditioner airConditioner)
        {
            var manufacturer = airConditioner.Manufacturer;
            var model = airConditioner.Model;

            if (this.CheckAirConditioner(manufacturer, model))
            {
                throw new DuplicateEntryException();
            }

            var key = manufacturer + "," + model;

            this.airConditioners.Add(key, airConditioner);
        }

        public void AddReport(IReport report)
        {
            var manufacturer = report.Manufacturer;
            var model = report.Model;

            if (this.CheckReport(manufacturer, model))
            {
                throw new DuplicateEntryException();
            }

            if (!this.reportsByManufacturer.ContainsKey(manufacturer))
            {
                this.reportsByManufacturer.Add(manufacturer, new List<IReport>());
            }

            this.reportsByManufacturer[manufacturer].Add(report);
            this.reportsByManufacturerModel.Add(manufacturer + "," + model, report);
        }

        public IAirConditioner GetAirConditioner(string manufacturer, string model)
        {
            if (!this.CheckAirConditioner(manufacturer, model))
            {
                throw new NonExistantEntryException();
            }

            var key = manufacturer + "," + model;
            return this.airConditioners[key];
        }

        public IReport GetReport(string manufacturer, string model)
        {
            if (!this.CheckReport(manufacturer, model))
            {
                throw new NonExistantEntryException();
            }

            var key = manufacturer + "," + model;
            return this.reportsByManufacturerModel[key];
        }

        public bool CheckAirConditioner(string manufacturer, string model)
        {
            var key = manufacturer + "," + model;

            return this.airConditioners.ContainsKey(key);
        }

        public bool CheckReport(string manufacturer, string model)
        {
            var fullName = manufacturer + "," + model;

            return this.reportsByManufacturerModel.ContainsKey(fullName);
        }

        public string GetReportsByManufacturer(string manufacturer)
        {
            if (!this.reportsByManufacturer.ContainsKey(manufacturer))
            {
                return NoReports;
            }

            var result = new StringBuilder();

            var sorted = this.reportsByManufacturer[manufacturer].OrderBy(m => m.Model);

            result.AppendLine($"Reports from {manufacturer}:");
            foreach (var report in sorted)
            {
                result.AppendLine(report.ToString());
            }

            return result.ToString().Trim();
        }
        
        public string Status()
        {
            double airConditionersCount = this.airConditioners.Count;
            double reportsCount = this.reportsByManufacturerModel.Count;

            if (airConditionersCount == 0 || reportsCount == 0)
            {
                return string.Format(StatusOutput, "0.00");
            }

            double percent = reportsCount / airConditionersCount;
            percent = percent * 100;

            return string.Format(StatusOutput, percent);
        }
    }
}
