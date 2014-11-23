namespace ComputersBuildingSystem
{
    using System;
    using System.Linq;

    public class ColorfullVideoCard : IVideoCard
    {
        public void Draw(string textToDisplay)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(textToDisplay);
            Console.ResetColor();
        }
    }
}
