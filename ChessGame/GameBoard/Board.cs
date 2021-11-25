using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Pieces;
using ChessGame.Game;
using ChessGame.Moves;

namespace ChessGame.GameBoard
{
    public class Board
    {
        private Tile[,] gameBoard;
        private List<Piece> whitePieces;
        private List<Piece> blackPieces;
        private Player whitePlayer;
        private Player blackPlayer;
        private Player currentPlayer;

        public Tile[,] GameBoard { get => gameBoard; set => gameBoard = value; }
        public List<Piece> BlackPieces { get => blackPieces; set => blackPieces = value; }
        public List<Piece> WhitePieces { get => whitePieces; set => whitePieces = value; }
        public Player WhitePlayer { get => whitePlayer; set => whitePlayer = value; }
        public Player BlackPlayer { get => blackPlayer; set => blackPlayer = value; }
        public Player CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

        public Board(Builder builder)
        {
            this.GameBoard = CreateTiles(builder);
            this.BlackPieces = ActivePieces(this, Alliance.BLACK);
            this.WhitePieces = ActivePieces(this, Alliance.WHITE);
            List<Move> whitePiecesLegalMoves = CalculateActivePiecesLegalMoves(this.WhitePieces);
            List<Move> blackPiecesLegalMoves = CalculateActivePiecesLegalMoves(this.BlackPieces);
            WhitePlayer = new Player(Alliance.WHITE, this, whitePiecesLegalMoves, blackPiecesLegalMoves);
            BlackPlayer = new Player(Alliance.BLACK, this, blackPiecesLegalMoves, whitePiecesLegalMoves);
            CurrentPlayer = DecideCurrentPlayer(WhitePlayer, BlackPlayer, builder.NextMoveMaker);
        }
        private List<Move> CalculateActivePiecesLegalMoves(List<Piece> activePieces)
        {
            List<Move> legalMoves = new List<Move>();
            foreach (Piece piece in activePieces)
            {
                foreach (Move move in piece.LegalMoves(this))
                {
                    legalMoves.Add(move);
                }
            }
            return legalMoves;
        }
        private List<Piece> ActivePieces(Board board, Alliance alliance)
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
                    Tile tile = GameBoard[j, i];
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
        private Player DecideCurrentPlayer(Player whitePlayer, Player blackPlayer, Alliance currentPlayerAlliance)
        {
            if (whitePlayer.Alliance == currentPlayerAlliance)
            {
                return whitePlayer;
            }
            if (blackPlayer.Alliance == currentPlayerAlliance)
            {
                return blackPlayer;
            }
            return null;
        }
        public static Board SetPiecesStartPosition()
        {
            Builder builder = new Builder();
            //Set the BLACK pieces
            builder.SetPiece(new Rock(new Cordinate(0, 0), Alliance.BLACK, true));
            builder.SetPiece(new Knigth(new Cordinate(1, 0), Alliance.BLACK, true));
            builder.SetPiece(new Bishop(new Cordinate(2, 0), Alliance.BLACK, true));
            builder.SetPiece(new Queen(new Cordinate(3, 0), Alliance.BLACK, true));
            builder.SetPiece(new King(new Cordinate(4, 0), Alliance.BLACK, true));
            builder.SetPiece(new Bishop(new Cordinate(5, 0), Alliance.BLACK, true));
            builder.SetPiece(new Knigth(new Cordinate(6, 0), Alliance.BLACK, true));
            builder.SetPiece(new Rock(new Cordinate(7, 0), Alliance.BLACK, true));
            
            builder.SetPiece(new Pawn(new Cordinate(0, 1), Alliance.BLACK, true));
            builder.SetPiece(new Pawn(new Cordinate(1, 1), Alliance.BLACK, true));
            builder.SetPiece(new Pawn(new Cordinate(2, 1), Alliance.BLACK, true));
            builder.SetPiece(new Pawn(new Cordinate(3, 1), Alliance.BLACK, true));
            builder.SetPiece(new Pawn(new Cordinate(4, 1), Alliance.BLACK, true));
            builder.SetPiece(new Pawn(new Cordinate(5, 1), Alliance.BLACK, true));
            builder.SetPiece(new Pawn(new Cordinate(6, 1), Alliance.BLACK, true));
            builder.SetPiece(new Pawn(new Cordinate(7, 1), Alliance.BLACK, true));

            //Set the WHITE pieces
            builder.SetPiece(new Rock(new Cordinate(0, 7), Alliance.WHITE, true));
            builder.SetPiece(new Knigth(new Cordinate(1, 7), Alliance.WHITE, true));
            builder.SetPiece(new Bishop(new Cordinate(2, 7), Alliance.WHITE, true));
            builder.SetPiece(new Queen(new Cordinate(3, 7), Alliance.WHITE, true));
            builder.SetPiece(new King(new Cordinate(4, 7), Alliance.WHITE, true));
            builder.SetPiece(new Bishop(new Cordinate(5, 7), Alliance.WHITE, true));
            builder.SetPiece(new Knigth(new Cordinate(6, 7), Alliance.WHITE, true));
            builder.SetPiece(new Rock(new Cordinate(7, 7), Alliance.WHITE, true));

            builder.SetPiece(new Pawn(new Cordinate(0, 6), Alliance.WHITE, true));
            builder.SetPiece(new Pawn(new Cordinate(1, 6), Alliance.WHITE, true));
            builder.SetPiece(new Pawn(new Cordinate(2, 6), Alliance.WHITE, true));
            builder.SetPiece(new Pawn(new Cordinate(3, 6), Alliance.WHITE, true));
            builder.SetPiece(new Pawn(new Cordinate(4, 6), Alliance.WHITE, true));
            builder.SetPiece(new Pawn(new Cordinate(5, 6), Alliance.WHITE, true));
            builder.SetPiece(new Pawn(new Cordinate(6, 6), Alliance.WHITE, true));
            builder.SetPiece(new Pawn(new Cordinate(7, 6), Alliance.WHITE, true));

            builder.SetNextMoveMaker(Alliance.WHITE);
            return builder.Build();
        }
        public Tile GetTile(Cordinate cordinate)
        {
            return GameBoard[cordinate.XCordinate, cordinate.YCordinate]; 
        }
    }
}
