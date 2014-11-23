namespace ComputersBuildingSystem
{
    using System;

    public class BuildingSystemStartPoit
    {
        public static void Main()
        {
            PC pc;
            Laptop laptop;
            Server server;

            const string InvalidCommandMessage = "Invalid command!";

            var manufacturerName = Console.ReadLine();

            ManufacturerFactory manufacturerFactory = new ManufacturerFactory();

            IComputerManufacturer computerManufacturer = manufacturerFactory.GetManufacturer(manufacturerName);

            pc = computerManufacturer.MakePC();
            laptop = computerManufacturer.MakeLaptop();
            server = computerManufacturer.MakeServer();

            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine == null || inputLine == "Exit")
                {
                    break;
                }

                var commandArray = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandArray.Length != 2)
                {
                    {
                        throw new ArgumentException(InvalidCommandMessage);
                    }
                }

                var commandName = commandArray[0];
                var commandArgument = int.Parse(commandArray[1]);

                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArgument);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandArgument);
                }
                else
                {
                    Console.WriteLine(InvalidCommandMessage);
                }
            }
        }
    }
}
