using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.TestScripts
{
    class CheckTest : CTest
    {
        public CheckTest()
        {
            testname = "Check and Checkmate";
        }

        public override bool run( out string message)
        {
            message = "";
            bool passed = true;
            if(!checkmateNegativeTest())
            {
                message += "(1)Checkmate is found as a false positive";
                passed = false;
            }
            if (!checkmatePositiveTest())
            {
                message += "(2)Checkmate is not found in a proper situation ";
                passed = false;
            }


            if (passed)
            message = "Passed";
            return passed;
        }

        bool checkmatePositiveTest()
        {
            List<Piece> pieces = new List<Piece>();
            Position p = new Position();
            p.X = 1;
            p.Y = 8;
            Assets.Scripts.Chess451.King k = new Assets.Scripts.Chess451.King(PIECE_COLOR.WHITE, p);
            pieces.Add(k);
            p = new Position();
            p.X = 3;
            p.Y = 8;
            Assets.Scripts.Rook r = new Assets.Scripts.Rook(PIECE_COLOR.BLACK, p);
            pieces.Add(r);
            p = new Position();
            p.X = 2;
            p.Y = 6;
            Assets.Scripts.Queen q = new Assets.Scripts.Queen(PIECE_COLOR.BLACK, p);
            pieces.Add(q);

            Assets.Scripts.Chess451.Board b = new Assets.Scripts.Chess451.Board(pieces);

           bool mate;

           b.Check(PIECE_COLOR.WHITE, out mate);
        
            return mate;
        }

        bool checkmateNegativeTest()
        {
            List<Piece> pieces = new List<Piece>();
            Position p = new Position();
            p.X = 1;
            p.Y = 8;
            Assets.Scripts.Chess451.King k = new Assets.Scripts.Chess451.King(PIECE_COLOR.WHITE, p);
            pieces.Add(k);
            p = new Position();
            p.X = 3;
            p.Y = 8;
            Assets.Scripts.Rook r = new Assets.Scripts.Rook(PIECE_COLOR.BLACK, p);
            pieces.Add(r);

            Assets.Scripts.Chess451.Board b = new Assets.Scripts.Chess451.Board(pieces);

            bool mate;

            b.Check(PIECE_COLOR.WHITE, out mate);

            return !mate;
        }
    }
}
