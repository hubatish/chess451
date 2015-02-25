using UnityEngine;
using System.Collections;

public class MovePiece : MonoBehaviour {

	public GameObject sPiece; //Selected piece
	private Vector3 newPosition; //Where we move the piece

	// Use this for initialization
	void Start () {
		newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); //Raycasting
		RaycastHit hit;


		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{

			if(sPiece == null) //select piece
			{
				if (Physics.Raycast (ray, out hit, 100)) 
				{
					sPiece = hit.transform.gameObject; //sPiece = selected object
				}
			}
			//if piece is already selected then we move it
			else if (Physics.Raycast (ray, out hit, 100)) 
			{
				newPosition.x = hit.transform.position.x;
				newPosition.y = sPiece.transform.position.y; //keep height of pieces constant
				newPosition.z = hit.transform.position.z;
				sPiece.transform.position = newPosition; //move piece
				Debug.Log (hit.transform.gameObject.name);
				sPiece = null; //deselect piece after moving
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
