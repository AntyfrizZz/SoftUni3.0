namespace AirConditionerTester.IO.Commands
{
    using System;
    using Database;
    using Models.AirConditioners;
    using Utilities;

    public class RegisterStationaryAirConditionerCommand : Command
    {
        private const int ExpectedArgumentsCount = 4;

        public RegisterStationaryAirConditionerCommand(string[] arguments, IDatabase database) 
            : base(arguments, database, ExpectedArgumentsCount)
        {
        }

        public override string Execute()
        {
            var manufacturer = this.Arguments[0];
            var model = this.Arguments[1];
            var energyEfficiencyRating = this.Arguments[2];
            int powerUsage;
            bool correctPowerUsageFormat = int.TryParse(this.Arguments[3], out powerUsage);

            if (!correctPowerUsageFormat)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }
            
            IAirConditioner airConditioner = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            this.Database.AddAirConditioner(airConditioner);

            return string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer);
        }
    }
}
