using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


      //Load the new level
	public void LoadLevel(string name)
      {
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}


      //Quit the game 
	public void QuitRequest()
      {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
