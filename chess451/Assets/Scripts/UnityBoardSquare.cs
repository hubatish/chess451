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

    public GameObject GetPieceOnSquare()
    {
        Ray ray = new Ray(gameObject.transform.position-Vector3.up*10, Vector3.up);

        RaycastHit[] hits = Physics.RaycastAll(ray, 100);
        Debug.Log("had " + hits.Length + "hits");
        foreach(var hit in hits)
        {
            if (hit.collider.gameObject.tag.Contains("Piece"))
            {
                return hit.transform.gameObject;
            }        
        }
        Debug.Log(gameObject.name + " found no piec");
        return null;
    }
}

