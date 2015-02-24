using UnityEngine;
using System.Collections;

public class MovePiece : MonoBehaviour {

	public GameObject square;
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
			if (Physics.Raycast (ray, out hit, 100)) {
				newPosition.x = hit.transform.position.x;
				newPosition.z = hit.transform.position.z;
				transform.position = newPosition;
				Debug.Log (hit.transform.gameObject.name);
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
