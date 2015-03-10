using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WhiteBlackPlayerManager : MonoBehaviour
{
    public static bool iAmWhite = true;
    public bool useLocal = false;
    public UnityBoard whitePieces;
    public UnityBoard blackPieces;

    protected void Start()
    {
        if(useLocal)
        {
            return;
        }
        whitePieces.enabled = iAmWhite;
        blackPieces.enabled = !iAmWhite;

    }
}

