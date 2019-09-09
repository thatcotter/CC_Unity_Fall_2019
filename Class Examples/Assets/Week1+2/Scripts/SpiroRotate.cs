using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiroRotate : MonoBehaviour
{
    public float speed;
    public Vector3 axis;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate( axis * speed );
    }
}
