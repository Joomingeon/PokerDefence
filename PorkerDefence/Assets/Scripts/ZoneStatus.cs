using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneStatus : MonoBehaviour
{
    public bool[] _enablezone;
    public ZoneToMove[] _units;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisableCheck()
    {
        for(int i = 0; i < _enablezone.Length; i++)
        {
            if(_enablezone[i] == false)
            {
                _units[i]._unit = null;
            }
        }
    }
}
