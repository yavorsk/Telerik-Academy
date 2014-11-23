namespace ComputersBuildingSystem
{
    public class LaptopBattery
    {
        private const int InitialBatteryCharge = 50;

        public LaptopBattery()
        {
            this.Percentage = InitialBatteryCharge;
        }

        public int Percentage { get; private set; }

        public void Charge(int amountOfCharge)
        {
            this.Percentage += amountOfCharge;
            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}
