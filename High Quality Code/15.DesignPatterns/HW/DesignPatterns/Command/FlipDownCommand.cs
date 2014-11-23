using System;
using System.Linq;

namespace Command
{
    // concrete command class for turning off the light
    public class FlipDownCommand : ICommand
    {
        public Light Light { get; set; }

        public FlipDownCommand(Light light)
        {
            this.Light = light;
        }

        public void Execute()
        {
            this.Light.TurnOff();
        }
    }
}
