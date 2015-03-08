using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    /// <summary>
    /// Class used to keep track of board position. Tested by PositionTest
    /// Author: qtr23
    /// </summary>
    public class Position
    {
        int x;
        int y;
        int XMAX;
        int YMAX;
        const int CHESSDEFAULT = 8;
        bool failed;

        public Position(int xMAX, int yMAX)
        {
            XMAX = xMAX;
            YMAX = yMAX;
            x = 1;
            y = 1;
            failed = false;
        }

        public Position()
        {
            XMAX = CHESSDEFAULT;
            YMAX = CHESSDEFAULT;
            x = 1;
            y = 1;
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value > 0 && value <= XMAX)
                    x = value;
                else failed = true;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value > 0 && value <= YMAX)
                    y = value;
                else failed = true;
            }
        }
        public void Reset()
        {
            x = 1;
            y = 1;
            failed = false;
        }
        public bool Failed()
        { return failed; }
    }
