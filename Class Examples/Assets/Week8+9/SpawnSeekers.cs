using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeekers : MonoBehaviour
{
    public GameObject seeker;
    public int numSeekers = 10;
    public float separation = 1f;
    public GameObject[] seekers;

    private void Awake() 
    {
        seekers = new GameObject[numSeekers];
        for (int i = 0; i < numSeekers; i++)
        {
            seekers[i] = Instantiate(seeker, Random.insideUnitSphere * 5, transform.localRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var s in seekers)
        {
            s.GetComponent<SeekerBehavior>().Avoid(seekers, separation);
        }
    }
}
