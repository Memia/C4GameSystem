using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    public int damage = 5;
    public float bulletSpeed = 20;
    public ParticleSystem particles;
    public Rigidbody rigid;

    private void Start()
    {
    }

    public virtual void Travel(Vector3 direction)
    {
            //Add a force in the given 'direction' variable and use impulse
            rigid.AddForce(direction * bulletSpeed, ForceMode.Impulse);
    }


    // Update is called once per frame
    public virtual void OnTriggerEnter(Collider other)
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

}
