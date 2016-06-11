using UnityEngine;
using System.Collections;
using System.Security.AccessControl;

public class LifeController: MonoBehaviour
{
	private Player _player;
	private GameObject _playerLife;
	// Use this for initialization
	void Start ()
	{
		_player = FindObjectOfType<Player> ();
	}

	// Update is called once per frame
	void Update ()
	{
		KeepTrackOfHealth ();
	}

	//Keep track of the player's health
	private void KeepTrackOfHealth ()
	{
		//Instantiate all the players health image
		int i = 0;
		while (i <= _player.MyHealth1)
		{
			i++;
			_playerLife = Instantiate (gameObject, transform.position + new Vector3 (25f, 0, 0),
				Quaternion.identity) as GameObject;
		}
	}

	//Take down health 
	public void TakeDownLife (GameObject life)
	{
		Destroy (life);
	}
}
