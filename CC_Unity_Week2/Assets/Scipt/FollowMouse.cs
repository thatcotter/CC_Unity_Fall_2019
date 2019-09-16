using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //every time i click
        //the position follows the mouse
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            mousePosition.z += 10f;
            var pos = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = pos;
        }
    }
}
