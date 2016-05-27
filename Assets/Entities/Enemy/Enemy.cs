using UnityEngine;
using System.Collections;

public class Enemy: Ship
{
      public GameObject Bullet;


      // Use this for initialization
      public override void Start()
      {

      }



      // Update is called once per frame
      public override void Update()
      {
            float fireRate = Random.value * Time.deltaTime;

            //Invoke the bullet
            InvokeRepeating( "Shoot", 0.00001f, fireRate );
      }


      //Shoot the bullet
      private void Shoot()
      {
            Vector3 startPosition = transform.position + new Vector3( 0, -1f, 0 );
            Instantiate( Bullet, startPosition, Quaternion.identity );

            //Keep track of the bullets
            EnemyBullet myBullet = new EnemyBullet();
            myBullet.TakeBulletCount();
      }
}
