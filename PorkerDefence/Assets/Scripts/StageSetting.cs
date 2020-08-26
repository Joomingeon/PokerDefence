using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class StageSetting : MonoBehaviourPun
{
    public Transform[] _CamPos;
    public GameObject[] _TouchBlock;
    public Text _text;
    public GameObject _localcam;

    public GameManager _GM;

    public Text _StageText;

    private void Awake()
    {
        _GM = GameObject.Find("Systems").GetComponent<GameManager>();
        _StageText.text = "Stage : "+_GM._StageIndex;
        if(_GM.GetComponent<LobbyManager>()._hostcheck == LobbyManager.HOSTCHECK.HOST)
        {
            _localcam.transform.position = _CamPos[0].transform.position;
            _TouchBlock[0].SetActive(false);
            _text.text = "HOST";
        }
        else if(_GM.GetComponent<LobbyManager>()._hostcheck == LobbyManager.HOSTCHECK.GUEST)
        {
            _localcam.transform.position = _CamPos[1].transform.position;
            _TouchBlock[1].SetActive(false);
            _text.text = "Guest";
            Invoke("GameReady", 5.0f);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }

    void GameReady()
    {
        photonView.RPC("GameStart", RpcTarget.All);
    }

    [PunRPC]
    public void GameStart()
    {
        GetComponent<SpawnEnemy>().GameStart = true;
    }
}
