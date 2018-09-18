using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WaypointEnemy : MonoBehaviour

{
    Bullet bullet;
    public float health = 100f;
    public Transform waypointParent;
    public NavMeshAgent agent;
    public float stoppingDistance = 1f;
    private Transform[] waypoints; //Creates a collection(array) of transforms
    private int currentIndex = 1;
    public Transform target;  //for seeking
    public float seekRadius = 5f;
    public Renderer rend;
    public Color hitColor = Color.red;
    private Color originalColor;
    private float hitDelay = 0.2f;
    [HideInInspector]
    public float initialSpeed;
    public enum State  //decleration
       
        

    {
        Patrol, Seek
    }

    public State currentState = State.Patrol; //definition
    void Patrol()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, point.position);

        if (distance < stoppingDistance)
        {

            // currentIndex = currentIndex +1
            currentIndex++;
        }//makes the index 1 if index reach/exceeds range, use this to create cycle
        if (currentIndex >= waypoints.Length)
        {
            currentIndex = 1;
        }
        agent.SetDestination(point.position);
        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget < seekRadius)
        {
            currentState = State.Seek;
        }

    }
    void Seek()
    {
        agent.SetDestination(target.position);
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);
        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget > seekRadius)
        {
            currentState = State.Patrol;
        }
    }

    void Start()
    {
        //Getting children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        originalColor = rend.material.color;
        initialSpeed = agent.speed;
    }


    void Update()
    {
        initialSpeed = agent.speed;
        switch (currentState)
        {
            case State.Patrol:
                //patrol statement
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
            default:
                break;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //switch current state
        //If we are in Patrol
        // Call patrol()
        //if  we are in seek
        //Call Seek()

    }
    IEnumerator Hit()
    {
        rend.material.color = hitColor;
        yield return new WaitForSeconds(hitDelay);
        rend.material.color = originalColor;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(Hit());
    }
}
