using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{

    #region
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Define a instância para este objeto
        }
        else if (instance != this)

            Destroy(gameObject); // Destroi o objeto se já houver uma instância existente
    }
    #endregion

    const string playerPrefabPath = "Prefabs/Player";

    int playerInGame;
    List<PlayerController> playerList = new List<PlayerController>();
    PlayerController playerLocal;


    // Start is called before the first frame update
    void Start()
    {
        photonView.RPC("AddPlayer",RpcTarget.AllBuffered);
    }
    private void CreatePlayer()
    {
        PlayerController player = PhotonNetwork.Instantiate(playerPrefabPath, new Vector3(30,1,30), Quaternion.identity).GetComponent<PlayerController>();
        player.photonView.RPC("Initialize",RpcTarget.All);
    }
    [PunRPC]
    void AddPlayer()
    {
        playerInGame++;
        if(playerInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }
    }

}
