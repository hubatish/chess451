using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//While waiting for two player game to start
public class StartGameAction : MenuAction
{
    public GameObject toShow;
    public GameObject toHide;
    protected GameObject loadingScreen;

    public InputField input;

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

        //get room name from input field
        string joinName = "defaultRoom";
        if(input.text!="")
        {
            joinName = input.text.ToLower();
        }
        connector.JoinRoom(joinName);
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

