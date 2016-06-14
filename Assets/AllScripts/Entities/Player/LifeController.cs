using UnityEngine;
using System.Collections;
using System.Security.AccessControl;
using UnityEditor;

public class LifeController: MonoBehaviour
{
	public int ShipLifeCount = 3;

	private void Start()
	{

	}

	//Keep track of the player's life count
	public void ReduceLive ()
	{
		print ("You have lost a life.");
		ShipLifeCount--;
		print (ShipLifeCount);
	}
}
