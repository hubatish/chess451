using UnityEngine;
using System.Collections;

public class MovePieceBlack : MovePieceWhite {
    protected override void Start()
    {
        base.Start();
        //I think this is the only difference between black & white pieces?
        isWhite = false;
    }
}
