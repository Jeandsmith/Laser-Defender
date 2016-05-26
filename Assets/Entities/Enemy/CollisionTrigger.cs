using UnityEngine;
using System.Collections;

public class CollisionTrigger : Ship {

	private void OnTriggerEnter2D(Collider2D other)
	{
            //Get the bullet component 
            PlayerBullet bullet = other.gameObject.GetComponent<PlayerBullet>();

            //Check that the player bullet is not null
            if (bullet != null)
            {
                  print( "I see a missile running" );
                  MyHealth -= bullet.Damage();
                  print("Health: " + MyHealth);

                  //Check if the player's health is at 0
                  if (MyHealth <= 0)
                  {
                        Destroy(gameObject);
                        MyHealth = 0;
                  }
                  bullet.Hit();
            }
	}
}
