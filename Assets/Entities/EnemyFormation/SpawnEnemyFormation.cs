using UnityEngine;
using System.Collections;

public class SpawnEnemyFormation: Ship
{

	public GameObject EnemyPrefab;


	public float _spaceWidth = 15f;
	private bool _movingRight;

	public float FormationSpeed = 5f;
	public float SpawnDelay = 0.5f;


	// Use this for initialization
	public override void Start()
	{
		base.Start();
		_movingRight = true;

		//Spawn Enemies 
		SpawnUntilFull();

		//Limit the play space movement
		Padding = 10f;

		//Left wall
		XMinRange = AllTheWayLeft.x;

		//Right wall
		XMaxRange = AllTheWayRight.x;
	}


	// Update is called once per frame
	public void Update()
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

		//Check if the formation is dead
		if ( AllEnemiesDead() )
		{
			SpawnUntilFull();
		}
	}


	//	Check if all enemies are dead
	private bool AllEnemiesDead()
	{
		int enemyCount;
		//Go through all child position object within this object
		foreach ( Transform childObject in transform )
		{
			//check if the child count is greater than 0;
			enemyCount = childObject.childCount;
			if ( enemyCount > 0 )
			{
				//Return not all enemies are dead.
				return false;
			}
		}

		//All enemies are dead.
		return true;
	}


	//Spawn until full 
	private void SpawnUntilFull()
	{
		Transform freePosition = FindNextFreePosition();

		if ( freePosition != null )
		{
			GameObject enemyCopy = Instantiate( EnemyPrefab, freePosition.transform.position,
				  Quaternion.identity ) as GameObject;

			//Set the enemy object to be spawn as a child of the position object
			enemyCopy.transform.parent = freePosition;
		}

		//Invoke this function with a time delay
		if ( FindNextFreePosition() )
		{ Invoke( "SpawnUntilFull", SpawnDelay ); }
	}


	//Spawn an enemy one by one.
	private Transform FindNextFreePosition()
	{
		foreach ( Transform freePosition in transform )
		{
			int childTransform = freePosition.childCount;
			if ( childTransform == 0 )
			{
				return freePosition.transform;
			}
		}

		//return null if the transform of this object is not empty.
		return null;
	}


	//Spawn Enemy Group
	private void SpawnFormation()
	{
		//Spawn an enemy ship on all the position's transform 
		foreach ( Transform positionChild in this.transform )
		{
			GameObject enemyCopy = Instantiate( EnemyPrefab, positionChild.transform.position,
				  Quaternion.identity ) as GameObject;

			//Set the enemy object to be spawn as a child of the position object
			enemyCopy.transform.parent = positionChild;

		}

	}


	//Draw Gizmo
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(_spaceWidth, 20f, 0));
	}

}
