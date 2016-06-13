using UnityEngine;
using System.Collections;

public class Bullet: MonoBehaviour
{
	protected float MySpeed;
	protected int MyDamage = 1;
	protected Rigidbody2D MyRigidbody;
	public GameObject Explosion;


	// Use this for initialization
	public virtual void Start()
	{
		MyRigidbody = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	private void Update()
	{

	}


	//Create Damage
	public virtual int Damage()
	{
		return MyDamage;
	}


	//Hit function
	public virtual void Hit()
	{
		Destroy( gameObject );
	}


	//Spawn the explosion
	protected virtual void SpawnExplosion(Vector2 position)
	{
		GameObject bulletExplosionCopy = Instantiate( Explosion, position, Quaternion.identity )
		   as GameObject;

		// Destroy the explosion prefab after it has run.
		float timeLimit = 0.9f;
		Destroy( bulletExplosionCopy, timeLimit );
	}
}
