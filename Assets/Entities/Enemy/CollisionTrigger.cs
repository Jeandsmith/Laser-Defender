﻿using UnityEngine;
using System.Collections;

public class CollisionTrigger: Ship
{

      private void OnTriggerEnter2D(Collider2D other)
      {
            RunCollision( other );
      }
}
