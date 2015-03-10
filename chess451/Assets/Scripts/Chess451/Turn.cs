using UnityEngine;
using System.Collections;



public class Turn : MonoBehaviour {

    public Camera wcam;
    public Camera bcam;
    public bool white_turn = true;

	// Use this for initialization
	void Start () 
    {
        white_on();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (white_turn == false)
        {
            black_on();
        }
        else
        {
            white_on();
        }
	}
    
    void white_on()
    {
        bcam.camera.active = false;
        wcam.camera.active = true;
    }

    void black_on()
    {
        wcam.camera.active = false;
        bcam.camera.active = true;
    }
   
 }

