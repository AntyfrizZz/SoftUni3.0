namespace AirConditionerTester.IO.Commands
{
    using System;
    using Database;
    using Models.AirConditioners;
    using Utilities;

    public class RegisterPlaneAirConditionerCommand : Command
    {
        private const int ExpectedArgumentsCount = 4;

        public RegisterPlaneAirConditionerCommand(string[] arguments, IDatabase database) 
            : base(arguments, database, ExpectedArgumentsCount)
        {
        }

        public override string Execute()
        {
            var manufacturer = this.Arguments[0];
            var model = this.Arguments[1];

            int volumeCovered;
            bool correctVolumeCoveredFormat = int.TryParse(this.Arguments[2], out volumeCovered);

            if (!correctVolumeCoveredFormat)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }

            int electricityUsed;
            bool correcElectricityUsedFormat = int.TryParse(this.Arguments[3], out electricityUsed);

            if (!correcElectricityUsedFormat)
            {
                throw new InvalidOperationException(Constants.InvalidCommand);
            }

            IAirConditioner airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCovered, electricityUsed);
            this.Database.AddAirConditioner(airConditioner);

            return string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer);
        }
    }
}
