using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Knight:Piece
    {
         public Knight(PIECE_COLOR c, Position p) : base(c, p) { }
        public override  Func<Assets.Scripts.Chess451.Board, Assets.Scripts.Chess451.ThreatMap> getMoves()
        {
            return (x) =>
            {
                Assets.Scripts.Chess451.ThreatMap t = new Assets.Scripts.Chess451.ThreatMap();

                // Using the piece's position...
                Position p = position;

                // Calculate a list of valid positions
                Position[] tempList = new Position[8];


                // Knight Valid positions = L shaped bullshit
                // 
                tempList[0].X = p.X + 1;
                tempList[0].Y = p.Y + 3;



                tempList[1].X = p.X + 3;
                tempList[1].Y = p.Y + 1;



                tempList[2].X = p.X + 3;
                tempList[2].Y = p.Y - 1;



                tempList[3].X = p.X - 1;
                tempList[3].Y = p.Y + 3;

                tempList[4].X = p.X - 1;
                tempList[4].X = p.Y - 3;

                tempList[5].X = p.X - 3;
                tempList[5].X = p.Y - 1;

                tempList[6].X = p.X + 1;
                tempList[6].Y = p.Y - 3;

                tempList[7].X = p.X - 3;
                tempList[7].Y = p.Y + 1;

                // The following is common in Most Pieces
                foreach (Position temp in tempList)
                {
                    // Is it on the board
                    if (!temp.Failed())
                    {
                        // If it's not an allied  piece...
                        Piece tempPiece = x.getBoardPiece(temp.X-1, temp.Y-1);
                        if ((Object.Equals(tempPiece,null)) || (tempPiece.color != color))
                        {
                            // It's valid
                            t.SetSpot(temp.X-1, temp.Y-1, true);
                        }
                    }
                }

                return t;

            };
        }
    }
}
