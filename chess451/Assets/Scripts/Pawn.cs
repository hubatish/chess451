using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Pawn: Piece
    {
  
        bool inStep = false;
         public Pawn(PIECE_COLOR c, Position p) : base(c, p) { }

        override public Position position
        {
            get { return pos; }
            protected set
            {
                UnityEngine.Debug.Log("beep");
                if (!hasMoved) { hasMoved = true; }
                if (Math.Abs(value.Y - pos.Y) > 1)
                {
                    inStep = true;
                }
                else if (inStep)
                {
                    inStep = false;
                }

                pos = value;
            }
        }
        public override Func<Assets.Scripts.Chess451.Board, Assets.Scripts.Chess451.ThreatMap> getMoves()
        {
            return (x) =>
            {
                Assets.Scripts.Chess451.ThreatMap t = new Assets.Scripts.Chess451.ThreatMap();

                // Using the piece's position...
                Position p = position;

                // Calculate a list of valid positions
                List<Position> tempList = new List<Position>();


                ///////////THE FOLLOWING ASSUMES THAT WHITE BEGINS AT 0 AND BLACK BEGINS at 7. CHANGE IF NECCESSARY
                int direction = ((color.Equals(PIECE_COLOR.WHITE)) ? 1 : -1);

                // in front
                Position p2 = new Position();
                p2.X = p.X;
                p2.Y = p.Y + direction;
                
                if (!p2.Failed() && Object.Equals(x.getBoardPiece(p2.X-1, p2.Y-1),null))
                tempList.Add(p2);

                p2 = new Position();

                //p2 = new Position();

                UnityEngine.Debug.Log(hasMoved);
                if (!hasMoved)
                {
                    p2.X = p.X;
                    p2.Y = p.Y + (direction * 2);

                    if (!p2.Failed() && Object.Equals(x.getBoardPiece(p2.X-1, p2.Y-1),null))
                    tempList.Add(p2);
					p2 = new Position();
                    //p2 = new Position();
                }
                

                // Diagnal left
               
                p2.X = p.X -1;
                p2.Y = p.Y + direction;
                if (!p2.Failed() && !Object.Equals(x.getBoardPiece(p2.X-1, p2.Y-1),null))
                    tempList.Add(p2);
                p2 = new Position();
                // En Pessant left. Does not handle capture yet
                p2.X = p.X - 1;
                p2.Y = p.Y + direction;
                if(!p2.Failed() && !Object.Equals(x.getBoardPiece(p2.X-1, p2.Y-direction-1),null) && x.getBoardPiece(p2.X-1, p2.Y-direction-1).color != color)
                {
                    Piece tempPiece = x.getBoardPiece(p2.X-1,p2.Y - direction-1);
                    if(tempPiece is Pawn)
                    {
                        Pawn tempPawn = (Pawn)tempPiece;
                        if (tempPawn.inStep)
                        {
                            tempList.Add(p2);
                        }
                    }
                }
                p2 = new Position();
                // Diagnal right

                p2.X = p.X + 1;
                p2.Y = p.Y + direction;
                if (!p2.Failed() && !Object.Equals(x.getBoardPiece(p2.X - 1, p2.Y - 1), null))
                    tempList.Add(p2);
                p2 = new Position();
                // En Pessant right. Does not handle capture yet
                p2.X = p.X + 1;
                p2.Y = p.Y + direction;
                if (!p2.Failed() && !Object.Equals(x.getBoardPiece(p2.X - 1, p2.Y - direction - 1), null) && x.getBoardPiece(p2.X - 1, p2.Y - direction - 1).color != color)
                {
                    Piece tempPiece = x.getBoardPiece(p2.X - 1, p2.Y - direction - 1);
                    if (tempPiece is Pawn)
                    {
                        Pawn tempPawn = (Pawn)tempPiece;
                        if (tempPawn.inStep)
                        {
                            // LARGE CHUNJES OF CODE MISSING HERE;
                            tempList.Add(p2);
                        }
                    }
                }
                // The following is common in Most Pieces
                foreach (Position temp in tempList)
                {
                    // Is it on the board
                    if (!temp.Failed())
                    {
                            
                        // If it's not an allied  piece...
                        Piece tempPiece = x.getBoardPiece(temp.X - 1, temp.Y - 1);
                        if ((Object.Equals(tempPiece,null)) || (tempPiece.color != color))
                        {
                            UnityEngine.Debug.Log("HIT!");
                            UnityEngine.Debug.Log(temp.X + " " + temp.Y);
                            // It's valid
                            t.SetSpot(temp.X - 1, temp.Y - 1, true);
                        }
                    }
                }

                return t;

            };
        }

       

    }
}
