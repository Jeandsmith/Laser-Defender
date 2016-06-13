using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine.Experimental.Director;

public class PlayerCollisionTrigger: Ship
{
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
			if (MyHealth <= 0)
			{
				MyHealth = 0;

				//Trying to spawn the player afte the player have been destroy.
				//There is a problems spawning the player after destroy. My hypothesis is that i cant access the script after
				//The ship have been destroy.
				LifeController manageLifes = FindObjectOfType<LifeController> ();
				manageLifes.ReduceLive ();
				if (manageLifes.ShipLifeCount != 0)
				{
					print ("Re-spawning Player");
					LifeController.PlayerRespawn pRespawn = GameObject.Find ("LifeController").GetComponent
						<LifeController.PlayerRespawn> ();
					pRespawn.RespawnPlayer ();
					Destroy (gameObject);
				}
				
				//This piece of code is working properly. 
				else if (manageLifes.ShipLifeCount == 0)
				{
					//Load the leader board scene.
					LevelManager levManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
					levManager.LoadLevel ("Leader-board");
				}
				SpawnExplosion (2f);
			}
			eBullet.Hit ();
		}
	}
}
