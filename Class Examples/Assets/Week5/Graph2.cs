//using System;
//using System.Collections;
//using System.Collections.Generic;

using System;
using UnityEngine;

public class Graph2 : MonoBehaviour
{
    public GameObject pointPrefab;
    
    public int resolution = 10;

    private Transform[] points;

    private void Awake()
    {
        points = new Transform[resolution];
        var step = 2f / resolution;
        var scale = Vector3.one * step;

        for (var u = 0; u < resolution; u++)
        {
            var point = Instantiate(pointPrefab, transform);
            point.transform.localScale = scale;
            points[u] = point.transform;
        }
    }

    private void Update()
    {
        
        var t = Time.time;
        var step = 2f / resolution;
        for (var x = 0; x < resolution; x++)
        {
            var u = (x + 0.5f) * step - 1f;
            points[x].localPosition = SineFn(u,t);
        }
    }

    private Vector3 SineFn(float x, float t)
    {
        Vector3 p;
        p.x = x;
        p.y = Mathf.Sin(Mathf.PI * (x + t));
        p.z = 0;
        return p;
    }
}
