namespace AirConditionerTester.Tester.Strategies
{
    using Models;
    using Models.AirConditioners;

    public interface IAirConditionerTestStrategy
    {
        IReport Test(IAirConditioner airConditioner);
    }
}
