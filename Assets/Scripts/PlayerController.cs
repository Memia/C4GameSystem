﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform weapon;
    public float moveSpeed;
    public Rigidbody rigid;
    public float jumpHeight = 10f;
    public float rayDistance = 1f;
    public bool rotateToMainCamera = false;
    public Weapon currentWeapon;



    private void OnDrawGizmos()
    {                           //the position where the script is attatched
        Ray groundRay = new Ray(transform.position, Vector3.down);
        //from groundRay.origin  to  groundRay.origin + groundRay.direction * rayDistance
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
    }

    // Use this for initialization
    void Start()
    {

    }
    bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        //casts a line beneath the player
        RaycastHit hit;
        if (Physics.Raycast(groundRay, /* out gives information about ray cast hit*/out hit, rayDistance))
        {
            return true;
        }
        return false;
    }
    bool CanFire()
    {
        //if the cooldown is more than zero, perform cooldown.
        if (currentWeapon.coolDown > 0)
        {
            currentWeapon.coolDown -= Time.deltaTime;
            return (false);
        }
        else
        {
            return (true);
        }



    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
            if (CanFire())
            {
                currentWeapon.Attack();
            }
        //Check if W key is perssed
        //moveforward
        #region If statement movement
        /*
        if (Input.GetKey(KeyCode.W))
        {          
            rigid.AddForce(Vector3.forward* moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector3.back * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector3.left * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector3.right * moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }
        */
        #endregion
        //GetAxisRaw snaps the numnber
        float inputH = Input.GetAxis("Horizontal") * moveSpeed;
        float inputV = Input.GetAxis("Vertical") * moveSpeed;
        //this makes y 0 and creates a problem when you fall.
        Vector3 moveDir = new Vector3(inputH, 0f, inputV);
        Vector3 camEuler = Camera.main.transform.eulerAngles;
        // Is the controller rotating to camera?
        if (rotateToMainCamera)
        {
            //Get the euler angles of Camera

            moveDir = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDir;
        }
        Vector3 force = new Vector3(moveDir.x, rigid.velocity.y, moveDir.z);
        if (Input.GetButton/*uses bool*/("Jump") && IsGrounded(/*the brackets make sure they are ercognised as a function*/))
        {
            force.y = jumpHeight;
        }

        //velocity equals to movedire.x,y,z times movement speed, it creates a problem for y axis because gravity gets involved
        rigid.velocity = force;
        //if the user pressed a key (moveDir has values in it other than 0)
        //  if (moveDir.magnitude > 0)
        //  {       //rotate the player to that moveDir
        //      transform.rotation = Quaternion.LookRotation(moveDir);
        //  }

        Quaternion playerRotation = Quaternion.AngleAxis(camEuler.y, Vector3.up);
        Quaternion weaponRotation = Quaternion.AngleAxis(camEuler.x, Vector3.right);
        weapon.localRotation = weaponRotation;
        transform.rotation = playerRotation;
    }

    /* OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Ground")
        {
            isGrounded = true;
        }
    }*/
}
