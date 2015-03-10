using UnityEngine;
using System.Collections;

public class MovePieceWhite : MonoBehaviour
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
                    Debug.Log("sweg");
                    sPiece = hit.transform.gameObject; //sPiece = selected object
                    pieceScript = (UnityPiece)sPiece.GetComponent(typeof(UnityPiece));
                }
            }
            //if piece is already selected then we move it to whatever object we click
            else if (Physics.Raycast(ray, out hit, 100) & isWhite == Turn.white_turn)
            {
                Debug.Log(sPiece.transform.gameObject.name);

                //QueensideCastle. Add the canQueensideCastle from move validation


                /// ZH 3-8, midnight
                /// Moved string parsing and convertRow functionality to Position.cs
                Position newPos = new Position(hit.transform.parent.name);
                Position oldPos = new Position(pieceScript.currentPos.name);

                Position WRook1NewPos = new Position(GameObject.Find("D1").name);
                Position WRook1OldPos = new Position(GameObject.Find("ChessPieceKnightWhite").name);

                if (sPiece.transform.gameObject.name == "ChessPieceKingWhite") // & hit.transform.gameObject.name == "ChessPieceRookWhite1") //& canQueensideCastle)
                {
                    GameObject kingDestination = GameObject.Find("C1");

                    NetworkPlayer.Instance.MovePiece(WRook1OldPos, WRook1NewPos);
                    newPos = new Position(kingDestination.name);

                }

                //XS 8:24 PM 
                //Capture piece of the opposite color if they collide.
                /*if((sPiece.collider.gameObject.tag == "WhitePiece" & hit.collider.gameObject.tag == "BlackPiece") | sPiece.collider.gameObject.tag == "BlackPiece" & hit.collider.gameObject.tag == "WhitePiece" )
                {
                    Destroy(hit.collider.gameObject);
                }*/

                //the checks give null references right now

                sPiece = null; //deselect piece after moving

                //the checks give null references right now
                NetworkPlayer.Instance.MovePiece(oldPos, newPos);
            }
        }
    } //update end

    public void TryMovePiece(Position oldPos, Position newPos)
    {
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
        Transform piece = UnityBoardSquare.GetUnityBoardSquare(oldPos).GetPieceOnSquare().transform;
        Transform newSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).transform;

        GameObject pieceOnDestSquare = UnityBoardSquare.GetUnityBoardSquare(newPos).GetPieceOnSquare();

        if (pieceOnDestSquare != null)
        {
            Transform newPiece = pieceOnDestSquare.transform;

            if ((piece.collider.gameObject.tag == "WhitePiece" & newPiece.gameObject.tag == "BlackPiece") | piece.collider.gameObject.tag == "BlackPiece" & piece.gameObject.tag == "WhitePiece")
            {
                Destroy(newPiece.gameObject);
            }
        }

        //don't change y value (ZH grab from XS 3-9, midnight)
        piece.transform.position = new Vector3(newSquare.position.x, piece.transform.position.y, newSquare.position.z);
        piece.GetComponent<UnityPiece>().SyncCurrentPosition();
        if (Turn.white_turn == true)
        {
            Turn.white_turn = false;
        }
        else
        {
            Turn.white_turn = true;
        }
    }
}
