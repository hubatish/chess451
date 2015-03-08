using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class NetworkPlayer : Singleton<NetworkPlayer>
{
    protected PhotonView photonView;
    protected void Awake()
    {
        photonView = gameObject.GetComponent<PhotonView>();
    }



    public void MovePiece(Vector3 oldPiecePos, Vector3 newPiecePos)
    {
        //PhotonNetwork.
        // [...]
        // calling the RPC somewhere else
        MoveMessages message = new MoveMessages(oldPiecePos, newPiecePos);
        photonView.RPC("OnReceiveMoveRPC", PhotonTargets.All, message.ToString());
    }

    [RPC]
    public void OnReceiveMoveRPC(string moveString)
    {
        //Debug.Log("RPC: 'OnReceiveMoveRPC' Parameter: " + moveString);
        MoveMessages message = new MoveMessages(moveString);
        Vector3 start = message.startPos;
        Vector3 end = message.endPos;
        Debug.Log("OnReceiveMoveRPC has start and end: " + start.ToString() + " , " + end.ToString());
        Debug.Log("TODO: do something with this info");
        //TODO:
        //  Make this call actually move pieces
    }
}

public class MoveMessages
{
    public Vector3 startPos, endPos;

    public MoveMessages(Vector3 start, Vector3 end)
    {
        startPos = start;
        endPos = end;
    }

    public MoveMessages(string message)
    {
        string[] vectors = message.Split(':');
        //Debug.Log("MoveMessages constructor has " + vectors.Length + " vectors");
        startPos = GetVectorFromString(vectors[0]);
        endPos = GetVectorFromString(vectors[1]);
    }

    protected Vector3 GetVectorFromString(string vString)
    {
        Vector3 v = new Vector3();
        try
        {
            string[] nums = vString.Split(',');
            /*Debug.Log("GetVecotrFromStirng has " + nums.Length + " entries");
            foreach(string s in nums)
            {
                Debug.Log("GetVectorFrom string nums array: " + s);
            }*/
            v.x = (float) Convert.ToDouble(nums[0]);
            v.y = (float) Convert.ToDouble(nums[1]);
            v.z = (float) Convert.ToDouble(nums[2]);
        }
        catch(Exception ex)
        {
            Debug.Log("exception parsing vector string " + ex.ToString());
        }
        return v;
    }

    public string ToString()
    {
        StringBuilder str = new StringBuilder("");
        AppendVector(str, startPos);
        str.Append(":");
        AppendVector(str, endPos);
        //Debug.Log("Converted Movemessage string to "+str.ToString());
        return str.ToString(); 
    }

    protected void AppendVector(StringBuilder str, Vector3 v)
    {
        str.Append(v.x.ToString());
        str.Append(",");
        str.Append(v.y.ToString());
        str.Append(",");
        str.Append(v.z.ToString());
        str.Append(",");
    }
}