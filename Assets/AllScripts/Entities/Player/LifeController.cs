using UnityEngine;
using System.Collections;
using System.Security.AccessControl;
using UnityEditor;

public class LifeController: MonoBehaviour
{
	//Spawning class within the life control class.
	public class PlayerRespawn: MonoBehaviour
	{
		private LifeController GetPlayer;

		public void RespawnPlayer()
		{
			GetPlayer = FindObjectOfType<LifeController>();
			SpawnPoisition spawnPoint = FindObjectOfType<SpawnPoisition>();
			Instantiate(GetPlayer.Player, spawnPoint.transform.position, Quaternion.identity);	
		}
	}

	public GameObject Player;
	public int ShipLifeCount = 3;

	//Keep track of the player's life count
	public void ReduceLive ()
	{
		print ("You have lost a life.");
		ShipLifeCount--;
		print (ShipLifeCount);
	}
}
