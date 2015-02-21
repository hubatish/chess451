using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Photon;

public class NetworkHost : UnityEngine.MonoBehaviour
{
/*    protected void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");   
    }

    private const string roomName = "RoomName";
    private RoomInfo[] roomsList;*/

    void OnGUI()
    {
        if (!PhotonNetwork.connected)
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }
/*        else if (PhotonNetwork.room == null)
        {
            // Create Room
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
                PhotonNetwork.CreateRoom(roomName + Guid.NewGuid().ToString("N"));
 
            // Join Room
            if (roomsList != null)
            {
                for (int i = 0; i < roomsList.Length; i++)
                {
                    if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].name))
                        PhotonNetwork.JoinRoom(roomsList[i].name);
                }
            }
        }*/
    }

/*    void OnReceivedRoomListUpdate()
    {
        roomsList = PhotonNetwork.GetRoomList();
    }
    void OnJoinedRoom()
    {
        Debug.Log("Connected to Room");
        Invoke("CreateObject", 1f);
    }

    protected void CreateObject()
    {
        PhotonNetwork.Instantiate("ColorPlayer", Vector3.zero, Quaternion.identity, 0);
    }*/
}

