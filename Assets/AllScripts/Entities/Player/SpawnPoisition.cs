using UnityEngine;
using System.Collections;

public class SpawnPoisition: MonoBehaviour
{
	public GameObject PlayerGameObject;

	private void FixedUpdate()
	{
		CheckForPlayer();
	}

	//Draw gizmo
	private void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere(transform.position, 1f);
	}

	public void CheckForPlayer()
	{
		Player player = FindObjectOfType<Player>();
		if (player == null)
		{
			InstatiatePlayer(PlayerGameObject);
		}
	}

	private void InstatiatePlayer(GameObject instPlayer)
	{
		Instantiate(instPlayer, transform.position, Quaternion.identity);
	}
}
