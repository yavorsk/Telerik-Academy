namespace ComputersBuildingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HewletComputerManufacturer : IComputerManufacturer
    {
        public PC MakePC()
        {
            RAMMemory hewletPcRam = new RAMMemory(2);
            Cpu hewletPCCpu = new Cpu(2, 32);
            IVideoCard hewletPCVideoCard = new ColorfullVideoCard();

            MotherBoard hewletMotherBoard = new MotherBoard(hewletPcRam, hewletPCVideoCard, hewletPCCpu);

            HDD hewletPcHdd = new HDD(500, false, 0);
            PC hewletPC = new PC(hewletMotherBoard, hewletPcHdd);

            return hewletPC;
        }

        public Laptop MakeLaptop()
        {
            RAMMemory hewletLaptopRam = new RAMMemory(4);
            Cpu hewletLaptopCpu = new Cpu(2, 64);
            IVideoCard hewletLaptopVideoCard = new ColorfullVideoCard();

            MotherBoard hewletLaptopMotherBoard = new MotherBoard(hewletLaptopRam, hewletLaptopVideoCard, hewletLaptopCpu);

            HDD hewletLaptopHdd = new HDD(500, false, 0);

            Laptop hewletLaptop = new Laptop(hewletLaptopMotherBoard, hewletLaptopHdd);

            return hewletLaptop;
        }

        public Server MakeServer()
        {
            RAMMemory hewletServerRam = new RAMMemory(32);
            Cpu hewletServerCpu = new Cpu(4, 32);
            IVideoCard hewletServerVideoCard = new MonochromeVideoCard();

            MotherBoard hewletServerMotherBoard = new MotherBoard(hewletServerRam, hewletServerVideoCard, hewletServerCpu);

            HDD hewletServerHdd = new HDD(1000, true, 2, new List<HDD>() { new HDD(1000, false, 0), new HDD(1000, false, 0) });

            Server hewletServer = new Server(hewletServerMotherBoard, hewletServerHdd);

            return hewletServer;
        }
    }
}