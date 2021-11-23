﻿using ChessGame.Game;
using ChessGame.GameBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Utils;
using ChessGame.Moves;

namespace ChessGame.Pieces
{
    public class King : Piece
    {
        public King(Cordinate cordinate, Alliance alliance) : base(cordinate, alliance , PieceType.KING)
        {

        }

        public override List<Move> LegalMoves(Board board)
        {
            List<Move> legalMoves = new List<Move>();
            Cordinate[][] straigthLineCordinates = MoveUtils.CalculateStraigthLineMovement(this.Cordinate);
            Cordinate[][] diagonalMovementCordinates = MoveUtils.CalculateDiagonalMovement(this.Cordinate);
            Cordinate[][] candidateCordinates = straigthLineCordinates.Concat(diagonalMovementCordinates).ToArray();

            for (int i = 0; i < (MoveUtils.DiagonalMoveDirections + MoveUtils.LinearMoveDirections); i++)
            {
                if (candidateCordinates[i].Length != 0)
                {
                    Cordinate currentCandidateCordinate = candidateCordinates[i][0];
                    Tile possibleDestinationTile = board.GetTile(currentCandidateCordinate);
                    if (!possibleDestinationTile.IsTileOccupied())
                    {
                        legalMoves.Add(new NonCaptureMove(this, currentCandidateCordinate, board));
                    } 
                    else
                    {
                        Piece pieceOnOccupiedTile = possibleDestinationTile.GetPiece();
                        if(pieceOnOccupiedTile.Alliance != this.Alliance)
                        {
                            legalMoves.Add(new CaptureMove(this, currentCandidateCordinate, board, pieceOnOccupiedTile));
                        }
                    }
                }
            }
            if (IsCastlePossilbe())
            {
                
            }
            
            return legalMoves;
        }

        public override Piece MovePiece(Move move)
        {
            return new King(move.DestinationCordinate, move.MovingPiece.Alliance);
        }

        private bool IsCastlePossilbe()
        {
            return true;
        }
    }
}
