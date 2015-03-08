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
        }
        public Piece getBoardPiece(int x, int y)
        { return _board[x, y]; }
        
        public void moveBoardPiece(int x1, int y1, int x2, int y2)
        {
            _board[x2, y2] = _board[x1, y1];
            _board[x1, y1] = null;
        }
    }
}
