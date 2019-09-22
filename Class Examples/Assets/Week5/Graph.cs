using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate Vector3 GraphFunction(float x, float z, float t);

public enum GraphFunctionName
{
    Sine,
    Sine2D,
    MultiSine,
    MultiSine2D,
    Ripple
}

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;

    [Range(10,100)]
    public int resolution = 10;

    public Transform[,] points;

    public GraphFunctionName function;

    static GraphFunction[] functions = {
		SineFunction,
        Sine2DFunction,
        MultiSineFunction,
        MultiSine2DFunction,
        Ripple
	};

    private void Awake() 
    {
        points = new Transform[resolution, resolution];
        var step = 2f / resolution;
        var scale = Vector3.one * step;
        for (var v = 0; v < resolution; v++)
        {
            for (var u = 0; u < resolution; u++)
            {
                var point = Instantiate(pointPrefab, transform, false);
                point.localScale = scale;
                points[u,v] = point;
            }
        }
    }

    private void Update() 
    {
        var t = Time.time;
        var f = functions[(int)function];

        // foreach (var point in points)
        // {
        //     Vector3 pos = point.localPosition;
        //     pos = f(pos.x, pos.z, t);
        //     point.localPosition = pos;
        //     point.localScale = Vector3.one * (2f/resolution);// * (Mathf.Abs(pos.z) + 0.3f);
        // }

        var step = 2f / resolution;
        for (var z = 0; z < resolution; z++)
        {
            var v = (z + 0.5f) * step - 1f;
            for (var x = 0; x < resolution; x++)
            {
                var u = (x + 0.5f) * step - 1f;
                points[x,z].localPosition = f(u,v,t);
            }
        }
    }


    static Vector3 SineFunction(float x, float z, float t)
    {
        Vector3 p;
		p.x = x;
		p.y = Mathf.Sin(Mathf.PI * (x + t));
		p.z = z;
		return p;
    }

    static Vector3 Sine2DFunction(float x, float z, float t)
    {
        Vector3 p;
		p.x = x;
		p.y = Mathf.Sin(Mathf.PI * (x + t));
		p.y += Mathf.Sin(Mathf.PI * (z + t));
		p.y *= 0.5f;
		p.z = z;
		return p;
    }

    static Vector3 MultiSineFunction(float x, float z, float t)
    {
        Vector3 p;
		p.x = x;
		p.y = Mathf.Sin(Mathf.PI * (x + t));
		p.y += Mathf.Sin(2f * Mathf.PI * (x + 2f * t)) * 0.5f;
		p.y *= 2f / 3f;
		p.z = z;
		return p;
    }

    static Vector3 MultiSine2DFunction(float x, float z, float t)
    {
        Vector3 p;
		p.x = x;
		p.y = 4f * Mathf.Sin(Mathf.PI * (x + z + t *0.5f));
		p.y += Mathf.Sin(Mathf.PI * (x + t));
		p.y += Mathf.Sin(2f * Mathf.PI * (z + 2f * t)) * 0.5f;
		p.y *= 1f / 5.5f;
		p.z = z;
		return p;
    }

    static Vector3 Ripple(float x, float z, float t)
    {
        Vector3 p;
		var d = Mathf.Sqrt(x * x + z * z);
		p.x = x;
		p.y = Mathf.Sin(Mathf.PI * (4f * d - t));
		p.y /= 1f + 10f * d;
		p.z = z;
		return p;
    }
}


