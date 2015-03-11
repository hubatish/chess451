using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UnityBoardSquare : MonoBehaviour
{
    public static UnityBoardSquare GetUnityBoardSquare(Position position)
    {
        string name = position.ToGridString();
        //Debug.Log("name of position " + name);
        GameObject g = GameObject.Find(name);
        if(g==null)
        {
            return null;
        }
        else
        {
            return g.GetComponent<UnityBoardSquare>();
        }
    }


	void Update()
	{
		Debug.DrawLine (gameObject.transform.position - (Vector3.up*1),gameObject.transform.position - (Vector3.up*1)+ Vector3.up,Color.green);
	}

    public GameObject GetPieceOnSquare()
    {
        Ray ray = new Ray(gameObject.transform.position-Vector3.up*1, Vector3.up);

        RaycastHit[] hits = Physics.RaycastAll(ray, 100);
        foreach(var hit in hits)
        {
            if (hit.collider.gameObject.tag.Contains("Piece"))
            {
				Debug.Log ("found piece: " + hit.transform.gameObject.name);
                return hit.transform.gameObject;
            }        
        }

	
        return null;
    }
}

