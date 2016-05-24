using UnityEngine;
using System.Collections;

public class Player : Ship {

	private bool _rightKey;
	private bool _leftKey;


	// Use this for initialization
	public override void Start () 
	{
            ShipSpeed = 10.0f;
        
            //Call upon the start function from the base class
		base.Start();

            //Save the X ranges of the view port
            XMinRange = AllTheWayLeft.x + Padding;
            XMaxRange = AllTheWayRight.x - Padding;
      }



	// Update is called once per frame
	public override void Update () 
	{
		ShipMovement();
	}



	//Get the player input
	void PlayerInput()
	{
		_rightKey = Input.GetKey(KeyCode.RightArrow);
		_leftKey = Input.GetKey(KeyCode.LeftArrow);
	}



	//Move the ship
	public override void ShipMovement()
	{
		PlayerInput();

		//Move right 
		if (_rightKey)
		{
			ShipTransform.position += Vector3.right * (ShipSpeed * Time.deltaTime);
		}

		//Move left 
		else if (_leftKey)
		{
			ShipTransform.position += Vector3.left * (ShipSpeed * Time.deltaTime);
		}

            //Base Class Ship Movement method
            base.ShipMovement();
	}
}
