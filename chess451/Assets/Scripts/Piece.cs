using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Template Pattern for Chess Pieces. Used for generic containers such as board positions and for testing.
/// Author: qtr23 batman
/// </summary>
///
/// 
public abstract class Piece
{
    Position pos;
    bool hasMoved = false;
    bool pinned; // TODO: FORKING ALGORITHM

	//setPosition commented out so that I can run the game - Xavi
    /*setPosition(Position p)
    {
    	if(!hasMoved){hasMoved = true;}
    	pos = p;
    }
	*/

    //abstract getMoves()
}
