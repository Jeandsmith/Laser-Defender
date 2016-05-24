using UnityEngine;
using System.Collections;

public class SpawnEnemyFormation: Ship
{

      public GameObject EnemyPrefab;


      public float _spaceWidth = 10f;
      private float _spaceHeight = 10f;
      private float _formationSPeed = 5f;
      private bool _movingRight;


      // Use this for initialization
      public override void Start()
      {
            base.Start();
            _movingRight = true;

            //Spawn an enemy ship on all the position's transform 
            foreach ( Transform positionChild in transform )
            {
                  GameObject enemyCopy = Instantiate( EnemyPrefab, positionChild.transform.position,
                        Quaternion.identity ) as GameObject;

                  //Set the enemy object to be spawn as a child of the position object
                  enemyCopy.transform.parent = positionChild;

            }

            //Limit the play space movement
            Padding = 10f;
            XMinRange = AllTheWayLeft.x;
            XMaxRange = AllTheWayRight.x; 
      }


      //Play Space Gizmo's
      public void OnDrawGizmos()
      {
            //Create a Gizmo cube around the spawn object 
            Gizmos.DrawWireCube(transform.position, new Vector3(_spaceWidth, _spaceHeight));     
      }


      // Update is called once per frame
      public override void Update()
      {
            if ( _movingRight )
            {
                  transform.position += Vector3.right * ( _formationSPeed * Time.deltaTime );


            } else
            {
                  transform.position += Vector3.left * ( _formationSPeed * Time.deltaTime );
            }   

            //Ship Movement
            float rightEdgeOfFormation = ( transform.position.x + ( _spaceWidth * 0.5f ) );
            float leftEdgeOfFormation = ( transform.position.x - ( _spaceWidth * 0.5f ) );

            if ( (leftEdgeOfFormation < XMinRange) || (rightEdgeOfFormation > XMaxRange) )
            {
                  _movingRight = !_movingRight;
                       
            }
      }
}
