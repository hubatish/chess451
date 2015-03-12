using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CheckDisplay : Singleton<CheckDisplay>
{
    public GameObject checkImage;
    public GameObject mateImage;
    public GameObject blackWinImage;
    public GameObject whiteWinImage;

    public void DisplayCheck(bool display)
    {
        checkImage.SetActive(display);
    }

    public void CheckMate(PIECE_COLOR color)
    {
        mateImage.SetActive(true);
        if(color==PIECE_COLOR.BLACK)
        {
            blackWinImage.SetActive(true);
        }
        else
        {
            whiteWinImage.SetActive(true);
        }
    }
}

