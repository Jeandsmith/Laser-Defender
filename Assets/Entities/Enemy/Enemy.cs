using UnityEngine;
using System.Collections;

public class Enemy: Ship
{
      public GameObject Bullet;

      public float ShotPerSeconds = 0.5f;

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
            GameObject bulletClone = Instantiate( Bullet, transform.position, Quaternion.identity ) as GameObject;
      }
}
