using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneToMove : MonoBehaviour
{
    public ZoneStatus _zonehead;
    public ZoneStatus _bzone;
    public int _posindex;

    public UnitStatus _unit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallBack()
    {
        _zonehead._enablezone[_posindex] = true;
        
    }
}
