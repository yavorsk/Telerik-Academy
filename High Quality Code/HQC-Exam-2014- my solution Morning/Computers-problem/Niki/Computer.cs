namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    public abstract class Computer
    {
        public Computer(MotherBoard motherBoard, HDD hardDrive)
        {
            this.MotherBoard = motherBoard;
            this.HardDrive = hardDrive;
        }

        public MotherBoard MotherBoard { get; private set; }

        public HDD HardDrive { get; private set; }
    }
}
