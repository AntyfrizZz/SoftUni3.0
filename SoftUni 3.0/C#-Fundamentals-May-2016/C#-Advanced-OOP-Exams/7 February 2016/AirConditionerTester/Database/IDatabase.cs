namespace AirConditionerTester.Database
{
    using Models;
    using Models.AirConditioners;

    public interface IDatabase
    {
        void AddAirConditioner(IAirConditioner airConditioner);

        IAirConditioner GetAirConditioner(string manufacturer, string model);

        IReport GetReport(string manufacturer, string model);

        string GetReportsByManufacturer(string manufacturer);

        bool CheckAirConditioner(string manufacturer, string model);

        bool CheckReport(string manufacturer, string model);

        void AddReport(IReport report);

        string Status();
    }
}
