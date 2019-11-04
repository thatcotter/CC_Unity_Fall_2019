using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeekerBehavior : MonoBehaviour
{
    private Transform target;

    public float maxSpeed = 1f;
    public float maxForce = 1f;

    Vector3 desired;
//    Vector3 acceleration;

    private Rigidbody rb;

    private void Awake()
    {
        target = GameObject.Find("Attractor").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
//        target = prefab.transform;
//        target = GameObject.Find("Attractor").transform;
        //set an inital velocity
        rb = transform.GetComponent<Rigidbody>();
        rb.velocity = Random.insideUnitSphere * 3;

        //set the desired location
//        desired = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        Seek();
    }

    private void Seek()
    {
        desired = target.position - transform.position;
        desired.Normalize();
        desired *= maxSpeed;

        Vector3 steer = desired - rb.velocity;
        steer.Normalize();
        steer *= maxForce;

        rb.AddForce(steer);
        transform.LookAt(transform.position + rb.velocity);
    }

    public void Avoid(GameObject[] seekers, float separationScale)
    {
        //check distance against each seeker and
        //keep a specified distance away
        var desiredSeparation = transform.localScale.z * 2 * separationScale;
        var sum = new Vector3();
        var count = 0;

        foreach (var s in seekers)
        {
            if(transform == s.transform) continue;
            var d  = Vector3.Distance(transform.position, s.GetComponent<Transform>().position);
            if (!(d < desiredSeparation)) continue;
            var diff  = transform.position - s.GetComponent<Transform>().position;
            diff.Normalize();
            diff /= d;
            sum += diff;
            count++;
        }

        if (count <= 0) return;
        sum /= count;
        sum.Normalize();
        sum *= maxSpeed;
        Vector3 steer = sum - rb.velocity;
        steer.Normalize();
        steer *= maxForce;
        rb.AddForce(steer);
        transform.LookAt(rb.velocity);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = new Color(1f,0f,0f);
        Gizmos.DrawLine(transform.position, transform.position + desired);
        
        Gizmos.color = new Color(0f,0f,1f);
        Gizmos.DrawLine(transform.position, transform.position + rb.velocity);
        
        Gizmos.color = new Color(0f,1f,0f);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);

    }
}
