using System;
using System.Linq;

namespace Command
{
    // concrete command class for turning on the light
    public class FlipUpCommand : ICommand
    {
        public Light Light {get; set;}

        public FlipUpCommand(Light light)
        {
            this.Light = light;
        }

        public void Execute()
        {
            this.Light.TurnOn();
        }
    }
}
