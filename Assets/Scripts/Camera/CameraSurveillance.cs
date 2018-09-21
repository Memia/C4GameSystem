using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSurveillance : MonoBehaviour
{
    public Camera[] cameras;
    public KeyCode prevKey = KeyCode.Q; //filter back to previous cam
    public KeyCode nextKey = KeyCode.E; //filter forward to next cam
    private int camIndex; //current cam index from array
    private int camMax; //maximum amount of cams in array
    private Camera current; // the current camera selected

    // Use this for initialization
    void Start()
    {
        //Get all Camera children and store into array
        cameras = GetComponentsInChildren<Camera>();
        //Last index of array = Array.Length -1
        camMax = cameras.Length - 1;
        //Activate the default camera;
       // ActivateCamera(camIndex);
    }
    void ActivateCamera(int camIndex)
    {
        //loop through all surveillance cameras
        for (int i = 0; i <cameras.Length; i++)
        {
            Camera cam = cameras[i];
            //if the current index matches the argu
            if(i ==camIndex)
            {
                cam.gameObject.SetActive(true);
               
            }
            else
            {
                //disable camera
                cam.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the next key is pressed
        if (Input.GetKeyDown(nextKey))
        {
            //increase index
            camIndex++;
            if (camIndex > camMax)
                camIndex = 0;
            ActivateCamera(camIndex);
        }
        //if the back key is perssed
        if (Input.GetKeyDown(prevKey))
        {
            //increase index
            camIndex--;
            if (camIndex < 0)
                camIndex = camMax;
            ActivateCamera(camIndex);
        }
       
    }

}
