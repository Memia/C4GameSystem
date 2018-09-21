using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    // public GameObject bullet;
    public KeyCode fireButton;

    override public void Attack()
    {

        // Instantiate a new bullet from prefab "bullet"
        GameObject clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        //Get the component from the new bullet
        Fire newBullet = clone.GetComponent<Fire>();
        ////Tell the bullet to fire()
        newBullet.Travel(transform.forward);
        currentAmmo--;
        coolDown = 1 - rateOfFire;

    }
}
