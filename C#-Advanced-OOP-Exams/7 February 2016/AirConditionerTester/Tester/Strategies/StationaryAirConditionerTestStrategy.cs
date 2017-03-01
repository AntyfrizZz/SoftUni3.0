namespace AirConditionerTester.Tester.Strategies
{
    using Models;
    using Models.AirConditioners;

    public class StationaryAirConditionerTestStrategy : IAirConditionerTestStrategy
    {
        public IReport Test(IAirConditioner airConditioner)
        {
            var testAirConditoner = airConditioner as StationaryAirConditioner;
            var energyEfficiencyRatingValue = string.Empty;

            var powerUsageBound = new int[] { 999, 1250, 1500, 2000, int.MaxValue };
            var energyEfficiencyRating = new string[] { "A", "B", "C", "D", "E" };

            for (int i = 0; i < powerUsageBound.Length; i++)
            {
                if (testAirConditoner.PowerUsage <= powerUsageBound[i])
                {
                    energyEfficiencyRatingValue += energyEfficiencyRating[i];
                    break;
                }
            }

            var mark = energyEfficiencyRatingValue.CompareTo(testAirConditoner.RequiredEnergyEfficiencyRating) < 1
                ? "Passed"
                : "Failed";

            return new Report(testAirConditoner.Manufacturer, testAirConditoner.Model, mark);
        }
    }
}
