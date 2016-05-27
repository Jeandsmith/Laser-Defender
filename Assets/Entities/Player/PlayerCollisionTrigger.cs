using UnityEngine;
using System.Collections;

public class PlayerCollisionTrigger: Ship
{

      //Check collision trigger
      private void OnTriggerEnter2D(Collider2D other)
      {
            EnemyBullet eBullet = other.gameObject.GetComponent<EnemyBullet>();

            //Check that the player bullet is not null
            if ( eBullet != null )
            {
                  print( "I see a missile running" );
                  MyHealth -= eBullet.Damage();
                  print( "Health: " + MyHealth );

                  //Check if the player's health is at 0
                  if ( MyHealth <= 0 )
                  {
                        Destroy( gameObject );
                        MyHealth = 0;
                  }
                  eBullet.Hit();
            }
      }
}
