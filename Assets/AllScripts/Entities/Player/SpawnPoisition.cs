using UnityEngine;
using System.Collections;

public class SpawnPoisition: MonoBehaviour
{
	//private Player _playerShip = null;

	//private void Update()
	//{
	//	CheckForPlayer();	
	//}

	////Check if the player is in the scene
	//private void CheckForPlayer()
	//{
	//	if (_playerShip == null)
	//	{
	//		Instantiate(_playerShip, transform.position, Quaternion.identity);
	//	}else if (_playerShip.GetInstanceID() != _playerShip.gameObject.GetInstanceID())
	//	{
	//		Destroy(_playerShip.gameObject);
	//	}
	//}

	//Draw gizmo
	private void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere(transform.position, 1f);
	}
}
