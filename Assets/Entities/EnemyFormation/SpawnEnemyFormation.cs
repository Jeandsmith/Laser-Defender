using UnityEngine;
using System.Collections;

public class SpawnEnemyFormation: Ship
{

      public GameObject EnemyPrefab;


      private float _spaceWidth = 21.5f;
      private float _spaceHeight = 10f;
      private bool _movingRight;

      public float FormationSpeed = 5f;


      // Use this for initialization
      public override void Start()
      {
            base.Start();
            _movingRight = true;

            //Spawn an enemy ship on all the position's transform 
            foreach ( Transform positionChild in this.transform )
            {
                  GameObject enemyCopy = Instantiate( EnemyPrefab, positionChild.transform.position,
                        Quaternion.identity ) as GameObject;

                  //Set the enemy object to be spawn as a child of the position object
                  enemyCopy.transform.parent = positionChild;

            }

            //Limit the play space movement
            Padding = 10f;

            //Left wall
            XMinRange = AllTheWayLeft.x;

            //Right wall
            XMaxRange = AllTheWayRight.x;
      }


      //Play Space Gizmo's
      public void OnDrawGizmos()
      {
            //Create a Gizmo cube around the spawn object 
            Gizmos.DrawWireCube( this.transform.position, new Vector3( _spaceWidth, _spaceHeight ) );
      }


      // Update is called once per frame
      public override void Update()
      {
            //Player movement
            if ( _movingRight )
            {
                  transform.position += Vector3.right * ( FormationSpeed * Time.deltaTime );
            } else
            {
                  transform.position += Vector3.left * ( FormationSpeed * Time.deltaTime );
            }

            //Check if the formation is touching either side of the play space
            float rightEdgeOfFormation = ( transform.position.x + ( _spaceWidth * 0.5f ) );
            float leftEdgeOfFormation = ( transform.position.x - ( _spaceWidth * 0.5f ) );

            if ( leftEdgeOfFormation <= XMinRange )
            {
                  _movingRight = true;
            } else if ( rightEdgeOfFormation >= XMaxRange )
            {
                  _movingRight = false;
            }
      }
}
