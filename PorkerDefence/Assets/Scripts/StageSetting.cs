using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSetting : MonoBehaviour
{

    public GameManager _GM;

    public Text _StageText;
    private void Awake()
    {
        _GM = GameObject.Find("Systems").GetComponent<GameManager>();
        _StageText.text = "Stage : "+_GM._StageIndex;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
