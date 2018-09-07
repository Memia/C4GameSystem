using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public int ammo;
    public float accuracy;
    public float range;
    [Range(0f, 1f)]
    public float rateOfFire;
    [HideInInspector]
    public float coolDown;
    public GameObject projectile;
    public Transform spawnPoint;
    protected int currentAmmo;

    // Use this for initialization
    private void Start()
    {
       coolDown = 1 - rateOfFire;
    }

    // Update is called once per frame

    abstract public void Attack();
    
    public void Reload()
    {
        //Resert currentAmmo
        currentAmmo = ammo;
    }
}
