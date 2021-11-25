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
        private List<Piece> activePieces;
        private King playerKing;
        private Alliance alliance;
        private bool isInCheck;

        public Player(Alliance alliance, Board board, List<Move> legalMoves, List<Move> opponentsLegalMoves)
        {
            this.Alliance = alliance;
            Board = board;
            OpponentsLegalMoves = opponentsLegalMoves;
            PlayerKing = EstablishKing(board);
            IsInCheck = IsPlayerInCheck(opponentsLegalMoves, board);
            ActivePieces = CalculatePlayersActivePieces(board);
            LegalMoves = legalMoves;
            LegalMoves.AddRange(CalculateCastleMoves(opponentsLegalMoves));   
        }
        public Board Board { get => board; set => board = value; }
        public List<Move> LegalMoves { get => legalMoves; set => legalMoves = value; }
        public List<Move> OpponentsLegalMoves { get => opponentsLegalMoves; set => opponentsLegalMoves = value; }
        public King PlayerKing { get => playerKing; set => playerKing = value; }
        public Alliance Alliance { get => alliance; set => alliance = value; }
        public bool IsInCheck { get => isInCheck; set => isInCheck = value; }
        public List<Piece> ActivePieces { get => activePieces; set => activePieces = value; }
        public bool IsPlayerInCheck(List<Move> moves, Board board)
        {
            Tile kingTile = board.GetTile(this.PlayerKing.Cordinate);
            if (kingTile.AttacksOnTile(moves).Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private King EstablishKing(Board board)
        {
            foreach (Piece piece in CalculatePlayersActivePieces(board))
            {
                if (piece.PieceType == PieceType.KING)
                {
                    return (King)piece;
                }
            }
            return null;
        }
        public bool HasEscapeMove()
        {
            foreach (Move move in LegalMoves)
            {
                MoveTransition moveTransition = MakeMove(move);
                if (moveTransition.MoveStatus == MoveStatus.DONE)
                {
                    return true;
                }
            }
            return false;
        }
        private List<Piece> CalculatePlayersActivePieces(Board board)
        {
            if (this.Alliance == Alliance.BLACK)
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
            if (this.Alliance == Alliance.BLACK)
            {
                return Board.WhitePlayer;
            }
            if (this.Alliance == Alliance.WHITE)
            {
                return Board.BlackPlayer;
            }
            return null;
        }
        public bool IsMoveLegal(Move move)
        {
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


        //TODO may need to do some changes depenging on movetransition devlopment
        public MoveTransition MakeMove(Move move)
        {
            if (!IsMoveLegal(move))
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


        private List<Move> CalculateCastleMoves(List<Move> opponentsLegalMoves)
        {
            List<Move> castleMoves = new List<Move>();        
            if (Alliance == Alliance.BLACK)
            {
                if (PlayerKing.IsFirstMove && !IsPlayerInCheck(opponentsLegalMoves, Board))
                {
                    //Check Kingside castle
                    if(!Board.GetTile(new Cordinate(5,0)).IsTileOccupied() &&
                       !Board.GetTile(new Cordinate(6,0)).IsTileOccupied() &&
                        Board.GetTile(new Cordinate(7,0)).IsTileOccupied())
                    {                       
                        if(Board.GetTile(new Cordinate(7,0)).GetPiece().PieceType == PieceType.ROCK)
                        {
                            Rock castleRock = (Rock) Board.GetTile(new Cordinate(7, 0)).GetPiece();
                            if (castleRock.IsFirstMove)
                            {
                                if (Board.GetTile(new Cordinate(5, 0)).AttacksOnTile(opponentsLegalMoves).Count == 0 &&
                                    Board.GetTile(new Cordinate(6, 0)).AttacksOnTile(opponentsLegalMoves).Count == 0)
                                {
                                    Cordinate kingDestinationCordinate = new Cordinate(6, 0);
                                    Cordinate rockDestinationCordinate = new Cordinate(5, 0);
                                    castleMoves.Add(new KingSideCastleMove(PlayerKing, kingDestinationCordinate, Board, castleRock, rockDestinationCordinate));
                                }
                            }
                        }
                    }
                    //Check Queenside castle
                    if (!Board.GetTile(new Cordinate(3, 0)).IsTileOccupied() &&
                        !Board.GetTile(new Cordinate(2, 0)).IsTileOccupied() &&
                        !Board.GetTile(new Cordinate(1, 0)).IsTileOccupied() &&
                         Board.GetTile(new Cordinate(0, 0)).IsTileOccupied())
                    {
                        if (Board.GetTile(new Cordinate(0, 0)).GetPiece().PieceType == PieceType.ROCK)
                        {
                            Rock castleRock = (Rock)Board.GetTile(new Cordinate(0, 0)).GetPiece();
                            if (castleRock.IsFirstMove)
                            {
                                if (Board.GetTile(new Cordinate(3, 0)).AttacksOnTile(opponentsLegalMoves).Count == 0 &&
                                    Board.GetTile(new Cordinate(2, 0)).AttacksOnTile(opponentsLegalMoves).Count == 0 &&
                                    Board.GetTile(new Cordinate(1, 0)).AttacksOnTile(opponentsLegalMoves).Count == 0)
                                {
                                    Cordinate kingDestinationCordinate = new Cordinate(2, 0);
                                    Cordinate rockDestinationCordinate = new Cordinate(3, 0);
                                    castleMoves.Add(new QueenSideCastleMove(PlayerKing, kingDestinationCordinate, Board, castleRock, rockDestinationCordinate));
                                }
                            }
                        }
                    }
                }
            }

            if (Alliance == Alliance.WHITE)
            {
                if (PlayerKing.IsFirstMove && !IsPlayerInCheck(opponentsLegalMoves, Board))
                {
                    //Check Kingside castle
                    if (!Board.GetTile(new Cordinate(5, 7)).IsTileOccupied() &&
                       !Board.GetTile(new Cordinate(6, 7)).IsTileOccupied() &&
                        Board.GetTile(new Cordinate(7, 7)).IsTileOccupied())
                    {
                        if (Board.GetTile(new Cordinate(7, 7)).GetPiece().PieceType == PieceType.ROCK)
                        {
                            Rock castleRock = (Rock)Board.GetTile(new Cordinate(7, 7)).GetPiece();
                            if (castleRock.IsFirstMove)
                            {
                                if (Board.GetTile(new Cordinate(5, 7)).AttacksOnTile(opponentsLegalMoves).Count == 0 &&
                                    Board.GetTile(new Cordinate(6, 7)).AttacksOnTile(opponentsLegalMoves).Count == 0)
                                {
                                    Cordinate kingDestinationCordinate = new Cordinate(6, 7);
                                    Cordinate rockDestinationCordinate = new Cordinate(5, 7);
                                    castleMoves.Add(new KingSideCastleMove(PlayerKing, kingDestinationCordinate, Board, castleRock, rockDestinationCordinate));
                                }
                            }
                        }
                    }
                    //Check Queenside castle
                    if (!Board.GetTile(new Cordinate(3, 7)).IsTileOccupied() &&
                        !Board.GetTile(new Cordinate(2, 7)).IsTileOccupied() &&
                        !Board.GetTile(new Cordinate(1, 7)).IsTileOccupied() &&
                         Board.GetTile(new Cordinate(0, 7)).IsTileOccupied())
                    {
                        if (Board.GetTile(new Cordinate(0, 7)).GetPiece().PieceType == PieceType.ROCK)
                        {
                            Rock castleRock = (Rock)Board.GetTile(new Cordinate(0, 7)).GetPiece();
                            if (castleRock.IsFirstMove)
                            {
                                if (Board.GetTile(new Cordinate(3, 7)).AttacksOnTile(opponentsLegalMoves).Count == 0 &&
                                    Board.GetTile(new Cordinate(2, 7)).AttacksOnTile(opponentsLegalMoves).Count == 0 &&
                                    Board.GetTile(new Cordinate(1, 7)).AttacksOnTile(opponentsLegalMoves).Count == 0)
                                {
                                    Cordinate kingDestinationCordinate = new Cordinate(2, 7);
                                    Cordinate rockDestinationCordinate = new Cordinate(3, 7);
                                    castleMoves.Add(new QueenSideCastleMove(PlayerKing, kingDestinationCordinate, Board, castleRock, rockDestinationCordinate));
                                }
                            }
                        }
                    }
                }
            }
            return castleMoves;
        }
    }
}
