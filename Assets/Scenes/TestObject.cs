using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    public float frozenTime = 2f;
    public float frozeness;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
  
        frozeness += 0.1f;
        Debug.Log(frozeness);
        if (frozeness >= 0.3f)
        {
            StartCoroutine("Freeze");
        }

    }

    IEnumerator Freeze()
    {
        Debug.Log("Frozen");
        yield return new WaitForSeconds(frozenTime); //wait for the frozen time to count down to zero before performing the code below
        Debug.Log("Thawed");
    }
}
