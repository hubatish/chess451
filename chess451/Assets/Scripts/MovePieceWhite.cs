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
		default : return -1;
			break;
		}
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
				newPosition.x = hit.transform.position.x;

                /// ZH 3-8, midnight
                /// Moved string parsing and convertRow functionality to Position.cs
                Position newPos = new Position(hit.transform.parent.name);
                Position oldPos = new Position(pieceScript.currentPos.name);

				//Debug.Log ("Row: " + posChar[0] + " Column: " + posChar[1]);
				//Debug.Log ("Coordinates: " + row + "," + column);
				newPosition.y = sPiece.transform.position.y; //keep height of pieces constant
				newPosition.z = hit.transform.position.z;
                bool enPassant = false;
                //if(boardRef.b.moveBoardPiece(oldPos,newPos, out enPassant))
                {
				    //Call Networking with this stuff
				    //TODO: Networking and checking should probably use positions in grid coordinates rather than Unity coordinates (like A2 or [0,1] rather than things with z's and floats
				    NetworkPlayer.Instance.MovePiece(oldPos,newPos);
				    //sPiece.transform.position = newPosition; //move piece
				    //Debug.Log (hit.transform.gameObject.name);

				    //pieceScript.setMovePos(hit.transform.parent.gameObject);

				    sPiece = null; //deselect piece after moving

                    if(enPassant)
                    {
                        // TODO: Code to remove en Pessanted piece
                    }
                }
			}
		}
		/*
		if(Input.GetKeyDown (KeyCode.Mouse0))
		{
			if (Input.GetMouseButtonDown (0))
			{
				newPosition.x = square.transform.position.x;
				newPosition.z = square.transform.position.z;
				transform.position = newPosition;
			}
		} */
	}

    //Update the 3d board with the piece movement
    public void OfficiallyMovePiece(Position oldPos, Position newPos)
    {
        Debug.Log("officially moving from  " + oldPos.ToGridString() + " to " + newPos.ToGridString());
        
        Transform piece = UnityBoardSquare.GetUnityBoardSquare(oldPos).GetPieceOnSquare().transform;
        Transform newSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).transform;
        piece.transform.position = newSquare.position;
        piece.GetComponent<UnityPiece>().SyncCurrentPosition();
    }
}
