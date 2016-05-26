using UnityEngine;
using System.Collections;

public class Bullet: MonoBehaviour
{
      protected float MySpeed;
      protected int MyDamage = 1;

      protected Rigidbody2D MyRigidbody;

      // Use this for initialization
      public virtual void Start()
      {
            MyRigidbody = GetComponent<Rigidbody2D>();     
      }

      // Update is called once per frame
      private void Update()
      {

      }
}
