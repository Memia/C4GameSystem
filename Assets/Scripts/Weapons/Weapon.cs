using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public int ammo = 25;
    public float reloadTime = 2.5f;
    // [HideInInspector]
    public int currentAmmo;
    public float accuracy;
    public float range;
    [Range(0f, 1f)]
    public float rateOfFire;
    [HideInInspector]
    public float coolDown;
    public GameObject projectile;
    public Transform spawnPoint;
    public bool reloading;


    // Use this for initialization
    private void Start()
    {
        coolDown = 1 - rateOfFire;
        currentAmmo = ammo;
    }

    // Update is called once per frame

    abstract public void Attack();
    private void Update()
    {
        if (reloading)
        {
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0)
            {
                reloading = false;
                Reload();
            }
        }
       
    }

    public void Reload()
    {
        currentAmmo = ammo;
        reloadTime = 2.5f;
    }
    //if (reloadTime > 0)
    //{
    //    reloading = true;
    //    reloadTime -= Time.deltaTime;
    //}
    //if (reloadTime <= 0)
    //{
    //    Resert currentAmmo
    //   currentAmmo = ammo;
    //  reloadTime = 2.5f;
    //    reloading = false;
}




