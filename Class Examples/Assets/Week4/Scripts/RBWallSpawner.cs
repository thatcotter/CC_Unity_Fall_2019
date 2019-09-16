using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBWallSpawner : MonoBehaviour
{
    public GameObject mBrick;
    public Vector3 numBricks = new Vector3(5,10,5);

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBricks.x; i++)
        {
            for (int j = 0; j < numBricks.y; j++)
            {
                for (int k = 0; k < numBricks.z; k++)
                {
                    var v = new Vector3(i - (numBricks.x/2), j, k - (numBricks.z/2));
                    Instantiate(mBrick, transform.position + v, Quaternion.identity);
                }
            }
        }
    }
}
