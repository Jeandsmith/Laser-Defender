using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreLeaderboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	      Text myText = GetComponent<Text>();
            myText.text = ScoreKeeper.Score.ToString();
            ScoreKeeper.ResetScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
