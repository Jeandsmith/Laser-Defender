using UnityEngine;
using System.Collections;

public class PlayerCollisionTrigger: Ship
{

      //Check collision trigger
      private void OnTriggerEnter2D(Collider2D other)
      {
            RunCollision( other );
      }
}
