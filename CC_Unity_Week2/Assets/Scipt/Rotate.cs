using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector3 myVector;

    private void Start()
    {
        myVector = new Vector3(1f,2f,3f);
//        myVector = Vector3.one * 3f;
        // Vector3.forward -> new Vector3(0,0,1f)
//        transform.rotation = Quaternion.Euler(myVector);
//        transform.localScale = myVector;
    }

    private void Update()
    {
        transform.Rotate(myVector * Time.deltaTime);
    }
}
