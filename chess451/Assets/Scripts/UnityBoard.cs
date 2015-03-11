﻿using UnityEngine;
using System.Collections;

public class UnityBoard : MonoBehaviour
{
    public GameObject sPiece; //Selected piece
    UnityPiece pieceScript; //the position of the piece
    BoardRef boardRef;

    public bool isWhite = true;
    private string GetColliderTag()
    {
        if (isWhite)
        {
            return "WhitePiece";
        }
        else
        {
            return "BlackPiece";
        }
    }

    // Use this for initialization
    protected virtual void Start()
    {
        boardRef = GameObject.FindGameObjectWithTag("BoardBase").GetComponent<BoardRef>();
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Raycasting
        RaycastHit hit;


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Select piece. We can only select a piece that has the tag "WhitePiece"
            if (sPiece == null)
            {
                if ((Physics.Raycast(ray, out hit, 100)) & hit.collider.gameObject.tag == GetColliderTag())
                {
                    sPiece = hit.transform.gameObject; //sPiece = selected object
                    pieceScript = (UnityPiece)sPiece.GetComponent(typeof(UnityPiece));
                }
            }
            //if piece is already selected then we move it to whatever object we click
            else if (Physics.Raycast(ray, out hit, 100) & isWhite == Turn.white_turn)
            {

                //QueensideCastle. Add the canQueensideCastle from move validation


                /// ZH 3-8, midnight
                /// Moved string parsing and convertRow functionality to Position.cs
                Position newPos = new Position(hit.transform.parent.name);
                Position oldPos = new Position(pieceScript.currentPos.name);

                //the checks give null references right now

                sPiece = null; //deselect piece after moving

                //the checks give null references right now
                NetworkPlayer.Instance.MovePiece(oldPos, newPos);
            }
        }
    } //update end

    public void TryMovePiece(Position oldPos, Position newPos)
    {
        //Debug.Log("Try Move got called with " + oldPos.ToGridString() + " to " + newPos.ToGridString() + " board ref is " + boardRef.ToString());
        bool enPassant = false;
        //Debug.Log("officially moving from  " + oldPos.ToGridString() + " to " + newPos.ToGridString());
        if (boardRef.b.moveBoardPiece(oldPos, newPos, out enPassant))
        {
            OfficiallyMovePiece(oldPos, newPos);
            if (enPassant)
            {
                // TODO: Code to remove en Pessanted piece
            }
        }

    }

    //Update the 3d board with the piece movement
    public void OfficiallyMovePiece(Position oldPos, Position newPos)
    {
        //Debug.Log("officially moving some pieces from " + oldPos.ToGridString() + " to " + newPos.ToGridString());
        Transform piece = UnityBoardSquare.GetUnityBoardSquare(oldPos).GetPieceOnSquare().transform;
        Transform newSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).transform;

        GameObject pieceOnDestSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).GetPieceOnSquare();

        if (pieceOnDestSquare != null) {
			Transform newPiece = pieceOnDestSquare.transform;
			Debug.Log ("NewPiece: " + newPiece.gameObject.name);

			if ((piece.collider.gameObject.tag == "WhitePiece" & newPiece.gameObject.tag == "BlackPiece") | piece.collider.gameObject.tag == "BlackPiece" & newPiece.gameObject.tag == "WhitePiece") {
				//Capture a piece
				Destroy (newPiece.gameObject);
			}
		
            //else 
			//{
                //ZH Moved XS Castling code to be shared for networking

			//White Pieces

			//Queenside castle
			if (piece.gameObject.name == "ChessPieceKingWhite" & newPiece.gameObject.name == "ChessPieceRookWhite1") //& canQueensideCastle)
			{
				Position WRook1NewPos = new Position("D1");
				Position WRook1OldPos = new Position("A1");
				GameObject kingDestination = GameObject.Find("C1");
				
				OfficiallyMovePiece(WRook1OldPos, WRook1NewPos);
				newPos = new Position("C1");
				
				newSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).transform;
			}    


			//Kingside Castle
				if (piece.gameObject.name == "ChessPieceKingWhite"  & newPiece.gameObject.name == "ChessPieceRookWhite") //& canKingsideCastle)
			{
				Position WRook1NewPos = new Position("F1");
				Position WRook1OldPos = new Position("H1");
				GameObject kingDestination = GameObject.Find("C1");
				
				OfficiallyMovePiece(WRook1OldPos, WRook1NewPos);
				newPos = new Position("G1");
				
				newSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).transform;
			} 
		
			//Black Pieces

			//Queenside castle
			if (piece.gameObject.name == "ChessPieceKingBlack"  & newPiece.gameObject.name == "ChessPieceRookBlack1") //& canQueensideCastle)
			{
				Position BRook1NewPos = new Position("D8");
				Position BRook1OldPos = new Position("A8");
				GameObject kingDestination = GameObject.Find("C1");
				
				OfficiallyMovePiece(BRook1OldPos, BRook1NewPos);
				newPos = new Position("C8");
				
				newSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).transform;
			} 
			  
		
				
			//Kingside Castle
			if (piece.gameObject.name == "ChessPieceKingBlack"  & newPiece.gameObject.name == "ChessPieceRookBlack") //& canKingsideCastle)
			{
				Position BRook1NewPos = new Position("F8");
				Position BRook1OldPos = new Position("H8");
				
				OfficiallyMovePiece(BRook1OldPos, BRook1NewPos);
				newPos = new Position("G8");
				
				newSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).transform;
			} 
                
            //}
        }

			
		


		
		//don't change y value (ZH grab from XS 3-9, midnight)
		piece.transform.position = new Vector3(newSquare.position.x, piece.transform.position.y, newSquare.position.z);
        piece.GetComponent<UnityPiece>().SyncCurrentPosition();
        Turn.white_turn = !Turn.white_turn;
    }
}
