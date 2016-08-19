namespace AirConditionerTester.Tester.Strategies
{
    using System;
    using Models;
    using Models.AirConditioners;

    public class PlaneAirConditionerTestStrategy : IAirConditionerTestStrategy
    {
        private const int MinVolumeCovered = 150;

        public IReport Test(IAirConditioner airConditioner)
        {
            var testAirConditioner = airConditioner as PlaneAirConditioner;
            var volumeCoveredSqrt = Math.Sqrt(testAirConditioner.VolumeCovered);
            var mark = testAirConditioner.ElectricityUsed / volumeCoveredSqrt < MinVolumeCovered ? "Passed" : "Failed";

            return new Report(testAirConditioner.Manufacturer, testAirConditioner.Model, mark);
        }
    }
}
