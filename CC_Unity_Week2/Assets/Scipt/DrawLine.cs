using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject myPrefab;
    private LineRenderer lineRend;
    private List<GameObject> points;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        points = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z += 10f;
            var pos = Camera.main.ScreenToWorldPoint(mousePosition);

            var tempPoint = Instantiate(myPrefab, pos, Quaternion.identity);
            
            points.Add(tempPoint);
        }

        if (Input.GetKeyDown("space"))
        {
            lineRend.positionCount = points.Count;

            for (int i = 0; i < points.Count; i++)
            {
                lineRend.SetPosition(i, points[i].transform.position);
            }
        }
    }
}
