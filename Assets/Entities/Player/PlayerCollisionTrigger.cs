using UnityEngine;
using System.Collections;

public class PlayerCollisionTrigger : Ship
{

    //Check collision trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyBullet eBullet = other.gameObject.GetComponent<EnemyBullet>();

        //Check that the player bullet is not null
        if (eBullet != null)
        {
            MyHealth -= eBullet.Damage();

            //Check if the player's health is at 0
            if (MyHealth <= 0)
            {
                SpawnExplosion(2f);
                Destroy(gameObject);
                LevelManager levManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                levManager.LoadLevel("Leader-board");
                MyHealth = 0;
            }
            eBullet.Hit();
        }
    }
}
