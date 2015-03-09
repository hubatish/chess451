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

        public Position(string gridString)
        {
            char[] posChar = gridString.ToCharArray();

            int row = convertRow(posChar[0]);
            int column = (int)char.GetNumericValue(posChar[1]) - 1;
            
            XMAX = CHESSDEFAULT;
            YMAX = CHESSDEFAULT;

            x = row;
            y = column;
        }

        public Position(Vector3 v)
        {
            XMAX = CHESSDEFAULT;
            YMAX = CHESSDEFAULT;

            x = (int) v.x;
            y = (int) v.y;
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
                    return 0;
                    break;

                case 'B':
                    return 1;
                    break;

                case 'C':
                    return 2;
                    break;

                case 'D':
                    return 3;
                    break;

                case 'E':
                    return 4;
                    break;

                case 'F':
                    return 5;
                    break;

                case 'G':
                    return 6;
                    break;

                case 'H':
                    return 7;
                    break;
                default: return -1;
                    break;
            }
        }
        char convertRow(int row)
        {
            switch (row)
            {
                case 0:
                    return 'A';
                    break;

                case 1:
                    return 'B';
                    break;

                case 2:
                    return 'C';
                    break;

                case 3:
                    return 'D';
                    break;

                case 4:
                    return 'E';
                    break;

                case 5:
                    return 'F';
                    break;

                case 6:
                    return 'G';
                    break;

                case 7:
                    return 'H';
                    break;
                default: return '0';
                    break;
            }
        }
        //Just straight converting, not doing anything fancy like getting Unity position from grid
        public Vector3 ToSimpleVector3()
        {
            return new Vector3(X, Y, 0);
        }
    }
