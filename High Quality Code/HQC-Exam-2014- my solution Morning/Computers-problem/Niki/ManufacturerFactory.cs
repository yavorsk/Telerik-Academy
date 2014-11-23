namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    // simple Factory
    public class ManufacturerFactory
    {
        public IComputerManufacturer GetManufacturer(string manufacturerName)
        {
            switch (manufacturerName)
            {
                case "HP": return new HewletComputerManufacturer();
                case "Dell": return new DellComputerManufacturer();
                case "Lenovo": return new LenovoComputerManufacturer();
                default: throw new InvalidArgumentException("Invalid manufacturer!");
            }
        }
    }
}
