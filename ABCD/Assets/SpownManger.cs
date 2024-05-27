using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownManger : MonoBehaviour
{
    public static SpownManger Instance;
    Spownpoint[] spownpoints;
    private void Awake()
    {
        Instance = this;
        spownpoints = GetComponentsInChildren<Spownpoint>();
    }

    public Transform GetSpownpoint()
    {
        if (spownpoints.Length == 0)
        {
            Debug.LogError("No Spownpoint components found.");
        }
        return spownpoints[Random.Range(0, spownpoints.Length)].transform;
    }
}
