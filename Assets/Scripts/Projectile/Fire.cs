using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//By the way it's not a good way to code flame throwers... I just did it cus lols
public class Fire : Projectile
{


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, .3f);
        Instantiate(particles, transform.position, transform.rotation);
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

            Enemy.TakeDamage(damage);

        }


    }

}
