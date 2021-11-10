﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Pieces;

namespace ChessGame.GameBoard
{
    public class Board
    {
        private Tile[,] gameBoard;
        private List<Piece> whitePieces;
        private List<Piece> blackPieces;

        public Tile[,] GameBoard { get => gameBoard; set => gameBoard = value; }
        public List<Piece> BlackPieces { get => blackPieces; set => blackPieces = value; }
        public List<Piece> WhitePieces { get => whitePieces; set => whitePieces = value; }

        public Board(Builder builder)
        {
            this.GameBoard = CreateTiles(builder);
            this.BlackPieces = ActivePieces(this, Alliance.BLACK);
            this.WhitePieces = ActivePieces(this, Alliance.WHITE);
        }

        public List<Piece> ActivePieces(Board board, Alliance alliance)
        {
            List<Piece> pieces = new List<Piece>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tile tile = board.GameBoard[i, j];
                    if (tile.IsTileOccupied())
                    {
                        if(tile.GetPiece().Alliance == alliance)
                        {
                            pieces.Add(tile.GetPiece());
                        }
                    }
                }            
            }
            return pieces;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tile tile = GameBoard[i, j];
                    if (tile.IsTileOccupied())
                    {
                        builder.Append(tile.GetPiece().ToString() + " ");
                    } else
                    {
                        builder.Append("- ");
                    }
                }
                builder.Append("\n");
            }

            return builder.ToString();

        }
        public Tile[,] CreateTiles(Builder builder)
        {
            Tile[,] tiles = new Tile[8, 8];
            Dictionary<Cordinate, Piece> boardConfig = builder.BoardConfig;
            Tile tile;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cordinate cor = new Cordinate(i, j);

                    if (boardConfig.ContainsKey(cor))
                    {
                        tile = Tile.CreateTile(cor, boardConfig[cor]);
                    } else
                    {
                        tile = Tile.CreateTile(cor, null);
                    }                  
                    tiles[i, j] = tile;
                }
            }
            return tiles;
        }

        public static Board SetPiecesStartPosition()
        {
            Builder builder = new Builder();
            //Set the BLACK pieces
            builder.SetPiece(new Rock(new Cordinate(0, 0), Alliance.BLACK, PieceType.ROCK));
            builder.SetPiece(new Knigth(new Cordinate(0, 1), Alliance.BLACK, PieceType.KNIGTH));
            builder.SetPiece(new Bishop(new Cordinate(0, 2), Alliance.BLACK, PieceType.BISHOP));
            builder.SetPiece(new Queen(new Cordinate(0, 3), Alliance.BLACK, PieceType.QUEEN));
            builder.SetPiece(new King(new Cordinate(0, 4), Alliance.BLACK, PieceType.KING));
            builder.SetPiece(new Bishop(new Cordinate(0, 5), Alliance.BLACK, PieceType.BISHOP));
            builder.SetPiece(new Knigth(new Cordinate(0, 6), Alliance.BLACK, PieceType.KNIGTH));
            builder.SetPiece(new Rock(new Cordinate(0, 7), Alliance.BLACK, PieceType.ROCK));
            
            builder.SetPiece(new Pawn(new Cordinate(1, 0), Alliance.BLACK, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(1, 1), Alliance.BLACK, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(1, 2), Alliance.BLACK, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(1, 3), Alliance.BLACK, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(1, 4), Alliance.BLACK, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(1, 5), Alliance.BLACK, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(1, 6), Alliance.BLACK, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(1, 7), Alliance.BLACK, PieceType.PAWN));


            //Set the WHITE pieces
            builder.SetPiece(new Rock(new Cordinate(7, 0), Alliance.WHITE, PieceType.ROCK));
            builder.SetPiece(new Knigth(new Cordinate(7, 1), Alliance.WHITE, PieceType.KNIGTH));
            builder.SetPiece(new Bishop(new Cordinate(7, 2), Alliance.WHITE, PieceType.BISHOP));
            builder.SetPiece(new King(new Cordinate(7, 4), Alliance.WHITE, PieceType.KING));
            builder.SetPiece(new Queen(new Cordinate(7, 3), Alliance.WHITE, PieceType.QUEEN));
            builder.SetPiece(new Bishop(new Cordinate(7, 5), Alliance.WHITE, PieceType.BISHOP));
            builder.SetPiece(new Knigth(new Cordinate(7, 6), Alliance.WHITE, PieceType.KNIGTH));
            builder.SetPiece(new Rock(new Cordinate(7, 7), Alliance.WHITE, PieceType.ROCK));

            builder.SetPiece(new Pawn(new Cordinate(6, 0), Alliance.WHITE, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(6, 1), Alliance.WHITE, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(6, 2), Alliance.WHITE, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(6, 3), Alliance.WHITE, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(6, 4), Alliance.WHITE, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(6, 5), Alliance.WHITE, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(6, 6), Alliance.WHITE, PieceType.PAWN));
            builder.SetPiece(new Pawn(new Cordinate(6, 7), Alliance.WHITE, PieceType.PAWN));

            builder.SetNextMoveMaker(Alliance.WHITE);

            return builder.Build();
        }

        public Tile GetTile(Cordinate cordinate)
        {
            return GameBoard[cordinate.XCordinate, cordinate.YCordinate]; 
        }
    }
}