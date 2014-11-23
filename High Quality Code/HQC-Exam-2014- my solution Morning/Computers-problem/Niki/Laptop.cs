namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    public class Laptop : Computer
    {
        public Laptop(MotherBoard motherBoard, HDD hardDrive)
            : base(motherBoard, hardDrive)
        {
            this.Battery = new LaptopBattery();
        }

        public LaptopBattery Battery { get; private set; }

        internal void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            this.MotherBoard.DrawOnVideoCard(string.Format("Battery status: {0}%", this.Battery.Percentage));
        }
    }
}
