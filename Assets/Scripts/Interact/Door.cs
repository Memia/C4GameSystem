using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Animator anim;


    public override void Interact()
    {
        bool isOpen = anim.GetBool("IsOpen");
        isOpen = !isOpen;
        anim.SetBool("IsOpen", isOpen);
    }
}
