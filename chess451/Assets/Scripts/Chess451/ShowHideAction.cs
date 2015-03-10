using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//While waiting for two player game to start
public class ShowHideAction : MenuAction
{
    public GameObject toShow;
    public GameObject toHide;

    protected void Start()
    {
        toShow.SetActive(false);
    }

    public override void TakeAction()
    {
        toHide.SetActive(false);
        toShow.SetActive(true);
    }
}

