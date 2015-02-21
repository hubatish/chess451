using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class NetworkedClient : MenuAction
{
    public static string roomName = "GreatChess.1";

    public GameObject 

    public override void TakeAction()
    {
        JoinRoom();
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), new TypedLobby());
        LoadingScreen.Instance.Show();
    }

    public void OnJoinedRoom()
    {
        LoadingScreen.Instance.Hide();
        
    }

    public void Update()
    {
        Room room = PhotonNetwork.room;
        if(room!=null && room.playerCount==2)
        {
            Debug.LogError("awesome we have 2 player sin room");
        }
    }
}

