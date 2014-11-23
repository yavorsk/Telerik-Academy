namespace ComputersBuildingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DellComputerManufacturer : IComputerManufacturer
    {
        public PC MakePC()
        {
            RAMMemory dellPcRam = new RAMMemory(8);
            Cpu dellPCCpu = new Cpu(4, 64);
            IVideoCard dellPCVideoCard = new ColorfullVideoCard();

            MotherBoard dellMotherBoard = new MotherBoard(dellPcRam, dellPCVideoCard, dellPCCpu);

            HDD dellPcHdd = new HDD(1000, false, 0);
            PC dellPC = new PC(dellMotherBoard, dellPcHdd);

            return dellPC;
        }

        public Laptop MakeLaptop()
        {
            RAMMemory dellLaptopRam = new RAMMemory(8);
            Cpu dellLaptopCpu = new Cpu(4, 32);
            IVideoCard dellLaptopVideoCard = new ColorfullVideoCard();

            MotherBoard dellLaptopMotherBoard = new MotherBoard(dellLaptopRam, dellLaptopVideoCard, dellLaptopCpu);

            HDD dellLaptopHdd = new HDD(1000, false, 0);

            Laptop dellLaptop = new Laptop(dellLaptopMotherBoard, dellLaptopHdd);

            return dellLaptop;
        }

        public Server MakeServer()
        {
            RAMMemory dellServerRam = new RAMMemory(64);
            Cpu dellServerCpu = new Cpu(8, 64);
            IVideoCard dellServerVideoCard = new MonochromeVideoCard();

            MotherBoard dellServerMotherBoard = new MotherBoard(dellServerRam, dellServerVideoCard, dellServerCpu);

            HDD dellServerHdd = new HDD(2000, true, 2, new List<HDD>() { new HDD(2000, false, 0), new HDD(2000, false, 0) });

            Server dellServer = new Server(dellServerMotherBoard, dellServerHdd);

            return dellServer;
        }
    }
}
