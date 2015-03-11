using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Chess451
{
    class King: Piece
    {
         public King(PIECE_COLOR c, Position p) : base(c, p) { }
        public override Func<Assets.Scripts.Chess451.Board, Assets.Scripts.Chess451.ThreatMap> getMoves()
        {
            return (x) =>
            {
                Assets.Scripts.Chess451.ThreatMap t = new Assets.Scripts.Chess451.ThreatMap();

                // Using the piece's position...
                Position p = position;

                // Calculate a list of valid positions
                Position[] tempList = new Position[8];

                for (int i = 0; i < 8; i++)
                    tempList[i] = new Position();

                //UnityEngine.Debug.Log("King Begin At " + p.X + " " + p.Y);
                // King Valid positions = surrounding 8 spaces

                // right
                
                tempList[0].X = p.X  + 1;
                tempList[0].Y = p.Y ;


                // left
                tempList[1].X = p.X - 1;
                tempList[1].Y = p.Y;


                // bottom
                tempList[2].X = p.X;
                tempList[2].Y = p.Y - 1;


                //top
                tempList[3].X = p.X;
                tempList[3].Y = p.Y + 1;


                //tl
                tempList[4].X = p.X - 1;
                tempList[4].Y = p.Y + 1;

                // tr
                tempList[5].X = p.X + 1;
                tempList[5].Y = p.Y + 1;

                // bl
                tempList[6].X = p.X - 1;
                tempList[6].Y = p.Y - 1;

                // br
                tempList[7].X = p.X + 1;
                tempList[7].Y = p.Y - 1;

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
                            //UnityEngine.Debug.Log("Hit!");
                            //UnityEngine.Debug.Log("At " + temp.X + " " + temp.Y);
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
