using UnityEngine;
using System.Collections;

public class BoardRef : MonoBehaviour {
    public Assets.Scripts.Chess451.Board b;
	// Use this for initialization
	void Start () {
        b = new Assets.Scripts.Chess451.Board();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
