using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph2
    : MonoBehaviour
{
    public float amplitude = 1f;
    public int resolution = 10;
    public GameObject reference;
    private Transform[,] points;
    
    
    // Start is called before the first frame update
    void Start()
    {
        points = new Transform[resolution,resolution];

        for (int i = 0; i < resolution; i++)
        {
            var x = i - resolution / 2f;
            for (int j = 0; j < resolution; j++)
            {
                var z = j - resolution / 2f;
                var pos = new Vector3(x, 0, z);
                var point = Instantiate(reference, transform);
                point.transform.localPosition = pos;
                points[i,j] = point.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var t = Time.time;
        for (int i = 0; i < resolution; i++)
        {
            var x = i - resolution / 2f;
            for (int j = 0; j < resolution; j++)
            {
                var z = j - resolution / 2f;
                points[i,j].localPosition = Sine2DFn(x,z,t);
            }
        }
    }

    Vector3 SineFn(float x, float z, float t)
    {
        var pos = Vector3.zero;
        pos.x = x;
        pos.y = Mathf.Sin(t + x);
        pos.y *= amplitude;
        pos.z = z;
        return pos;
    }

    Vector3 MultiSineFn(float x, float z, float t)
    {
        var pos = Vector3.zero;
        pos.x = x;
        pos.y = Mathf.Sin(t + x);
        pos.y += Mathf.Sin(t * 2f + x * 2f);
        pos.y *= 0.66f;
        pos.y *= amplitude;
        pos.z = z;
        return pos;
    }

    Vector3 Sine2DFn(float x, float z, float t)
    {
        var pos = Vector3.zero;
        pos.x = x;
        pos.y = Mathf.Sin(t + x);
        pos.y += Mathf.Sin(t + z);
        pos.y *= 0.66f;
        pos.y *= amplitude;
        pos.z = z;
        return pos;
    }
}
