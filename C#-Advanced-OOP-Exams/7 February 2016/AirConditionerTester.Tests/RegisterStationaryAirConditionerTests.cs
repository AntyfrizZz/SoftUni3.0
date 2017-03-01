namespace AirConditionerTester.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models.AirConditioners;

    [TestClass]
    public class RegisterStationaryAirConditionerTests
    {
        private const int ManufacturerNameMinLength = 4;
        private string validMinLenghtManufacturer = new string('a', ManufacturerNameMinLength);
        private string invalidMinLengthManufacturer = new string('a', ManufacturerNameMinLength - 1);

        private const int ModelNameMinLength = 2;
        private string validMinLenghtModel = new string('m', ModelNameMinLength);
        private string invalidMinLenghtModel = new string('m', ModelNameMinLength - 1);

        private const int MinPowerUsage = 1;
        private int validPowerUsage = MinPowerUsage;
        private int invalidPowerUsage = MinPowerUsage - 1;

        // private static readonly List<string> EnergyEfficiencyRating = new List<string>() { "A", "B", "C", "D", "E" };
        private string validRequiredEnergyEfficiencyRating = "A";
        private string invalidRequiredEnergyEfficiencyRating = "F";

        [TestMethod]
        public void RegisterStationaryAirConditioner_AllValid_ShoudCreateStationaryAirConditioner()
        {

            var airConditioner = new StationaryAirConditioner(this.validMinLenghtManufacturer, this.validMinLenghtModel, this.validRequiredEnergyEfficiencyRating, this.validPowerUsage);

            Assert.AreEqual(this.validMinLenghtManufacturer, airConditioner.Manufacturer, "Manufacturer didn't set properly");
            Assert.AreEqual(this.validMinLenghtModel, airConditioner.Model, "Model didn't set properly");
            Assert.AreEqual(this.validRequiredEnergyEfficiencyRating, airConditioner.RequiredEnergyEfficiencyRating, "Required Energy Efficiency Rating didn't set properly");
            Assert.AreEqual(this.validPowerUsage, airConditioner.PowerUsage, "Power didn't set properly");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Manufacturer's name must be at least {1} symbols long.")]
        public void RegisterStationaryAirConditioner_InvalidManufacturer_ShoudFail()
        {
            var airConditioner = new StationaryAirConditioner(this.invalidMinLengthManufacturer, this.validMinLenghtModel, this.validRequiredEnergyEfficiencyRating, this.validPowerUsage);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Model's name must be at least {1} symbols long.")]
        public void RegisterStationaryAirConditioner_InvalidModel_ShoudFail()
        {
            var airConditioner = new StationaryAirConditioner(this.validMinLenghtManufacturer, this.invalidMinLenghtModel, this.validRequiredEnergyEfficiencyRating, this.validPowerUsage);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Energy efficiency rating must be between \"A\" and \"E\".")]
        public void RegisterStationaryAirConditioner_InvalidREER_ShoudFail()
        {
            var airConditioner = new StationaryAirConditioner(this.validMinLenghtManufacturer, this.validMinLenghtModel, this.invalidRequiredEnergyEfficiencyRating, this.validPowerUsage);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Power must be a positive integer.")]
        public void RegisterStationaryAirConditioner_InvalidPower_ShoudFail()
        {
            var airConditioner = new StationaryAirConditioner(this.validMinLenghtManufacturer, this.validMinLenghtModel, this.validRequiredEnergyEfficiencyRating, this.invalidPowerUsage);
        }
    }
}
