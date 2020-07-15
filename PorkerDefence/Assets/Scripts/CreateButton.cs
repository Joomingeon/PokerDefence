using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButton : MonoBehaviour
{
    public ZoneStatus _zonestatus;

    public string[] _name;
    public string[] _job;

    public int _nameindex;

    public GameObject _unit;
    public Transform[] _SpawnPos;

    public GameObject _parentobj;

    int _spawnCheck;

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
        int _posindex = Random.Range(0, _SpawnPos.Length);
        
        for (int i = 0; i < _zonestatus._enablezone.Length; i++)
        {
            if(_zonestatus._enablezone[i])
            {
                _spawnCheck += 1;
            }
        }


        if (_spawnCheck != 9)
        {
            if (!_zonestatus._enablezone[_posindex])
            {
                GameObject _spawnunit = Instantiate(_unit, _SpawnPos[_posindex].position, Quaternion.identity);
                _spawnunit.transform.parent = _parentobj.transform;
                _spawnunit.transform.position = new Vector3(_spawnunit.transform.position.x, _spawnunit.transform.position.y, -2f);
                _spawnunit.transform.localScale = new Vector2(0.2f, 0.2f);
                _spawnunit.GetComponent<UnitStatus>()._posindex = _posindex;
                _zonestatus._enablezone[_posindex] = true;
                _spawnunit.GetComponent<UnitStatus>().UnitSetting();
                _zonestatus._units[_posindex]._jobindex = _spawnunit.GetComponent<UnitStatus>()._jobindex;
                _zonestatus._units[_posindex]._nameindex = _spawnunit.GetComponent<UnitStatus>()._nameindex;
                _zonestatus._units[_posindex]._starindex = _spawnunit.GetComponent<UnitStatus>()._starindex;
                _zonestatus._units[_posindex]._unit = _spawnunit.GetComponent<UnitStatus>();
                _spawnunit.GetComponent<UnitDrag>()._prevzone = "KeepZone";
                
                _spawnCheck = 0;
            }
            else
            {
                Click();
            }
        }
    }
}
