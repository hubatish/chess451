using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhotonConnector : Singleton<PhotonConnector>
{
    public static string roomName = "GreatChess.1";
    public bool autoConnectToRoom = false;

    //customizable callbacks for all these events
    private List<Action> onJoinedLobbyActions = new List<Action>();
    public void AddJoinedLobbyAction(Action action)
    {
        onJoinedLobbyActions.Add(action);
    }

    private List<Action> onJoinedRoomActions = new List<Action>();
    public void AddJoinedRoomAction(Action action)
    {
        onJoinedRoomActions.Add(action);
    }

    private List<Action> onTwoPlayersConnectedActions = new List<Action>();
    public void AddTwoPlayerConnectedAction(Action action)
    {
        onTwoPlayersConnectedActions.Add(action);
    }

    protected void Start()
    {
        if(!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings("0.1");
        }
    }

    //callback when lobby has been joined
    public void OnJoinedLobby()
    {
        foreach(Action action in onJoinedLobbyActions)
        {
            action();
        }
        if(autoConnectToRoom)
        {
            JoinRoom();
        }
    }

    //Connect to room using Photon Network
    public void JoinRoom()
    {
        JoinRoom(roomName);
    }

    public void JoinRoom(string room)
    {
        PhotonNetwork.JoinOrCreateRoom(room, new RoomOptions(), new TypedLobby());
    }

    //callback
    public void OnJoinedRoom()
    {
        foreach(Action action in onJoinedRoomActions)
        {
            action();
        }
    }

    private bool alreadyJoined = false;

    public void Update()
    {
        Room room = PhotonNetwork.room;
        if (room != null && room.playerCount == 2)
        {
            //manual check setting up OnTwoPlayer events
            if(!alreadyJoined)
            {
                alreadyJoined = true;
                foreach(Action action in onTwoPlayersConnectedActions)
                {
                    action();
                }
            }
        }
    }

}

