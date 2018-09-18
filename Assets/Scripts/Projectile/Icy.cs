using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icy : Fire
{
    [Header("SlowDownProperty")]
    public float frozeness;
    public float frozenTime = 2f;
    public bool frozen = false;


    public float initialSpeed;

    private WaypointEnemy enemy;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, .3f);
        Instantiate(particles, transform.position, transform.rotation);
        initialSpeed = enemy.agent.speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnTriggerEnter(Collider other)
    {
        // Tell the enemy that they're frozen and by a certain value

        enemy = other.GetComponent<WaypointEnemy>();
        // If it is indeed an enemy
        if (enemy)
        {
            enemy.TakeDamage(damage);
            frozeness += 0.1f;

        }
        if (frozeness >= 2f)
        {
            StartCoroutine("Freeze");
        }
    }

    IEnumerator Freeze()
    {

        frozen = true;
        enemy.agent.speed = 0;
        yield return new WaitForSeconds(frozenTime);
        frozen = false;
        enemy.agent.speed = initialSpeed;
        frozeness = 0;
    }

}
