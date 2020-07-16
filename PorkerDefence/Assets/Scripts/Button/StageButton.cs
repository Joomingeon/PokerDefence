using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : MonoBehaviour
{
    public bool MainScene;

    public DefaultSetting _defaultsetting;
    public string Stagename;
    public int StageIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if(MainScene)
        {
            Application.LoadLevel(Stagename);
        }
        else
        {
            _defaultsetting._Systems.GetComponent<GameManager>()._StageIndex = StageIndex;
            Application.LoadLevel(Stagename);
        }
    }
}
