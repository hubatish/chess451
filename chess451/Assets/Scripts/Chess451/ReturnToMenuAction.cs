using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ReturnToMenuAction : MonoBehaviour
{
    public void TakeAction()
    {
        LevelLoader.LoadLevel("NetworkingMenu");
    }
}

