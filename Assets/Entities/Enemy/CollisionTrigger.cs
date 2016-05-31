using UnityEngine;
using System.Collections;

public class CollisionTrigger: Ship
{
      private ScoreKeeper ScoreTracker;
      public int MyValue = 154;



      public override void Start()
      {
            ScoreTracker = GetComponent<ScoreKeeper>();
      }



      private void OnTriggerEnter2D(Collider2D other)
      {
            //Get the bullet component 
            PlayerBullet bullet = other.gameObject.GetComponent<PlayerBullet>();

            //Check that the player bullet is not null
            if ( bullet != null )
            {
                  MyHealth -= bullet.Damage();
                  print( "Health: " + MyHealth );

                  //Check if the player's health is at 0
                  if ( MyHealth <= 0 )
                  {
                        ScoreTracker.MaintainScore(MyValue);
                        Destroy( gameObject );
                        MyHealth = 0;
                  }
                  bullet.Hit();
            }
      }
}
