using UnityEngine;

//Application.LoadLevel seems to cause issues with Unity GUI.  Deleting all the files seems to fix it
//Nevermind it was secretly a bug with my singleton class
public class LevelLoader: MonoBehaviour{
	public static void LoadNextLevel(){
		foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>()) {
		//	Destroy(go);
		}
		Application.LoadLevel (Application.loadedLevel+1);
	}

	public static void RestartLevel(){
		foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>()) {
		//	Destroy(go);
		}
		Application.LoadLevel (Application.loadedLevel);
	}

	public static void LoadLevel(string sceneName){
		foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>()) {
			//Destroy(go);
		}
		Application.LoadLevel (sceneName);
	}
}