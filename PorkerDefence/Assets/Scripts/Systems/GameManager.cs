using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int _StageIndex;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            Application.LoadLevel("BattleScene");
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            Application.LoadLevel("StageScene");
        }
    }
}
