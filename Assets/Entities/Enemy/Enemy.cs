using UnityEngine;
using System.Collections;

public class Enemy : Ship
{
     
	// Use this for initialization
	public override void Start ()
      {
            //Get the transform of this object
	      ShipTransform = GetComponent<Transform>();      
	}
	


	// Update is called once per frame
	public override void Update ()
      {
	
	}
}
