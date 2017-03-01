namespace AirConditionerTester.IO.Commands
{
    using System;
    using Database;
    using Models.AirConditioners;
    using Utilities;

    public class RegisterCarAirConditionerCommand : Command
    {
        private const int ExpectedArgumentsCount = 3;

        public RegisterCarAirConditionerCommand(string[] arguments, IDatabase database)
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

            IAirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCovered);
            this.Database.AddAirConditioner(airConditioner);

            return string.Format(Constants.Register, airConditioner.Model, airConditioner.Manufacturer);
        }
    }
}
