using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapcamera : MonoBehaviour
{
    public GameObject cameraposition;
    public GameObject cameraa;
    private Quaternion targetRotation = Quaternion.Euler(90f, 0f, -180f);
    void Start()
    {
        cameraa.transform.position = new Vector3(-60.63095f, 52.89999f, -38.22703f);
        cameraa.transform.rotation = targetRotation;
    }

    // Update is called once per frame
    void Update()
    {
        cameraa.transform.position = new Vector3(-60.63095f, 52.89999f, -38.22703f);
        cameraa.transform.rotation = targetRotation;
    }
}
