using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Chess451
{
    public class Board
    {
        Piece[,] _board;
        Board()
        {
            _board = new Piece[8,8];


            // Seed White Backrow
            Position p = new Position();
            p.X = 1;
            p.Y = 1;
            _board[0, 0] = new Rook(PIECE_COLOR.WHITE,p);
            p.X = 2;
            _board[1, 0] = new Knight(PIECE_COLOR.WHITE, p);
            p.X = 3;
            _board[2, 0] = new Bishop(PIECE_COLOR.WHITE, p);
            p.X = 4;
            _board[3, 0] = new Queen(PIECE_COLOR.WHITE, p);
            p.X = 5;
            _board[4, 0] = new King(PIECE_COLOR.WHITE, p);
            p.X = 6;
            _board[5, 0] = new Bishop(PIECE_COLOR.WHITE, p);
            p.X = 7;
            _board[6, 0] = new Knight(PIECE_COLOR.WHITE, p);
            p.X = 8;
            _board[7, 0] = new Rook(PIECE_COLOR.WHITE, p);

            p.Y = 2;
            //Seet White Frontrow
            for (int i = 0; i < 8; i++ )
            {
                p.X = i + 1;
                _board[i, 1] = new Pawn(PIECE_COLOR.WHITE, p);
            }

                // Seed Black backrow
            p.X = 1;
            p.Y = 8;
            _board[0, 7] = new Rook(PIECE_COLOR.BLACK, p);
            p.X = 2;
            _board[1, 7] = new Knight(PIECE_COLOR.BLACK, p);
            p.X = 3;
            _board[2, 7] = new Bishop(PIECE_COLOR.BLACK, p);
            p.X = 4;
            _board[3, 7] = new King(PIECE_COLOR.BLACK, p);
            p.X = 5;
            _board[4, 7] = new Queen(PIECE_COLOR.BLACK, p);
            p.X = 6;
            _board[5, 7] = new Bishop(PIECE_COLOR.BLACK, p);
            p.X = 7;
            _board[6, 7] = new Knight(PIECE_COLOR.BLACK, p);
            p.X = 8;
            _board[7, 7] = new Rook(PIECE_COLOR.BLACK, p);

            p.Y = 7;
            //Seet Black Frontrow
            for (int i = 0; i < 8; i++)
            {
                p.X = i + 1;
                _board[i, 7] = new Pawn(PIECE_COLOR.BLACK, p);
            }
        }


        public bool isValidMove(int x1, int y1, int x2, int y2)
        {
            ThreatMap t = _board[x1, y1].getMoves().Invoke(this);
            if (t.GetSpot(x2, y2))
                return true;
            else  return false;
        }

        public bool canKingSideCastle(PIECE_COLOR c)
        {
            if (c == PIECE_COLOR.WHITE && !Object.Equals(_board[4, 0], null) && !_board[4, 0].hasMoved) // check the king
                if (!Object.Equals(_board[7, 0], null) && !_board[7, 0].hasMoved) // chech the rook
                {
                    for (int i = 5; i < 7; i++)
                    {
                        if (!Object.Equals(_board[i, 0], null)) // check that the spaces in between are empty
                            return false;
                    }
                        return true;
                }
            if (c == PIECE_COLOR.BLACK && !Object.Equals(_board[3, 7], null) && !_board[3, 7].hasMoved) // check the king
                if (!Object.Equals(_board[0, 7], null) && !_board[0, 7].hasMoved) // chech the rook
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (!Object.Equals(_board[i, 7], null)) // check that the spaces in between are empty
                            return false;
                    }
                    return true;
                }
            return false;
        }


        public bool canQueenSideCastle(PIECE_COLOR c)
        {
            if (c == PIECE_COLOR.WHITE && !Object.Equals(_board[4, 0], null) && !_board[4, 0].hasMoved) // check the king
                if (!Object.Equals(_board[0, 0], null) && !_board[0, 0].hasMoved) // chech the rook
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (!Object.Equals(_board[i, 0], null)) // check that the spaces in between are empty
                            return false;
                    }
                    return true;
                }
            if (c == PIECE_COLOR.BLACK && !Object.Equals(_board[3, 7], null) && !_board[3, 7].hasMoved) // check the king
                if (!Object.Equals(_board[7, 7], null) && !_board[7, 7].hasMoved) // chech the rook
                {
                    for (int i = 4; i < 7; i++)
                    {
                        if (!Object.Equals(_board[i, 7], null)) // check that the spaces in between are empty
                            return false;
                    }
                    return true;
                }
            return false;
        }

        public Piece getBoardPiece(int x, int y)
        { return _board[x, y]; }


        public bool Check()
        {
            foreach(Piece p in _board)
            {
                ThreatMap t = p.getMoves().Invoke(this);
                for(int i =  0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if(_board[i, j] is King && t.GetSpot(i, j))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }



        public bool moveBoardPiece(int x1, int y1, int x2, int y2)
        {
            bool passant = false;
            if (_board[x1, y1] is Pawn && x2 != x1 && Object.Equals(_board[x2, y2],null))
            {
                //Capture en passent piece
                _board[x2, y1] = null;
                passant = true;
            }
            _board[x2, y2] = _board[x1, y1];
          
            _board[x1, y1] = null;
            return passant;
        }
    }
}
