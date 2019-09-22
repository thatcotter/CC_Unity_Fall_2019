using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brick;
    public Vector3 dimensions;
    
    void Start()
    {
        
        for (int y = 0; y < dimensions.y; y++)
        {
            for (int x = 0; x < dimensions.x; x++)
            {
                for (int z = 0; z < dimensions.z; z++)
                {
                    var position =
                        transform.position +
                        new Vector3(x - dimensions.x * 0.5f, y, z - dimensions.z * 0.5f);
                    Instantiate(brick,
                        position,
                        Quaternion.identity);
                }
            }
        }
    }
}
