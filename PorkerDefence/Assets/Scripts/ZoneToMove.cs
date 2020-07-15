using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneToMove : MonoBehaviour
{
    public ZoneStatus _zonehead;
    public ZoneStatus _bzone;
    public int _posindex;

    public int _d_dmg;
    public int _d_speed;

    public int _starindex;
    public int _jobindex;
    public int _nameindex;

    public UnitStatus _unit;

    // Start is called before the first frame update
    void Start()
    {
        _jobindex = 99;
        _nameindex = 99;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallBack()
    {
        _zonehead._enablezone[_posindex] = true;
        //_zonehead.DisableCheck();
        for(int i = 0; i < _zonehead._zonerank.Length; i++)
        {
            _zonehead._zonerank[i].DeckRankUp();
        }
        for(int i = 0; i < _bzone._zonerank.Length; i++)
        {
            _bzone._zonerank[i].DeckRankUp();
        }
    }
}
