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
            x = 1;
            y = 1;

            X = row;
            Y = column;
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
                    return 1;
                    break;

                case 'B':
                    return 2;
                    break;

                case 'C':
                    return 3;
                    break;

                case 'D':
                    return 4;
                    break;

                case 'E':
                    return 5;
                    break;

                case 'F':
                    return 6;
                    break;

                case 'G':
                    return 7;
                    break;

                case 'H':
                    return 8;
                    break;
                default: return -1; // PROBLEM - Occasionally sees "W" or "B" for reasons I don't understand
                    break;
            }
        }
        char convertRow(int row)
        {
            switch (row)
            {
                case 1:
                    return 'A';
                    break;

                case 2:
                    return 'B';
                    break;

                case 3:
                    return 'C';
                    break;

                case 4:
                    return 'D';
                    break;

                case 5:
                    return 'E';
                    break;

                case 6:
                    return 'F';
                    break;

                case 7:
                    return 'G';
                    break;

                case 8:
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
