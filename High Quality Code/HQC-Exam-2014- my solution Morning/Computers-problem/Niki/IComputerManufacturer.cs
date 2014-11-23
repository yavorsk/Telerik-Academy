namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    public interface IComputerManufacturer
    {
        PC MakePC();

        Laptop MakeLaptop();

        Server MakeServer();
    }
}
