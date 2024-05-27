using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    [SerializeField] TMP_InputField roomname;
    [SerializeField] TMP_Text errortext;
    [SerializeField] TMP_Text roomtext;
    [SerializeField] Transform roomlistcontent;
    [SerializeField] GameObject roomlistiteamprefab;
    [SerializeField] Transform playerlistcontent;
    [SerializeField] GameObject playerlistiteamprefab;
    [SerializeField] GameObject startbutton;
    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        Debug.Log("connecting to master ");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master ");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("we are in lobby!!!!");
        MenuManger.Instance.OpenMenu("title");
        PhotonNetwork.NickName = " Player " + Random.Range(0, 1000).ToString("0000");
    }
    
    public void Createroom()
    {
        if (string.IsNullOrEmpty(roomname.text))
        {
            return;
        }
        MenuManger.Instance.OpenMenu("loading");
        PhotonNetwork.CreateRoom(roomname.text);
       
    }

    public override void OnJoinedRoom()
    {
        MenuManger.Instance.OpenMenu("room");
        roomtext.text = PhotonNetwork.CurrentRoom.Name;
        Player[] players = PhotonNetwork.PlayerList;
        foreach(Transform child in playerlistcontent)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerlistiteamprefab, playerlistcontent).GetComponent<Playerlistiteam>().setup(players[i]);
        }
        startbutton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startbutton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errortext.text = " Room creation failed " + message;
        MenuManger.Instance.OpenMenu("error");
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManger.Instance.OpenMenu("loading");
    }


    public void Joinroom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManger.Instance.OpenMenu("loading");

       
        
    }
    public override void OnLeftRoom()
    {
        MenuManger.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomlistcontent)
        {
            Destroy(trans.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomlistiteamprefab, roomlistcontent).GetComponent<Roomlist>().Setup(roomList[i]);
        }
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerlistiteamprefab, playerlistcontent).GetComponent<Playerlistiteam>().setup(newPlayer);
    }
}
