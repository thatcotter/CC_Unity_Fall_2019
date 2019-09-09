//using System.Collections;
//using System.Collections.Generic;

//using System;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    public GameObject pointPrefab;

    private List<GameObject> _points;
        
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _points = new List<GameObject>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.z * -1;
            var pos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(pos);
            CreatePointMarker(pos);
        }

        if (Input.GetMouseButtonDown(1))
        {
            ClearPoints();
        }

        if (Input.GetKeyDown("space"))
        {
            ReDrawLine();
        }
    }

    private void CreatePointMarker(Vector3 pointPosition)
    {
        var point = Instantiate(pointPrefab, pointPosition, Quaternion.identity);
        point.transform.parent = transform;
        _points.Add( point );
    }

    private void ClearPoints()
    {
        foreach (var point in _points)
        {
            Destroy(point);
        }
        _points.Clear();
    }

    private void ReDrawLine()
    {
        _lineRenderer.positionCount = _points.Count;
        
        if (_points.Count == 0) return;

        for (var i = 0; i < _points.Count; i++)
        {
            _lineRenderer.SetPosition(i, _points[i].transform.position);
        }
    }

//    private void LineRenderSetup()
//    {
//        _lineRenderer = GetComponent<LineRenderer>();
//        _lineRenderer.positionCount = 4;
//        
//        _lineRenderer.SetPosition(0, new Vector3(-2,2,0));
//        _lineRenderer.SetPosition(1, new Vector3(2,2,0));
//        _lineRenderer.SetPosition(2, new Vector3(2,-2,0));
//        _lineRenderer.SetPosition(3, new Vector3(-2,-2,0));
//
//        _lineRenderer.loop = true;
//    }
}
