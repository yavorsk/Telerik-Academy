using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    public enum GameState
    {
        WaitingForSecondPlayer = 0,
        BluePlayerTurn = 1,
        RedPlayerTurn = 2,
        WonByBluePlayer = 3,
        WonByRedPlayer = 4
    }
}
