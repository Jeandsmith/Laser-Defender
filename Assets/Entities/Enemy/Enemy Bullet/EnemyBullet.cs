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
}
