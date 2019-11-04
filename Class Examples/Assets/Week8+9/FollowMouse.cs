using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private float _distance;
    // Start is called before the first frame update
    private void Start()
    {
        if (Camera.main != null) _distance = (Camera.main.transform.position - transform.position).magnitude;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetButton("Fire1")) return;
        var mousePos = Input.mousePosition;
        mousePos.z = _distance;
        if (Camera.main != null) transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
