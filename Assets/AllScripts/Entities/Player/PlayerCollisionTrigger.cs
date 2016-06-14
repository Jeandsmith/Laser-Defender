using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine.Experimental.Director;

public class PlayerCollisionTrigger: Ship
{
	public int MyHealth1
	{
		get {return MyHealth;}
		set {MyHealth = value;}
	}


	public override void Start ()
	{
		MyHealth = 5;
	}

	//Check collision trigger
	private void OnTriggerEnter2D (Collider2D other)
	{
		EnemyBullet eBullet = other.gameObject.GetComponent<EnemyBullet> ();

		//Check that the player bullet is not null
		if (eBullet != null)
		{
			MyHealth -= eBullet.Damage ();

			//Check if the player's health is at 0
			if (MyHealth1 <= 0)
			{
				MyHealth1 = 0;
				LifeController manageLifes = FindObjectOfType<LifeController>();
				manageLifes.ReduceLive();
				if (manageLifes.ShipLifeCount == 0)
				{
					//Load the leader board scene.
					LevelManager levManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
					levManager.LoadLevel ("Leader-board");
				}
				SpawnExplosion (2f);
				Destroy (gameObject);
			}
			eBullet.Hit ();
		}
	}
}
