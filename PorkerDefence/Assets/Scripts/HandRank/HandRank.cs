using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandRank : MonoBehaviour
{
    public RankManager _rankmanager;

    public Text _name;

    public int _jobindex;
    public int _nameindex;

    // Start is called before the first frame update
    void Start()
    {
        _jobindex = Random.Range(0,3);
        _nameindex = Random.Range(0, 12);
        _name.text = "" + _nameindex;

        if (_rankmanager.RankUpIndex == 4)
        {
            _rankmanager.DeckRankUp();
        }
        else
        {
            _rankmanager.RankUpIndex += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshHand()
    {
        _jobindex = Random.Range(0, 3);
        _nameindex = Random.Range(0, 12);
        _name.text = ""+_nameindex;
        _rankmanager.DeckRankUp();
    }
}
