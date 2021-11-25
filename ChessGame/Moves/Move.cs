using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Pieces;

namespace ChessGame.Moves
{
    public abstract class Move : IEquatable<Move>
    {
        private Piece movingPiece;
        private Cordinate destinationCordinate;
        private Board board;

        public Move(Piece movingPiece, Cordinate destination, Board board)
        {
            this.MovingPiece = movingPiece;
            this.DestinationCordinate = destination;
            this.Board = board;
        }

        public abstract Board Execute();

        public override bool Equals(object obj)
        {
            return Equals(obj as Move);
        }

        public bool Equals(Move other)
        {
            return other != null &&
                   EqualityComparer<Piece>.Default.Equals(movingPiece, other.movingPiece) &&
                   EqualityComparer<Cordinate>.Default.Equals(destinationCordinate, other.destinationCordinate) &&
                   EqualityComparer<Board>.Default.Equals(board, other.board);
        }

        public override int GetHashCode()
        {
            int hashCode = 661229150;
            hashCode = hashCode * -1521134295 + EqualityComparer<Piece>.Default.GetHashCode(movingPiece);
            hashCode = hashCode * -1521134295 + EqualityComparer<Cordinate>.Default.GetHashCode(destinationCordinate);
            hashCode = hashCode * -1521134295 + EqualityComparer<Board>.Default.GetHashCode(board);
            return hashCode;
        }
        public virtual bool IsCastleMove()
        {
            return false;
        }
        public Cordinate DestinationCordinate { get => destinationCordinate; set => destinationCordinate = value; }
        public Piece MovingPiece { get => movingPiece; set => movingPiece = value; }
        public Board Board { get => board; set => board = value; }
    }
}
