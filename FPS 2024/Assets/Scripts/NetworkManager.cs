using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UIElements;
using Photon.Pun.Demo.Cockpit;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    #region Singleton

    public static NetworkManager instance;

    private void Awake()
    {
        if (instance =null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }



    #endregion


     void Start()
    {
        PhotonNetwork.ConnectUsingSettings();   
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected Sucessful");
        MenuManager.Instance.Connected();
    }

    public void JoinRoom(string roomName, string nickName)
    {
        PhotonNetwork.NickName = nickName;
        PhotonNetwork.JoinRoom(roomName);
    }

    #region



    #endregion

}
