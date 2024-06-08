using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class playersync : MonoBehaviour
{
    PhotonView pv;
    void Start()
    {
        if (!pv.IsMine)
        {
            Destroy(GetComponent<Camera>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
