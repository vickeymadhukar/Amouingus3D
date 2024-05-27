using UnityEngine;
using UnityEngine.UI;

public class maptoggle : MonoBehaviour
{

    public GameObject minimap;
    private void Start()
    {
        minimap.SetActive(false);
    }
   public void maponof()
    {
        if (minimap.activeInHierarchy == true)
        {
            minimap.SetActive(false);
        }
        else
        {
            minimap.SetActive(true);
        }
    }
}
