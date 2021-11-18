using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.GameBoard;
using ChessGame.Moves;
using ChessGame.Pieces;

namespace ChessGame.Game
{
    public class Player
    {
        private Board board;
        private List<Move> legalMoves;
        private List<Move> opponentsLegalMoves;
        private King playerKing;
        private Alliance alliance;
        private bool isInCheck;

        public Player(Alliance alliance, Board board, List<Move> legalMoves, List<Move> opponentsLegalMoves)
        {
            this.Alliance = alliance;
            Board = board;
            LegalMoves = legalMoves;
            OpponentsLegalMoves = opponentsLegalMoves;
            PlayerKing = EstablishKing();
            IsInCheck = IsPlayerInCheck(opponentsLegalMoves, Board);
        }
        public Board Board { get => board; set => board = value; }
        public List<Move> LegalMoves { get => legalMoves; set => legalMoves = value; }
        public List<Move> OpponentsLegalMoves { get => opponentsLegalMoves; set => opponentsLegalMoves = value; }
        public King PlayerKing { get => playerKing; set => playerKing = value; }
        public Alliance Alliance { get => alliance; set => alliance = value; }
        public bool IsInCheck { get => isInCheck; set => isInCheck = value; }
        
        public bool IsPlayerInCheck(List<Move> moves, Board board)
        {
            Tile kingTile = board.GetTile(this.PlayerKing.Cordinate);
            if(kingTile.AttacksOnTile(moves).Count == 0)
            {
                return false;
            } else
            {
                return true;
            }
        } 
        private King EstablishKing()
        {
            foreach(Piece piece in GetActivePieces())
            {
                if(piece.PieceType == PieceType.KING)
                {
                    return (King) piece;
                }
            }
            return null;
        }

        public bool HasEscapeMove()
        {
            foreach(Move move in LegalMoves)
            {
                MoveTransition moveTransition = MakeMove(move);
                if (moveTransition.MoveStatus == MoveStatus.DONE)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Piece> GetActivePieces()
        {
            if(this.Alliance == Alliance.BLACK)
            {
                return board.BlackPieces;
            }
            if (this.Alliance == Alliance.WHITE)
            {
                return board.WhitePieces;
            }
            return null;
        }

        public Player GetOpponent()
        {
            if(this.Alliance == Alliance.BLACK)
            {
                return Board.WhitePlayer;
            }
            if(this.Alliance == Alliance.WHITE)
            {
                return Board.BlackPlayer;
            }
            return null;
        }

        public bool IsMoveLegal(Move move)
        {
            //Need to change the move Equals + Hash metod?          
           return this.LegalMoves.Contains(move);          
        }
        public bool IsInCheckMate()
        {
            return IsInCheck && !HasEscapeMove();
        }
        public bool IsInStalemate()
        {
            return !IsInCheck && !HasEscapeMove();
        }
        public bool IsCastled()
        {
            return false;
        }

        //TODO may need to do some changes depenging on movetransition devlopment
        public MoveTransition MakeMove(Move move)
        {
            if(!IsMoveLegal(move))
            {
                return new MoveTransition(move, this.board, this.board, MoveStatus.ILLEGAL_MOVE);
            }

            Board transitionBoard = move.Execute();

            if (IsPlayerInCheck(transitionBoard.CurrentPlayer.GetOpponent().LegalMoves, transitionBoard))
            {
                return new MoveTransition(move, this.Board, this.Board, MoveStatus.LEAVES_PLAYER_IN_CHECK);
            }

            return new MoveTransition(move, transitionBoard, this.Board, MoveStatus.DONE);
        }
    }
}
