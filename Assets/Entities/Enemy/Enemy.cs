using UnityEngine;
using System.Collections;

public class Enemy: Ship
{
      public GameObject Bullet;

      public float ShotPerSeconds = 0.5f;
      // Use this for initialization
      public override void Start()
      {

      }



      // Update is called once per frame
      public override void Update()
      {
            float shootProbability = Time.deltaTime * ShotPerSeconds;

            if(Random.value < shootProbability)
            {
                  Shoot();
            }
      }


      //Shoot the bullet
      private void Shoot()
      {
            Vector3 startPosition = transform.position + new Vector3( 0, -1f, 0 );
            GameObject bulletClone = Instantiate( Bullet, startPosition, Quaternion.identity ) as GameObject;
      }
}
