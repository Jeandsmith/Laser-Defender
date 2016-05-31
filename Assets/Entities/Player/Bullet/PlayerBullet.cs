using UnityEngine;
using System.Collections;

public class PlayerBullet : Bullet {


      
	// Use this for initialization
	public override void Start ()
      { 
            //Have use of the base class functions
            base.Start();
            MySpeed = 10f;
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
}
