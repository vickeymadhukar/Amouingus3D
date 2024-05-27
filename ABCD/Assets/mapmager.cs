using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapmager : MonoBehaviour
{
   public GameObject minimap;

    private bool isMapOpen = false;
    public void ToggleMap()
    {
        if (isMapOpen)
        {
            CloseMap();
        }
        else
        {
            OpenMap();
        }
    }

    private void OpenMap()
    {
        minimap.SetActive(true);
        isMapOpen = true;
    }

    private void CloseMap()
    {
        minimap.SetActive(false);
        isMapOpen = false;
    }
}
