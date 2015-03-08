using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Template Pattern for Chess Pieces. Used for generic containers such as board positions and for testing.
/// Author: qtr23
/// </summary>
///
/// 

public enum PIECE_COLOR
{
    WHITE, BLACK
}

//public delegate Assets.Scripts.Chess451.ThreatMap Del(Assets.Scripts.Chess451.Board x);

public abstract class Piece
{
    public PIECE_COLOR color {get;  private set;}
    Position pos;
    bool hasMoved = false;
    bool pinned; // TODO: FORKING ALGORITHM

    public Piece(PIECE_COLOR c, Position startPos)
    {
        color = c;
        pos = startPos;
    }

    public Piece()
    {
        color = PIECE_COLOR.WHITE;
        pos = new Position();
    }
	protected Position position
    {
        get { return pos; }
        set
        {
            if (!hasMoved) { hasMoved = true; }
            pos = value;
        }
    }
  
    // Delegates are so last Tuesday
    public abstract Func<Assets.Scripts.Chess451.Board, Assets.Scripts.Chess451.ThreatMap> getMoves();
   // public abstract Del getMoves();

    
}
