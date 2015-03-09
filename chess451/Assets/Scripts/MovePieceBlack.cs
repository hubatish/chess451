using UnityEngine;
using System.Collections;

/// Zach Howell
/// 3-8 midnight, refactored this as it's almost exactly the same as MovePieceWhite
public class MovePieceBlack : MovePieceWhite {
    protected override void Start()
    {
        base.Start();
        //I think this is the only difference between black & white pieces?
        isWhite = false;
    }
}
