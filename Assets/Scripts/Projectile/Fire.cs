using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Projectile
{


    // Use this for initialization
    void Start()
    {

    }
    public override void Travel(Vector3 direction)
    {
        //Add a force in the given 'direction' variable and use impulse
        rigid.AddForce(direction * bulletSpeed, ForceMode.Impulse);
    }
    public override void OnTriggerEnter(Collider other)
    {
        WaypointEnemy Enemy = other.GetComponent<WaypointEnemy>();
        // If it is indeed an enemy
        if (Enemy)
        {
            //Deal damage to the enemy
            Enemy.TakeDamage(damage);
            //Destroy the bullet
            Destroy(gameObject);
        }
        Destroy(gameObject);
        Instantiate(particles, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
