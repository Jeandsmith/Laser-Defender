using UnityEngine;
using System.Collections;
using System.Threading;

public class EnemyBullet: Bullet
{



      // Use this for initialization
      public override void Start()
      {
            MyDamage = 1;
            MySpeed = 6f;

            base.Start();
      }



      // Update is called once per frame
      private void Update()
      {
            Move();
      }



      //Move Bullet.
      private void Move()
      {
            MyRigidbody.velocity = new Vector2( 0.0f, -MySpeed );
      }



      //Keep track of the Bullet count
      public void TakeBulletCount()
      {
            int bulletCount = 0;
            const int bulletCountLimit = 1;
            const float bulletTimeLimit = 2f;
            EnemyBullet bullet = FindObjectOfType<EnemyBullet>();

            if ( bullet != null )
            {
                  bulletCount++;
                  print( bulletCount );

                  //Destroy Bullet
                  if ( bulletCount > bulletCountLimit )
                  {
                        DestroyBullet( bullet, bulletTimeLimit );
                  }
            }

      }



      //Destroy Bullet
      private void DestroyBullet(EnemyBullet bullet, float timer)
      {
            Destroy( bullet, timer );
      }
}
