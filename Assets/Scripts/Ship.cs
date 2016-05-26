using UnityEditor;
using UnityEngine;


//Ship base class
public class Ship: MonoBehaviour
{
      //Get hold off the game object's transform.
      public Transform ShipTransform;

      //Player and scene information and padding
      protected int MyHealth = 3;
      protected float ShipSpeed = 1f;
      protected float Padding = 0.5f;
      protected float XMinRange = -5f;
      protected float XMaxRange = 5f;
      protected float Distance;

      protected Vector3 AllTheWayLeft;
      protected Vector3 AllTheWayRight;


      // Use this for initialization
      public virtual void Start()
      {

            //Get the transform of this object
            ShipTransform = GetComponent<Transform>();

            //Get a hold of the camera
            Distance = ShipTransform.position.z - Camera.main.transform.position.z;
            AllTheWayLeft = Camera.main.ViewportToWorldPoint( new Vector3( 0, 0, Distance ) );
            AllTheWayRight = Camera.main.ViewportToWorldPoint( new Vector3( 1f, 0, Distance ) );
      }


      // Update is called once per frame
      public virtual void Update()
      {
    
      }


      //Ship Movement
      public virtual void ShipMovement()
      {
            //Restrict the boundaries of the player's movement to the width of the screen
            float newX = Mathf.Clamp( ShipTransform.position.x, XMinRange, XMaxRange );

            //reset the position of the ship to the game space
            ShipTransform.position = new Vector3( newX, ShipTransform.position.y, ShipTransform.position.z );
      }
}
