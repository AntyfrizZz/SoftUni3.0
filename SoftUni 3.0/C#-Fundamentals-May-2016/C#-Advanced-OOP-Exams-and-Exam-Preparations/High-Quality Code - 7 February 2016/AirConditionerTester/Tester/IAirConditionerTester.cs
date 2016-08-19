namespace AirConditionerTester.Tester
{
    using Models;
    using Models.AirConditioners;

    public interface IAirConditionerTester
    {
        IReport TestAirConditioner(IAirConditioner airConditioner);
    }
}
