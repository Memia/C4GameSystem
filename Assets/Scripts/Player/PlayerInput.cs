using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerController player;
    private int weaponIndex = 0;
    // Use this for initialization
    void Start()
    {
        //Select the first weapon
        player.SelectWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        player.Move(inputH, inputV);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            
            player.Attack();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            player.Interact();
        }
    }
    private void WeaponSwitch()
    {
        int currentIndex = weaponIndex;
        //if Q is pressed and weaponIndex > 0
        if (Input.GetKeyDown(KeyCode.Q) && weaponIndex > 0)
            //Decrement weaponIndex
            weaponIndex--;
        //If E is pressed && weaponIndex <= length
        if (Input.GetKeyDown(KeyCode.E) && weaponIndex <= player.weapons.Length)
        {
            //increment weaponIndex
            weaponIndex++;
        }

        if (currentIndex != weaponIndex)
        {   //Update weapon index
            weaponIndex = currentIndex;

            //Select weaponIndex
            player.SelectWeapon(weaponIndex);
        }

    }
}
