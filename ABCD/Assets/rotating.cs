using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotating : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust this value to control the rotation speed

    void Update()
    {
        // Rotate the GameObject around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
