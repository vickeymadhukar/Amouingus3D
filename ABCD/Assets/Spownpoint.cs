using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spownpoint : MonoBehaviour
{
    [SerializeField] GameObject garphic;//spown poin visual

    private void Awake()
    {
        garphic.SetActive(false);
    }
}
