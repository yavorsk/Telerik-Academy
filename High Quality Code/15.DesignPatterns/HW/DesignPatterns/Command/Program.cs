using System;
using System.Linq;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Light lamp = new Light();
            ICommand switchUp = new FlipUpCommand(lamp);
            ICommand switchDown = new FlipDownCommand(lamp);

            Switch sw = new Switch();

            sw.StoreAndExecute(switchUp);
            sw.StoreAndExecute(switchDown);
        }
    }
}
