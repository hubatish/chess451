using UnityEngine;
using System.Collections;

public class UnityPiece : MonoBehaviour {

	public GameObject thisPiece; //the piece the script is attached to
	public GameObject startPos; //the starting position of the piece
	public GameObject currentPos; //the piece's current position

	public void setMovePos(GameObject newPos)
	{
		this.currentPos = newPos;
	}
	// Use this for initialization
	void Start () 
	{
        startPos = GetCurrentBoardPosition();

		this.thisPiece = gameObject;
		this.currentPos = startPos;
	}

    public void SyncCurrentPosition()
    {
        currentPos = GetCurrentBoardPosition();
    }

    public GameObject GetCurrentBoardPosition()
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.up*-1);//gameObject.transform.TransformDirection(Vector3.back));

        RaycastHit hit;

        if ((Physics.Raycast(ray, out hit, 100)))
        {
            return hit.transform.parent.gameObject;
        }
        return null;
    }
	
	// Update is called once per frame
	void Update () 
	{


		//Debug.DrawRay (ray, Color.red);
	}
}
