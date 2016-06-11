using UnityEngine;
using System.Collections;

public class Enemy: Ship
{
	public GameObject Bullet;

	public float ShotPerSeconds = 0.5f;


	public override void Start()
	{ 
		base.Start();
		MyHealth = 3;
	}
	// Update is called once per frame
	public void Update()
	{
		float shootProbability = Time.deltaTime * ShotPerSeconds;
		if ( Random.value < shootProbability )
		{
			Shoot();
		}
	}


	//Shoot the bullet
	private void Shoot()
	{
		Audio.Play();
		Vector3 newPosition = new Vector3( transform.position.x, transform.position.y - 1.15f, 0 );
		SpawnFlare( newPosition );
		Instantiate( Bullet, transform.position, Quaternion.identity );
	}
}
