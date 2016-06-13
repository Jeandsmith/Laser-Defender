using System;
using UnityEngine;
using System.Collections;

public class Position: MonoBehaviour
{
      //Implement OnDrawGizmosSelected if you want to draw gizmos when important object is selected
      public void OnDrawGizmos()
      {
            Gizmos.DrawWireSphere( transform.position, 1 );
      }
}
