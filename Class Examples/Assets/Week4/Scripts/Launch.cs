using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 7500);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            rb.AddForce(Random.insideUnitSphere * 5000);
        }
    }

    
}
