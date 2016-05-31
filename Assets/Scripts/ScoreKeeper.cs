using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper: MonoBehaviour
{

      public int Score;

      private Text _myText;


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
      public void ResetScore()
      {
            Score = 0;

            //Turn the value of the score variable into a string value.
            _myText.text = Score.ToString();
      }
}
