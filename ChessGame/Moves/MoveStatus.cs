using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Moves
{
    public enum MoveStatus
    {
        DONE,
        ILLEGAL_MOVE,
        LEAVES_PLAYER_IN_CHECK
    }
}
