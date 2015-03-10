using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Queen: Piece
    {
         public Queen(PIECE_COLOR c, Position p) : base(c, p) { }
        public override Func<Assets.Scripts.Chess451.Board, Assets.Scripts.Chess451.ThreatMap> getMoves()
        {
            return (x) =>
            {
                Assets.Scripts.Chess451.ThreatMap t = new Assets.Scripts.Chess451.ThreatMap();

                // Using the piece's position...
                Position p = position;

                // Calculate a list of valid positions
                List<Position> tempList = new List<Position>();


                // Queen positions = All the bullshit

                // From the Queen's position, find add every empty space up to the first unit or the edge of the board
                // Add it to our list of potential positions

                AddToListInDirection(tempList, p, 0, -1, x);
                AddToListInDirection(tempList, p, 1, 0, x);
                AddToListInDirection(tempList, p, -1, 0, x);
                AddToListInDirection(tempList, p, 0, 1, x);

                AddToListInDirection(tempList, p, 1, 1, x);
                AddToListInDirection(tempList, p, 1, -1, x);
                AddToListInDirection(tempList, p, -1, 1, x);
                AddToListInDirection(tempList, p, -1, -1, x);


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
