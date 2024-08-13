using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    const string playerPrefabPath = "Prefabs/Player";

    int playersInGame;
    List<PlayerController> playerList = new List<PlayerController>();
    PlayerController playerLocal;

    float timer = 10;

    private void Start()
    {
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
    }

    private void CreatePlayer()
    {
        PlayerController player = NetworkManager.instance.Instantiate(playerPrefabPath, new Vector3(30, 1, 30), Quaternion.identity).GetComponent<PlayerController>();
        player.photonView.RPC("Initialize", RpcTarget.All);
    }

    [PunRPC]
    private void AddPlayer()
    {
        playersInGame++;
        if (playersInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }
    }

    private void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            timer -= Time.deltaTime;
            photonView.RPC("UpdateTimerTextRPC", RpcTarget.All, timer);
            if (timer <= 0)
            {
                photonView.RPC("SetGameOverWindow", RpcTarget.All, true);
            }
        }
    }

    [PunRPC]
    void UpdateTimerTextRPC(float value)
    {
        ManagerUI.instance.UpdateTimerText(value);
    }

    [PunRPC]
    void SetGameOverWindow(bool active)
    {
        ManagerUI.instance.SetGameOver(active);
    }
}