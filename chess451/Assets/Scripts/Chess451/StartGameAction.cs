using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//While waiting for two player game to start
public class StartGameAction : MenuAction
{
    public GameObject toShow;
    public GameObject toHide;
    public GameObject loadingScreen;

    private PhotonConnector connector;
    protected void Start()
    {
        connector = PhotonConnector.Instance;
        toShow.SetActive(false);
        loadingScreen = LoadingScreen.Instance.gameObject;
    }

    public override void TakeAction()
    {
        toHide.SetActive(false);
        loadingScreen.SetActive(true);
        connector.AddTwoPlayerConnectedAction(OnTwoPlayers);
        connector.AddJoinedRoomAction(OnRoomEnter);
        connector.JoinRoom();
    }

    public void OnRoomEnter()
    {
        toShow.SetActive(true);
        loadingScreen.SetActive(false);
    }

    public void OnTwoPlayers()
    {
        LevelLoader.LoadNextLevel();
    }
}

