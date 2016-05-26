using UnityEngine;
using System.Collections;

public class PlayerBullet : Bullet {


      
	// Use this for initialization
	public override void Start ()
      { 
            //Have use of the base class functions
            base.Start();
            MySpeed = 6f;
      }
	


	// Update is called once per frame
	private void Update ()
      {
	      Movement();
	}


      //Move the bullet 
      private void Movement()
      {
            MyRigidbody.velocity = new Vector2(0, MySpeed);      
      }


      //Inflict Damage to the collider object
      public int Damage()
      {
            //When this function is called, the Damage value will be return where it been called.
            return MyDamage;
      }


      //Hit function
      public void Hit()
      {
            Destroy(gameObject);      
      }
}
