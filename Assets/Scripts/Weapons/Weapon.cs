using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public int ammo;
    public float accuracy;
    public float range;
    public float rateOfFier;
    public GameObject projectile;
    public Transform spawnPoint;
    protected int currentAmmo;

    // Use this for initialization


    // Update is called once per frame

    abstract public void Attack();
    
    public void Reload()
    {
        //Resert currentAmmo
        currentAmmo = ammo;
    }
}
