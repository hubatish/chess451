using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assets.Scripts.Chess451
{
    public class Board
    {
        Piece[,] _board;
        public Board()
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
            _board[3, 7] = new Queen(PIECE_COLOR.BLACK, p);
            p.X = 5;
            _board[4, 7] = new King(PIECE_COLOR.BLACK, p);
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
                _board[i, 6] = new Pawn(PIECE_COLOR.BLACK, p);
            }
        }
        public Board(List<Piece> pieces)
        {
            _board = new Piece[8, 8];

            foreach (Piece p in pieces)
            {
                int x = p.position.X - 1;
                int y = p.position.Y - 1;
                _board[x, y] = p;
            }
        }


        public bool isValidMove(int x1, int y1, int x2, int y2)
        {
            UnityEngine.Debug.Log( "Moving from " + _board[x1, y1].position.X + " " + _board[x1, y1].position.Y + " to " + (x2 + 1) + " " + (y2 + 1));
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
                    //_board[7,0] 
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

        public bool isCastleMoveValid(int x1, int y1, int x2, int y2)//(Position p1, Position p2)
        {
           /* int x1 = p1.X - 1;
            int y1 = p1.Y - 1;
            int x2 = p2.X - 1;
            int y2 = p2.Y - 1;*/

            if (Object.Equals(_board[x1, y1], null) || Object.Equals(_board[x2, y2], null))
            {
                //either square empty
                return false;
            }

            PIECE_COLOR color = _board[x1, y1].color;
            if(color == PIECE_COLOR.WHITE)
            {
                if(y1!=0 || y2!=0)
                {
                    //y wrong
                    return false;
                }
                //king is at 4
                int otherX = -1;
                if(x1 == 4)
                {
                    otherX = x2;
                }
                else if(x2==4)
                {
                    otherX = x1;
                }
                if(otherX==-1)
                {
                    //neither is king
                    return false;
                }
                //check if other position is correct
                if(otherX==0)
                {
                    return canQueenSideCastle(color);
                }
                else if(otherX==7)
                {
                    return canKingSideCastle(color);
                }
                return false;
            }
            else if (color == PIECE_COLOR.BLACK)
            {
                if (y1 != 7 || y2 != 7)
                {
                    //y wrong
                    return false;
                }
                //king is at 3
                int otherX = -1;
                if (x1 == 3)
                {
                    otherX = x2;
                }
                else if (x2 == 3)
                {
                    otherX = x1;
                }
                if (otherX == -1)
                {
                    //neither is king
                    return false;
                }
                //check if other position is correct
                if (otherX == 0)
                {
                    return canQueenSideCastle(color);
                }
                else if (otherX == 7)
                {
                    return canKingSideCastle(color);
                }
                return false;
            }

            return false;
        }

        public Piece getBoardPiece(Position p)
        {
            return _board[p.X - 1, p.Y - 1];
        }
        public Piece getBoardPiece(int x, int y)
        { return _board[x, y]; }

        public bool Stalemate()
        {
            bool retVal = true;
            foreach (Piece p in _board)
            {
                if (!Object.Equals(p, null))
                {
                    ThreatMap t = p.getMoves().Invoke(this);
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (t.GetSpot(i, j))
                            {
                                retVal = false;
                            }
                        }
                    }
                    //tList1.Add(t);
                }


            }
            return retVal;
        }

        public bool FastCheck(PIECE_COLOR c)
        {
            bool retVal = false;
            foreach (Piece p in _board)
            {
                if (!Object.Equals(p, null))
                {
                    ThreatMap t = p.getMoves().Invoke(this);
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (_board[i, j] is King && t.GetSpot(i, j) && _board[i, j].color == c)
                            {

                                retVal = true;
                                goto End;                                
                                
                            }

                        }
                    }
                    //tList1.Add(t);
                }


            }
            End:
            return retVal;
            
        }

        public bool Check(PIECE_COLOR c, out bool mate)
        {
            King myKing = new King(c, new Position());
            mate = false;
            bool retVal = false;
            List<Piece> checkingPieces = new List<Piece>();
            //List<ThreatMap> tList1 = new List<ThreatMap>();
            Dictionary<Piece, ThreatMap> d = new Dictionary<Piece, ThreatMap>();
            foreach(Piece p in _board)
            {
                if(!Object.Equals(p, null))
                {
                ThreatMap t = p.getMoves().Invoke(this);
                d.Add(p, t);
                //tList1.Add(t);
                }
                
               
            }
            // We now have every threatmap
            foreach(Piece p in d.Keys)
            {
                ThreatMap t = d[p];
                for (int i = 0; i < 8; i++)
                 {
                    for (int j = 0; j < 8; j++)
                    {
                        if (_board[i, j] is King && t.GetSpot(i, j) && _board[i, j].color == c)
                        {

                            retVal = true;
                            checkingPieces.Add(p);
                            //d.Remove(p);
                            myKing = (King)_board[i, j];    
                        }
                        
                    }
                }
            }

            foreach (Piece p in checkingPieces)
            {
                d.Remove(p);
            }
            d.Remove(myKing);
            // Checkmate code begins here. It's complicated
            if (retVal)
            {
               
                Dictionary<Piece,ThreatMap> checkTs = new Dictionary<Piece,ThreatMap>();
                foreach (Piece p in checkingPieces)
                {
                    checkTs.Add( p,p.getMoves().Invoke(this));    
                }
                List<Piece> blockers = new List<Piece>();
                // Step 1: Can one of my pieces Take it out
               //  In addition, leave "block" markers for any area they can move to
               // {

                    
                    foreach (Piece p in d.Keys)
                    {
                        for (int j = 0; j < 8; j++)
                            for (int k = 0; k < 8; k++)
                            {
                                foreach (Piece p2 in checkTs.Keys)
                                {
                                    if (p.color == c && d[p].GetSpot(j, k) && (j + 1) == p2.position.X && (k + 1) == p2.position.Y)
                                    {
                                        checkingPieces.Remove(p);
                                        //checkTs.Remove(p);
                                        // goto Bottom;
                                    }
                                }
                                if(d[p].GetSpot(j,k) && p.color == c)
                                {
                                Position p3 = new Position();
                                p3.X = j + 1;
                                p3.Y = k + 1;
                                blockers.Add(new Pawn(c, p3));
                                }
                            }
                    }
                //Bottom:
                  //  continue; 

                //}

                    blockers.Add(myKing);
                    
                    Board tempBoard = new Board(blockers);
                    List<Piece> buffer = new List<Piece>();
                    foreach (Piece p in checkingPieces)
                    {
                        ThreatMap t = p.getMoves().Invoke(tempBoard);
                        if (!t.GetSpot(myKing.position.X - 1, myKing.position.Y - 1))
                        {
                            buffer.Add(p);
                            checkTs.Remove(p);
                        }
                    }

                    foreach (Piece p in buffer)
                    {
                        checkingPieces.Remove(p);
                    }


                if (checkingPieces.Count != 0) // if we STILL have things checking the king
                {
                    ThreatMap kingThreat = myKing.getMoves().Invoke(this);
                    mate = true; // Checkmate is now possible
                    // Strip checking pieces
                    foreach (Piece p in checkingPieces)
                    {
                        for (int i = 0; i < 8; i++)  
                            for (int j = 0; j < 8; j++)
                            {
                                if (checkTs[p].GetSpot(i, j))
                                    kingThreat.SetSpot(i, j, false);
                            }
                    }
                    // Strip all other pieces
                    foreach (Piece p in d.Keys)
                    {
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                            {
                                if (d[p].GetSpot(i, j))
                                    kingThreat.SetSpot(i, j, false);
                            }
                    }

                    for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                                if (kingThreat.GetSpot(i, j))
                                {
                                    //UnityEngine.Debug.Log("Last Chance Saloon at " + i + " " + j);
                                    mate = false; // if the king has even one legal move, this is not checkmate
                                }
                }

            }

            return retVal;
        }

        //ZH Try to move whatever piece is at p1 to p2
        //Return if that's a valid move
        public bool moveBoardPiece(Position p1, Position p2, out bool passant)
        {
            return moveBoardPiece(p1.X-1, p1.Y-1, p2.X-1, p2.Y-1, out passant);
        }

        public bool moveBoardPiece(int x1, int y1, int x2, int y2, out bool passant)
        {
            bool isValid;
            if(isCastleMoveValid(x1,y1,x2,y2))
            {
                isValid = true;
            }
            else
            {
                isValid = isValidMove(x1, y1, x2, y2);
            }
            passant = false;
            
            Piece tempPassant = new Pawn(PIECE_COLOR.WHITE, new Position());
            if (isValid)
            {
                
                if (_board[x1, y1] is Pawn && x2 != x1 && Object.Equals(_board[x2, y2], null))
                {
                    tempPassant = _board[x2, y1];
                    //Capture en passent piece
                    _board[x2, y1] = null;
                    passant = true;
                }

                Piece tempPiece = _board[x2, y2];
                _board[x2, y2] = _board[x1, y1];
                _board[x1, y1] = null;
                

                if(FastCheck(_board[x2, y2].color)) // Rollback illegal moves (mostly pins)
                {
                    _board[x1, y1] = _board[x2, y2];
                    _board[x2, y2] = tempPiece;

                    if (passant)
                    {
                        _board[x2, y1] = tempPassant;
                    }
                    return false;
                }

                Position p = new Position();
                p.X = x2 + 1;
                p.Y = y2 + 1;
                _board[x2, y2].position = p;
				

            }
            return isValid;
        }
    }
}
