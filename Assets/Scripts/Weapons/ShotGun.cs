using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    public float spread = 5f;
    public int pellets = 6;
    // Use this for initialization


public override void Attack()
    {
        //Store forward direction of player
        Vector3 direction = transform.forward;

        //Calculate offset by using range
        Vector3 spread = Vector3.zero;
        //Offsert on local Y
        spread += transform.up * Random.Range(-accuracy, accuracy);
        spread += transform.right * Random.Range(-accuracy, accuracy);

        // Instantiate a new bullet from prefab "bullet"
        GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
        //Get the component from the new bullet
        Bullet newBullet = clone.GetComponent<Bullet>();
        //Tell the bullet to fire()
        newBullet.Fire(direction + spread);
    }

}
