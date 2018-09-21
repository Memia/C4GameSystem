using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public Transform[] lookObjects;//array of objects to look at
    public bool smooth = true; // is smooth enabled?
    public float damping = 6; //smoothness value of camera
    [Header("GUI")]
    public float scrW;
    public float scrH;

    private int lookIndex;//index into array of lookObjects
    private int lookMax; //stores the total amount of lookObjects
    private Transform target; //current target look object

    // Use this for initialization
    void Start()
    {
        //Last index of array
        lookMax = lookObjects.Length - 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Get current object to look at
        target = lookObjects[lookIndex];
        //if target is not null
        if (target)
        {
            //is smoothing enabled
            if (smooth)
            {
                //calculate direction to look at target
                Vector3 lookDirection = target.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(lookDirection);
                //look at and dampen the rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            }

            else
            {
                //just look at the traget without the smooth and dampen
                transform.LookAt(target);
            }
        }
        else
        {
            //keep swapping cameras until a valid target is found
            CamSwap();
        }
        
    }
    void CamSwap()
    {
        //increase index 1 to select next object
        lookIndex++;
        //if indexis greater than our max array size
        if (lookIndex > lookMax)
        {
            //Reset lookIndex back to zero
            lookIndex = 0;
        }

    }
    private void OnGUI()
    {
        if(scrW !=Screen.width/16 || scrH !=Screen.height/9)
        {
            scrW = Screen.width / 16;
            scrH = Screen.height / 9;

        }
        if(GUI.Button(new Rect(0.5f*scrW,0.25f*scrH,1.5f*scrW,0.75f*scrH),"Swap"))
        {
            //swap the cameras
            CamSwap();
        }
    }
}
