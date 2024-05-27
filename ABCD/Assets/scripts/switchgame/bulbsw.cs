using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulbsw : MonoBehaviour
{
    public GameObject buton;
    public GameObject Light;
    public GameObject butonoff;
    public GameObject Lightoff;


    private void Start()
    {
        buton.SetActive(false);
        Light.SetActive(false);
        butonoff.SetActive(true);
        Lightoff.SetActive(true);
    }
    public void bulbon()
    {
        buton.SetActive(true);
        Light.SetActive(true);
        butonoff.SetActive(false);
        Lightoff.SetActive(false);
    }
  
}
