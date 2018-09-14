using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerscript;

    // Use this for initialization
    void Start()
    {
        playerscript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.GetComponent<Rigidbody>().AddForce(player.transform.up* 500);

        }
    }
}
