using System;
using System.Collections.Generic;
using System.Linq;

namespace Command
{
    // invoker
    class Switch
    {
        private List<ICommand> commands = new List<ICommand>();

        public void StoreAndExecute(ICommand command)
        {
            this.commands.Add(command);
            command.Execute();
        }
    }
}
