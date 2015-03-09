using UnityEngine;
using System.Collections;

public class MovePieceBlack : MonoBehaviour {

	public GameObject sPiece; //Selected piece
	private Vector3 newPosition; //Where we move the piece
	PiecePosition pieceScript; //the position of the piece
    BoardRef boardRef;

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
	// Use this for initialization
	void Start () {
		newPosition = transform.position;
        boardRef = GameObject.FindGameObjectWithTag("BoardBase").GetComponent<BoardRef>();
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //Raycasting
		RaycastHit hit;


		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			//Select piece. We can only select a piece that has the tag "BlackPiece"
			if(sPiece == null) 
			{
				if( (Physics.Raycast (ray, out hit, 100)) & hit.collider.gameObject.tag == "BlackPiece")
				{
					sPiece = hit.transform.gameObject; //sPiece = selected object
					pieceScript = (PiecePosition) sPiece.GetComponent(typeof(PiecePosition));
				}
			}
			//if piece is already selected then we move it to whatever object we click
			else if (Physics.Raycast (ray, out hit, 100)) 
			{
                newPosition.x = hit.transform.position.x;
                char[] posChar = hit.transform.parent.name.ToCharArray();
                char[] posCharO = pieceScript.currentPos.name.ToCharArray();


                int row = convertRow(posCharO[0]);
                int column = (int)char.GetNumericValue(posCharO[1]) - 1;



                int row2 = convertRow(posChar[0]);
                int column2 = (int)char.GetNumericValue(posChar[1]) - 1;

                //Debug.Log ("Row: " + posChar[0] + " Column: " + posChar[1]);
               // Debug.Log ("Coordinates: " + row + "," + column);
                newPosition.y = sPiece.transform.position.y; //keep height of pieces constant
                newPosition.z = hit.transform.position.z;
                bool enPassant = false;
                if (boardRef.b.moveBoardPiece(row, column, row2, column2, out enPassant))
                {
                    //Call Networking with this stuff
                    //TODO: Networking and checking should probably use positions in grid coordinates rather than Unity coordinates (like A2 or [0,1] rather than things with z's and floats
                    NetworkPlayer.Instance.MovePiece(sPiece.transform.position, newPosition);
                    sPiece.transform.position = newPosition; //move piece
                    Debug.Log(hit.transform.gameObject.name);

                    pieceScript.setMovePos(hit.transform.parent.gameObject);

                    sPiece = null; //deselect piece after moving

                    if (enPassant)
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
}
