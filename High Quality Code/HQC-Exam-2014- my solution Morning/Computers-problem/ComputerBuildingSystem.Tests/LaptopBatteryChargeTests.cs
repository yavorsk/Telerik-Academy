namespace ComputerBuildingSystem.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ComputersBuildingSystem;

    [TestClass]
    public class LaptopBatteryChargeTests
    {
        private LaptopBattery battery;

        [TestInitialize]
        public void CreateLaptopBattery()
        {
            this.battery = new LaptopBattery();
        }

        [TestMethod]
        public void BatteryInitialChargeShouldBe50()
        {
            int batteryInitialCharge = battery.Percentage;

            Assert.AreEqual(50, batteryInitialCharge);
        }

        [TestMethod]
        public void BatteryShouldChargeWithTheGivenAmaunt()
        {
            battery.Charge(20);
            int batteryCurrentCharge = battery.Percentage;

            Assert.AreEqual(70, batteryCurrentCharge);
        }

        [TestMethod]
        public void BatteryShouldNotChargeAbove100()
        {
            battery.Charge(51);
            int batteryCurrentCharge = battery.Percentage;

            Assert.AreEqual(100, batteryCurrentCharge);
        }

        [TestMethod]
        public void BatteryShouldNotChargeBellow0()
        {
            battery.Charge(-51);
            int batteryCurrentCharge = battery.Percentage;

            Assert.AreEqual(0, batteryCurrentCharge);
        }
    }
}
