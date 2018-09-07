using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    public int damage = 50;
    public float speed = 5f;
    public Rigidbody rigid;
    // Use this for initialization
    public void Fire(Vector3 direction)
    {
        //Add a force in the given 'direction' variable and use impulse
        rigid.AddForce(direction * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
 
        //Get the enemy component from it
        WaypointEnemy Enemy = other.GetComponent<WaypointEnemy>();
        // If it is indeed an enemy
        if (Enemy)
        {
            //Deal damage to the enemy
            Enemy.TakeDamage(damage);
            //Destroy the bullet
            Destroy(gameObject);
        }
        Destroy(gameObject,2.5f);
    }
}
