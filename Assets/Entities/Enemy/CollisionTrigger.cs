using UnityEngine;
using System.Collections;

public class CollisionTrigger: Ship
{
	private ScoreKeeper _scoreTracker;
	public int MyValue;


	public override void Start()
	{
		//Get the game object and it's component.
		_scoreTracker = FindObjectOfType<ScoreKeeper>().GetComponent<ScoreKeeper>();
		MyHealth = 2;
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		//Get the bullet component 
		PlayerBullet bullet = other.gameObject.GetComponent<PlayerBullet>();

		//Check that the player bullet is not null
		if ( bullet != null )
		{
			MyHealth -= bullet.Damage();

			//Check if the player's health is at 0
			if ( MyHealth <= 0 )
			{
                SpawnExplosion(1.2f);
				MyValue = Random.Range (Mathf.FloorToInt (150f), Mathf.FloorToInt (300f));
				_scoreTracker.MaintainScore( MyValue );
				Destroy( gameObject );
				AudioSource.PlayClipAtPoint( DeadClip, transform.position );
				MyHealth = 0;
			}
			bullet.Hit();
		}
	}
}
