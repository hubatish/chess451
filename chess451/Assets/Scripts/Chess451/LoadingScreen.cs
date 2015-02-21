using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadingScreen : Singleton<LoadingScreen>
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}

