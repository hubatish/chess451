using UnityEngine;
using System.Collections;

public class TestRunner : MonoBehaviour {

    ArrayList tests;

    void Awake()
    {
        tests = new ArrayList();

        // Add Tests here
        tests.Add(new PositionTest());
    }
	// Use this for initialization
	void Start () {
        bool passed = true;
	foreach (Test test in tests)
      {
          string message;
          if (!test.run(out message))
          {
              Debug.Log(test.testname + " failed with message " + message);
              passed = false;
          }
        }
        if (passed)
        {
            Debug.Log("All Test Cases pass!");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
