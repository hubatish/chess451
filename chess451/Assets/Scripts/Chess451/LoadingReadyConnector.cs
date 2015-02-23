using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LoadingReadyConnector : MonoBehaviour
{
    public GameObject loadingObject;
    public GameObject readyObject;

    protected PhotonConnector connector;

    protected void Start()
    {
        connector = gameObject.GetComponent<PhotonConnector>();
        if (loadingObject != null && readyObject != null)
        {
            loadingObject.SetActive(true);
            readyObject.SetActive(false);
        }
        connector.AddJoinedLobbyAction(DisplayReady);
    }

    protected void DisplayReady()
    {
        if (loadingObject != null && readyObject != null)
        {
            loadingObject.SetActive(false);
            readyObject.SetActive(true);
        }
    }
}

