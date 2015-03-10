using UnityEngine;
using System.Collections;

public class MovePieceWhite : MonoBehaviour {
	public GameObject sPiece; //Selected piece
	private Vector3 newPosition; //Where we move the piece
	UnityPiece pieceScript; //the position of the piece
    BoardRef boardRef;

    public bool isWhite = true;
    private string GetColliderTag()
    {
        if(isWhite)
        {
            return "WhitePiece";
        }
        else
        {
            return "BlackPiece";
        }
    }

	// Use this for initialization
	protected virtual void Start () {
		newPosition = transform.position;
        boardRef = GameObject.FindGameObjectWithTag("BoardBase").GetComponent<BoardRef>();
	}

	// Update is called once per frame
	void Update () {
		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //Raycasting
		RaycastHit hit;
		
		
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			//Select piece. We can only select a piece that has the tag "WhitePiece"
			if(sPiece == null) 
			{
				if( (Physics.Raycast (ray, out hit, 100)) & hit.collider.gameObject.tag == GetColliderTag())
				{
					sPiece = hit.transform.gameObject; //sPiece = selected object
					pieceScript = (UnityPiece) sPiece.GetComponent(typeof(UnityPiece));
				}
			}
			//if piece is already selected then we move it to whatever object we click
			else if (Physics.Raycast (ray, out hit, 100)) 
			{
				Debug.Log(sPiece.transform.gameObject.name);
				//newPosition.x = hit.transform.position.x;
				newPosition.y = sPiece.transform.position.y; //keep height of pieces constant
				//newPosition.z = hit.transform.position.z;

				//QueensideCastle. Add the canQueensideCastle from move validation


                /// ZH 3-8, midnight
                /// Moved string parsing and convertRow functionality to Position.cs
                Position newPos = new Position(hit.transform.parent.name);
                Position oldPos = new Position(pieceScript.currentPos.name);

				Position WRook1NewPos = new Position(GameObject.Find("D1").name);
				Position WRook1OldPos = new Position(GameObject.Find("ChessPieceKnightWhite").name);

				if(sPiece.transform.gameObject.name == "ChessPieceKingWhite") // & hit.transform.gameObject.name == "ChessPieceRookWhite1") //& canQueensideCastle)
				{
					GameObject kingDestination = GameObject.Find("C1");

					NetworkPlayer.Instance.MovePiece(WRook1OldPos,WRook1NewPos);
					newPos = new Position(kingDestination.name);

				}

                bool enPassant = false;
	
				//XS 8:24 PM 
				//Capture piece of the opposite color if they collide.
				if((sPiece.collider.gameObject.tag == "WhitePiece" & hit.collider.gameObject.tag == "BlackPiece") | sPiece.collider.gameObject.tag == "BlackPiece" & hit.collider.gameObject.tag == "WhitePiece" )
				{
					Destroy(hit.collider.gameObject);
				}

                //the checks give null references right now

                if(boardRef.b.moveBoardPiece(oldPos,newPos, out enPassant))

               // if(boardRef.b.moveBoardPiece(oldPos,newPos, out enPassant))

                {
				   NetworkPlayer.Instance.MovePiece(oldPos,newPos);

				    sPiece = null; //deselect piece after moving

                    if(enPassant)
                    {
                        // TODO: Code to remove en Pessanted piece
                    }
                } 
			}
		}
	}

    //Update the 3d board with the piece movement
    public void OfficiallyMovePiece(Position oldPos, Position newPos)
    {
        //Debug.Log("officially moving from  " + oldPos.ToGridString() + " to " + newPos.ToGridString());
        
        Transform piece = UnityBoardSquare.GetUnityBoardSquare(oldPos).GetPieceOnSquare().transform;
        Transform newSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).transform;
        piece.transform.position = newSquare.position;
        piece.GetComponent<UnityPiece>().SyncCurrentPosition();
    } 
}
