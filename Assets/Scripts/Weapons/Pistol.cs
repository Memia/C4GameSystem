using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
   // public GameObject bullet;
    public KeyCode fireButton;

    // Use this for initialization

    // Update is called once per frame

    override public void Attack()
    {
        // Instantiate a new bullet from prefab "bullet"
        GameObject clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        //Get the component from the new bullet
        Bullet newBullet = clone.GetComponent<Bullet>();
        //Tell the bullet to fire()
        newBullet.Fire(transform.forward);
    }
}
