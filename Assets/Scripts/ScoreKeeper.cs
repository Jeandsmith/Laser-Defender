using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper: MonoBehaviour
{

	public static int Score;

	private Text _myText;

	//Run only once
	public void Start()
	{
		_myText = GetComponent<Text>();
	}


	//Keep Track of the score
	public void MaintainScore(int points)
	{
		Score += points;
		_myText.text = Score.ToString();
	}


	//Reset
	public static void ResetScore()
	{
		Score = 0;
	}
}
