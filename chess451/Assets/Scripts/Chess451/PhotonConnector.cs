using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhotonConnector : MonoBehaviour
{
    public GameObject loadingObject;
    public GameObject readyObject;

    protected void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        loadingObject.SetActive(true);
        readyObject.SetActive(false);
    }

    public void OnJoinedLobby()
    {
        DisplayReady();
    }

    protected void DisplayReady()
    {
        loadingObject.SetActive(false);
        readyObject.SetActive(true);
    }
}

