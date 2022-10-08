using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Cameras;

public class ServerManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public int gender=-1;
    public GameObject player_prefab;
    public PlayerModel_base localPlayer;
    public static ServerManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        //Default have to do
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion("in");
    }

    
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }
    public void join()
    {
        PhotonNetwork.LoadLevel("VRTest");
        PhotonNetwork.NickName = UIManager.instance.Name_Inputfield.text;
    }
    private void OnLevelWasLoaded(int level)
    {
        //localPlayer.getPlayerModelByGender(gender).view.RPC("TurnOnAnimation",RpcTarget.AllBuffered);
        localPlayer.getPlayerModelByGender(0).view.RPC("TurnOnAnimation",RpcTarget.AllBuffered);
        UIManager.instance.ChangeCanvas("Level");
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinRoom("delta");
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Room Created.");
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        this.GetComponent<PhotonView>().RPC("SpawnPlayer", RpcTarget.AllBuffered);
        Debug.Log("Room Joined.");
    }
    [PunRPC]
    private void SpawnPlayer()
    {
        // Spawning the player in Photon Network.😊
        //localPlayer = PhotonNetwork.Instantiate(player_prefab.name, player_prefab.transform.position, player_prefab.transform.rotation);
        //localPlayer = go.GetComponent<PlayerModel_base>();
        localPlayer = PhotonNetwork.Instantiate(player_prefab.name, player_prefab.transform.position, player_prefab.transform.rotation).GetComponent<PlayerModel_base>();
        ////localPlayer = GameObject.Find("Player");
        //localPlayer = PhotonNetwork.Instantiate(player[gender].name, this.transform.position, this.transform.rotation);
        //localPlayer.name = PlayerPrefs.GetString("localPlayer_Name");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        PhotonNetwork.CreateRoom("delta");
    }
}
