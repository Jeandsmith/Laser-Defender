
using UnityEngine;
using System.Collections;


//Ship base class
public class Ship : MonoBehaviour
{
    //Get hold off the game object's transform.
    public Transform ShipTransform;
    public GameObject Explosion;
    public AudioClip DeadClip;
    public GameObject Flare;
    protected AudioSource Audio;

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

        //Get the audio source
        Audio = GetComponent<AudioSource>();

        //Get a hold of the camera
        Distance = ShipTransform.position.z - Camera.main.transform.position.z;
        AllTheWayLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Distance));
        AllTheWayRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0, Distance));
    }


    //Ship Movement
    protected virtual void ShipMovement()
    {
        //Restrict the boundaries of the player's movement to the width of the screen
        float newX = Mathf.Clamp(ShipTransform.position.x, XMinRange, XMaxRange);

        //reset the position of the ship to the game space
        ShipTransform.position = new Vector3(newX, ShipTransform.position.y, ShipTransform.position.z);
    }

    //Call upon the ship flare.
    protected void SpawnFlare(Vector3 position)
    {
        GameObject flareCopy = Instantiate(Flare, position, Quaternion.identity) as GameObject;
        if (flareCopy != null)
        {
            //Set the parent of this object.
            flareCopy.transform.parent = transform;
            Animator shipBarrel = flareCopy.GetComponent<Animator>();
            shipBarrel.SetTrigger("Shoot");
            Destroy(flareCopy, 0.25f);
        }
    }

    // Spawn the explosion after the ship is destroy
    protected void SpawnExplosion(float timer)
    {
        GameObject explosionCopy = Instantiate(Explosion, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(explosionCopy, timer);
    }
}
