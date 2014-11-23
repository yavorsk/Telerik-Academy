namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    public class PC : Computer
    {
        private const string WinMessage = "You win!";

        public PC(MotherBoard motherBoard, HDD hardDrive)
            : base(motherBoard, hardDrive)
        {
        }

        public void Play(int guessNumber)
        {
            int randomNumber = this.MotherBoard.Processor.GetRandomNumber(1, 10);
            if (randomNumber != guessNumber)
            {
                this.MotherBoard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", randomNumber));
            }
            else
            {
                this.MotherBoard.DrawOnVideoCard(WinMessage);
            }
        }
    }
}
