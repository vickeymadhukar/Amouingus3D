using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togglestate : MonoBehaviour
{
    public GameObject[] objectsToToggle;
    public GameObject[] onStateObject;
    public GameObject touchPanel;

    private void Start()
    {
        // Ensure all objects are initially deactivated
        DeactivateAllObjects();
    }

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Check the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch is within the boundaries of the panel
            if (IsTouchWithinPanel(touch.position))
            {
                // Toggle the activation status of objects
                ToggleObjects();
                ToggleObjectstwo();
            }
        }
    }

    private void ToggleObjects()
    {
        // Toggle the activation status of objects
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
    private void ToggleObjectstwo()
    {
        // Toggle the activation status of objects
        foreach (GameObject obj in onStateObject)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    private bool IsTouchWithinPanel(Vector2 touchPosition)
    {
        // Check if the touch position is within the panel boundaries
        RectTransform panelRect = touchPanel.GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(panelRect, touchPosition);
    }

    private void DeactivateAllObjects()
    {
        // Deactivate all objects in the array
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(false);
        }
    }
    private void activateAllObjects()
    {
        // Deactivate all objects in the array
        foreach (GameObject obj in onStateObject)
        {
            obj.SetActive(true);
        }
    }
}
