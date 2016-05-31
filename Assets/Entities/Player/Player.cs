using UnityEngine;
using System.Collections;

public class Player: Ship
{

      private bool _rightKey;
      private bool _leftKey;
      private bool _shootKey;
      //private int _bulletCount;

      public GameObject Bullet;
      public float FireRate = 0.2f;
     



      // Use this for initialization
      public override void Start()
      {
            ShipSpeed = 10.0f;
            MyHealth = 4;

            //Call upon the start function from the base class
            base.Start();

            //Save the X ranges of the view port
            XMinRange = AllTheWayLeft.x + Padding;
            XMaxRange = AllTheWayRight.x - Padding;
      }



      // Update is called once per frame
      public override void Update()
      {
            ShipMovement();
      }



      //Get the player input
      private void PlayerInput()
      {
            _rightKey = Input.GetKey( KeyCode.RightArrow );
            _leftKey = Input.GetKey( KeyCode.LeftArrow );
            _shootKey = Input.GetKeyDown( KeyCode.Space );
      }



      //Move the ship
      protected override void ShipMovement()
      {
            PlayerInput();

            //Check if the press key
            if ( _shootKey )
            {
                  //Repeat call the method passed as an argument
                  //InvokeRepeating( "ShootBullet", 0.000001f, FireRate );

                  //Shoot Bullet
                  ShootBullet();
            } 

            //Move right 
            if ( _rightKey )
            {
                  ShipTransform.position += Vector3.right * ( ShipSpeed * Time.deltaTime );
            }

            //Move left 
            else if ( _leftKey )
            {
                  ShipTransform.position += Vector3.left * ( ShipSpeed * Time.deltaTime );
            }

            //Base Class Ship Movement method
            base.ShipMovement();
      }



      //Shoot the bullet.
      private void ShootBullet()
      {
            Vector3 startPosition = transform.position + new Vector3( 0, 0.7f, 0 );
            Instantiate( Bullet, startPosition, Quaternion.identity );
      }



      //Keep track of the bullet count and destroy oldest one
      //private void DestroyBullet(GameObject bullet)
      //{
      //      const int bulletLimit = 0;

      //      _bulletCount++;
      //      if ( _bulletCount > bulletLimit )
      //      {
      //            Destroy( bullet, 2f );
      //      }
      //}
}
