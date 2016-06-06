using UnityEngine;
using System.Collections;

public class PlayerBullet : Bullet
{

    public GameObject Explosion;

    // Use this for initialization
    public override void Start()
    {
        //Have use of the base class functions
        base.Start();
        MySpeed = 10f;
    }


    // Update is called once per frame
    private void Update()
    {
        Movement();
    }


    //Move the bullet 
    private void Movement()
    {
        MyRigidbody.velocity = new Vector2(0, MySpeed);
    }


    //Check collision with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject bulletExplosionCopy = Instantiate(Explosion, this.transform.position, Quaternion.identity)
           as GameObject;
           
        //    If there is a bullet in the scen and that scene make contact
        if (this.gameObject != null)
        {
            bulletExplosionCopy.transform.parent = this.transform;
        }
        
        // If there is not bullet in the scene, look for it and give its transform to the particle.
        else if (this == null)
        {
           GameObject myBody =  GameObject.Find("PlayerLaser");
           bulletExplosionCopy.transform.parent = myBody.transform;
        }
        
        // Destroy the explosion prefab after it has run.
        float timeLimit = 5f;
        Destroy(bulletExplosionCopy, timeLimit);
    }
}
