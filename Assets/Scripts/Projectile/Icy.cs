using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icy : Fire
{
    public float slowDown = 0.5f;
    public float timer = 3f;
    public float intialTimer;
    public bool frozen = false;
   public WaypointEnemy enemy;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, .3f);
        Instantiate(particles, transform.position, transform.rotation);
        intialTimer = timer;
       enemy = enemy.GetComponent<WaypointEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (frozen)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            frozen = false;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
       // WaypointEnemy enemy = other.GetComponent<WaypointEnemy>();
        // If it is indeed an enemy
        if (enemy)
        {

            frozen = true;
            enemy.TakeDamage(damage);
         
        }
    }
    void Freeze()
    {
        if (frozen = true)
        {
            timer = intialTimer;
            enemy.agent.speed = slowDown;
        }

        if (frozen = false)
        {
            Debug.Log("sad");
            enemy.agent.speed = enemy.initialSpeed;
        }
    }

}
