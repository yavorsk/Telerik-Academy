namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    public class Server : Computer
    {
        public Server(MotherBoard motherBoard, HDD hardDrive)
            : base(motherBoard, hardDrive)
        {
        }

        internal void Process(int data)
        {
            string result = this.MotherBoard.Processor.SquareNumber(data);
            this.MotherBoard.DrawOnVideoCard(result);
        }
    }
}
