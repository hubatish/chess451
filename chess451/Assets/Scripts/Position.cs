using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    /// <summary>
    /// Class used to keep track of board position. Tested by PositionTest
    /// Author: qtr23
    /// Z.H. 3-8:
    ///     Added functionality to convert to and from grid strings, vector3s
    /// qtr23 3-9
    ///     Corrected conversion - Positions are indexed begining at 1
    /// </summary>
    public class Position
    {
        int x;
        int y;
        int XMAX;
        int YMAX;
        const int CHESSDEFAULT = 8;
        bool failed = false;

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
        }//comment for commit

        public Position(string gridString)
        {
            //Debug.Log("the grid string was: " + gridString);
            char[] posChar = gridString.ToCharArray();

            int row = convertRow(posChar[0]);
            int column = (int)char.GetNumericValue(posChar[1]);
            
            XMAX = CHESSDEFAULT;
            YMAX = CHESSDEFAULT;
            x = 1;
            y = 1;

            X = row;
            Y = column;
            //Debug.Log("X: " + X + "Y: " + Y);
        }

        public Position(Vector3 v)
        {
            XMAX = CHESSDEFAULT;
            YMAX = CHESSDEFAULT;

            x = 1;
            y = 1;

            X = (int) v.x;
            Y = (int) v.y;
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

        //grid string has format of a character (row) followed by number (column)
        //ex: A2
        public string ToGridString()
        {
            string str = "";
            str += convertRow(x);
            str += y.ToString();
            return str;
        }
        int convertRow(char row)
        {
            switch (row)
            {
                case 'A':
                    return 1;

                case 'B':
                    return 2;

                case 'C':
                    return 3;

                case 'D':
                    return 4;

                case 'E':
                    return 5;

                case 'F':
                    return 6;

                case 'G':
                    return 7;

                case 'H':
                    return 8;
                default: return -1; // PROBLEM - Occasionally sees "W" or "B" for reasons I don't understand
            }
        }
        char convertRow(int row)
        {
            switch (row)
            {
                case 1:
                    return 'A';

                case 2:
                    return 'B';

                case 3:
                    return 'C';

                case 4:
                    return 'D';

                case 5:
                    return 'E';

                case 6:
                    return 'F';

                case 7:
                    return 'G';

                case 8:
                    return 'H';
                default: return '0';
            }
        }
        //Just straight converting, not doing anything fancy like getting Unity position from grid
        public Vector3 ToSimpleVector3()
        {
            return new Vector3(X, Y, 0);
        }
    }
