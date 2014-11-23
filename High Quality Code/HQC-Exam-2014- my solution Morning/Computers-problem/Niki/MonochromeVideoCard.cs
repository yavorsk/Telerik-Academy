namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    public class MonochromeVideoCard : IVideoCard
    {
        public void Draw(string textToDisplay)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(textToDisplay);
            Console.ResetColor();
        }
    }
}
