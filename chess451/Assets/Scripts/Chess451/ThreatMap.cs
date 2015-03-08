using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Chess451
{
    public class ThreatMap
    {
        bool[,] map;


        public    ThreatMap()
        {
                map = new bool [8,8];
                for (int i= 0; i < 8 ; i++ )
                {
                    for (int j = 0; j < 8; j++)
                    {
                        map[i, j] = false;
                    }
                }
        }
        
        
        
        
        public void SetSpot(int x, int y, bool canMove)
        {
            map[x,y] = canMove;
        }
        public bool GetSpot(int x, int y)
        {
            return map[x, y];
        }

    }
}
