using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public enum HOSTCHECK
    {
        NONE,
        HOST,
        GUEST
    }

    public HOSTCHECK _hostcheck;

    private string GameVersion = "1";
    public byte _maxPlayer;

    public Text connectionInfoText;
    public Button joinButton;


    private void Awake()
    {

    }

    void OnLevelWasLoaded()
    {
        if(Application.loadedLevelName == "StageScene")
        {
            joinButton = GameObject.Find("Canvas/Scene/Center/GameStart").GetComponent<Button>();

            if (joinButton != null)
            {
                joinButton.interactable = true;
                joinButton.onClick.AddListener(() => { GetComponent<LobbyManager>().Connect(); });
                connectionInfoText = GameObject.Find("Canvas/Scene/Center/GameStart/Text").GetComponent<Text>();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = GameVersion;
        PhotonNetwork.ConnectUsingSettings();
        connectionInfoText = GameObject.Find("Canvas/Button/Text").GetComponent<Text>();

        //joinButton.interactable = false;

        connectionInfoText.text = "서버에 접속중. . .";
    }

    public override void OnConnectedToMaster()
    {
        //joinButton.interactable = true;

        connectionInfoText.text = "온라인 : 서버와 연결됨";

        PhotonNetwork.LoadLevel("StageScene");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        //joinButton.interactable = false;

        connectionInfoText.text = "오프라인 : 서버와 연결실패 \n 접속 재시도중. . .";

        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect()
    {
        joinButton.interactable = false;

        if(PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "룸에 접속. . . ";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "오프라인 : 서버와 연결실패 \n 접속 재시도 중 . . . ";

            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "빈 방이 없음, 새로운 방 생성. . .";
        _hostcheck = HOSTCHECK.HOST;

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = _maxPlayer });
    }

    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방 참가 성공";
        if(_hostcheck != HOSTCHECK.HOST)
        {
            _hostcheck = HOSTCHECK.GUEST;
        }
        PhotonNetwork.LoadLevel("FixBattleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
