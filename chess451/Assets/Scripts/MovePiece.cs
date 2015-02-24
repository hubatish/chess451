using UnityEngine;
using System.Collections;

public class MovePiece : MonoBehaviour {

	public GameObject sPiece; //Selected piece
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;


		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			if(sPiece == null) //select piece
			{
				if (Physics.Raycast (ray, out hit, 100)) 
				{
					sPiece = hit.transform.gameObject;
				}
			}
			else if (Physics.Raycast (ray, out hit, 100)) {
				newPosition.x = hit.transform.position.x;
				newPosition.y = sPiece.transform.position.y; //so that we dont fly off high
				newPosition.z = hit.transform.position.z;
				sPiece.transform.position = newPosition;
				Debug.Log (hit.transform.gameObject.name);
				sPiece = null;
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
