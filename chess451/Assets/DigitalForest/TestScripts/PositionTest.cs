using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PositionTest: Test
{
    public PositionTest()
    {
        testname = "Position";
    }

    public override bool run( out string message)
    {
        message = "";
        bool passed = true;
        if(!positionNegativeTest())
        {
            message += "(1)Position allows negative index values ";
            passed = false;
        }
        if (!positionUpperPositiveTest())
        {
            message += "(2)Position allows index values out of bounds ";
            passed = false;
        }


        if (passed)
        message = "Passed";
        return passed;
    }

    /// <summary>
    /// Test for whether either Position quantity allows for values below zero
    /// </summary>
    /// <returns>success or failure of test</returns>
    bool positionNegativeTest()
    {
        Position p = new Position(8, 8);
       
        p.X = -1;
        if (p.X == -1)
            return false;
        p.Y = -1;
        if (p.Y == -1)
            return false;
        return true;
    }
    /// <summary>
    /// Test for whether either Position quantity allows for values above the maximum size of the board container
    /// </summary>
    /// <returns>success or failure of test</returns>
    bool positionUpperPositiveTest()
    {
        Position p = new Position();
        p.X = 10;
        p.Y = 12;
        if (p.X == 10)
            return false;
        if (p.Y == 12)
            return false;
        return true;
    }
}
