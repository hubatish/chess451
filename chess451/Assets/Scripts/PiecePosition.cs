using UnityEngine;
using System.Collections;

public class PiecePosition : MonoBehaviour {

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

		Vector3 initial = gameObject.transform.TransformDirection (Vector3.back);

		Ray ray = new Ray(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.back));

		RaycastHit hit;

		if((Physics.Raycast (ray, out hit, 100)))
		  {
			this.startPos = hit.transform.parent.gameObject;
		}

		this.thisPiece = gameObject;
		this.currentPos = startPos;
	}
	
	// Update is called once per frame
	void Update () 
	{


		//Debug.DrawRay (ray, Color.red);
	}
}
