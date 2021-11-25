using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Game;
using ChessGame.GameBoard;

namespace ChessGame.Moves
{
    public class MoveTransition
    {
        private Move move;
        private Board transitionBoard;
        private Board currentBoard;
        private MoveStatus moveStatus;

        public Move Move { get => move; set => move = value; }
        public Board TransitionBoard { get => transitionBoard; set => transitionBoard = value; }
        public Board CurrentBoard { get => currentBoard; set => currentBoard = value; }
        public MoveStatus MoveStatus { get => moveStatus; set => moveStatus = value; }

        public MoveTransition(Move move, Board transitionBoard, Board currentBoard, MoveStatus moveStatus)
        {
            this.move = move;
            this.transitionBoard = transitionBoard;
            this.currentBoard = currentBoard;
            this.moveStatus = moveStatus;
        }

    }
}
