using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerManger : MonoBehaviour
{
    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        if (PV.IsMine)
        {
            createController();
        }
    }

  
   void createController()
    {
        Transform spown = SpownManger.Instance.GetSpownpoint();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "player2"), spown.position, spown.rotation);
    }
}
