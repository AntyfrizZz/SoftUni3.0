namespace AirConditionerTester.Tester.Strategies
{
    using System;
    using Models;
    using Models.AirConditioners;

    public class CarAirConditionerTestStrategy : IAirConditionerTestStrategy
    {
        private const int MinVolumeCovered = 3;

        public IReport Test(IAirConditioner airConditioner)
        {
            var testAirConditioner = airConditioner as CarAirConditioner;
            var volumeCoveredSqrt = Math.Sqrt(testAirConditioner.VolumeCovered);
            var mark = volumeCoveredSqrt < MinVolumeCovered ? "Failed" : "Passed";

            return new Report(testAirConditioner.Manufacturer, testAirConditioner.Model, mark);
        }
    }
}
