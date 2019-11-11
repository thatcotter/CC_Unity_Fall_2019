using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NoiseMovement : MonoBehaviour
{
    public Vector3 bounds;
    public float scale = 0.00001f;

    // Update is called once per frame
    private void Update()
    {
        var position = transform.position;
        var noisePos = new Vector3(
            Mathf.PerlinNoise(position.z, Time.realtimeSinceStartup),
            Mathf.PerlinNoise(position.x, Time.realtimeSinceStartup),
            Mathf.PerlinNoise(position.y, Time.realtimeSinceStartup)
        );
 
        noisePos.x = (noisePos.x - 0.5f) * 2 * bounds.x;
        noisePos.y = (noisePos.y - 0.5f) * 2 * bounds.y;
        noisePos.z = (noisePos.z - 0.5f) * 2 * bounds.z;

        position = Vector3.Lerp(position, noisePos, scale);
        transform.position = position;
    }
}
