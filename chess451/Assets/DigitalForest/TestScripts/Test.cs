using UnityEngine;
using System.Collections;

public abstract class CTest  {

    public  string testname;

    /// <summary>
    /// Runs the full set of testcases for this Test Suite. First line should always set the testname of the suite
    /// </summary>
    /// <param name="message">Message to be passed back to Suite Runner. Should include details of all failed test casses, or the message "Passed" if no test case failed</param>
    /// <returns>False if atleast one testcase fails, and true otherwise</returns>
    public abstract bool run(out string message);
}
