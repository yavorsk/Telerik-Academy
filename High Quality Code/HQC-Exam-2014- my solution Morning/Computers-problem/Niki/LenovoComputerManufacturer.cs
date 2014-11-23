namespace ComputersBuildingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LenovoComputerManufacturer : IComputerManufacturer
    {
        public PC MakePC()
        {
            RAMMemory lenovoPcRam = new RAMMemory(4);
            Cpu lenovoPCCpu = new Cpu(2, 64);
            IVideoCard lenovoPCVideoCard = new ColorfullVideoCard();

            MotherBoard lenovoMotherBoard = new MotherBoard(lenovoPcRam, lenovoPCVideoCard, lenovoPCCpu);

            HDD lenovoPcHdd = new HDD(2000, false, 0);
            PC lenovoPC = new PC(lenovoMotherBoard, lenovoPcHdd);

            return lenovoPC;
        }

        public Laptop MakeLaptop()
        {
            RAMMemory lenovoLaptopRam = new RAMMemory(16);
            Cpu lenovoLaptopCpu = new Cpu(2, 64);
            IVideoCard lenovoLaptopVideoCard = new ColorfullVideoCard();

            MotherBoard lenovoLaptopMotherBoard = new MotherBoard(lenovoLaptopRam, lenovoLaptopVideoCard, lenovoLaptopCpu);

            HDD lenovoLaptopHdd = new HDD(1000, false, 0);

            Laptop lenovoLaptop = new Laptop(lenovoLaptopMotherBoard, lenovoLaptopHdd);

            return lenovoLaptop;
        }

        public Server MakeServer()
        {
            RAMMemory lenovoServerRam = new RAMMemory(8);
            Cpu lenovoServerCpu = new Cpu(2, 128);
            IVideoCard lenovoServerVideoCard = new MonochromeVideoCard();

            MotherBoard lenovoServerMotherBoard = new MotherBoard(lenovoServerRam, lenovoServerVideoCard, lenovoServerCpu);

            HDD lenovoServerHdd = new HDD(500, true, 2, new List<HDD>() { new HDD(500, false, 0), new HDD(500, false, 0) });

            Server lenovoServer = new Server(lenovoServerMotherBoard, lenovoServerHdd);

            return lenovoServer;
        }
    }
}