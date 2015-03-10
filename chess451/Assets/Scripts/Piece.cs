using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
    protected Position pos;
    public bool hasMoved { get; protected set; }
    bool pinned; // TODO: FORKING ALGORITHM

    public Piece(PIECE_COLOR c, Position startPos)
    {
        color = c;
        pos = new Position();
        pos.X = startPos.X;
        pos.Y = startPos.Y;
        hasMoved = false;
    }

    public Piece()
    {
        color = PIECE_COLOR.WHITE;
        pos = new Position();
        hasMoved = false;
    }
	virtual public Position position
    {
        get { return pos; }
        protected set
        {
            UnityEngine.Debug.Log("beep");
            if (!hasMoved) { hasMoved = true; }
            pos = value;
        }
    }
  
    // Delegates are so last Tuesday
    public abstract Func<Assets.Scripts.Chess451.Board, Assets.Scripts.Chess451.ThreatMap> getMoves();
   // public abstract Del getMoves();

    protected void AddToListInDirection(List<Position> positions, Position startPos, int xOffset, int yOffset, Assets.Scripts.Chess451.Board board)
    {
        Position p2 = new Position();
        p2.X = startPos.X + xOffset;
        p2.Y = startPos.Y + yOffset;
        bool found = false;
        while (!found && !p2.Failed())
        {
            if (!Object.Equals(board.getBoardPiece(p2), null))
            {
                found = true;
            }
            positions.Add(p2);

            //create a new Position for the next entry in list
            Position oldP = p2;
            p2 = new Position();
            p2.X = oldP.X + xOffset;
            p2.Y = oldP.Y + yOffset;
        }
    }
    
}
