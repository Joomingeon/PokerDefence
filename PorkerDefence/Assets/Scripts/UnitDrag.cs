using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    public bool zCheck;
    public bool SumCheck;
    public Vector3 zOffset;
    public Vector3 dOffset;

    public Vector3 mOffset;
    public float mZCoord;

    public UnitStatus _unitstatus;
    public ZoneStatus _battlezone;
    public ZoneStatus _keepzone;

    public string _prevzone;

    public string _zonename;
    ZoneToMove _zonetomove;
    // Start is called before the first frame update
    void Start()
    {
        _unitstatus = GetComponent<UnitStatus>();
        _battlezone = GameObject.Find("BattleZone").GetComponent<ZoneStatus>();
        _keepzone = GameObject.Find("KeepZone").GetComponent<ZoneStatus>();
        dOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp()
    {
        if (SumCheck)
        {
            if(_zonetomove._zonehead._units[_zonetomove._posindex]._posindex != _unitstatus._posindex)
            {
                if (_zonetomove._zonehead._units[_zonetomove._posindex]._starindex == _unitstatus._starindex)
                {
                    if (_zonetomove._zonehead._units[_zonetomove._posindex]._jobindex == _unitstatus._jobindex)
                    {
                        if (_zonetomove._zonehead._units[_zonetomove._posindex]._nameindex == _unitstatus._nameindex)
                        {
                            _zonetomove._zonehead._units[_zonetomove._posindex]._unit._starindex += 1;
                            _zonetomove._zonehead._units[_zonetomove._posindex]._starindex += 1;
                            ZoneDisableCheck();
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
        else
        {
            transform.position = dOffset;
        }

        if (zCheck)
        {
            transform.position = new Vector3(zOffset.x, zOffset.y, -2);
            dOffset = transform.position;

            _zonetomove._unit = gameObject.GetComponent<UnitStatus>();

            ZoneDisableCheck();
            
            if(_zonename == "BattleZone")
            {
                _prevzone = "BattleZone";
                _unitstatus._battleReady = true;
                _unitstatus.AnimCheck = true;
                _unitstatus._posindex = _zonetomove._posindex;
                _zonetomove._starindex = _unitstatus._starindex;
                _zonetomove._jobindex = _unitstatus._jobindex;
                _zonetomove._nameindex = _unitstatus._nameindex;
                _zonetomove._d_dmg = _unitstatus._d_dmg;
                _zonetomove._d_speed = _unitstatus._d_speed;
                _zonetomove.CallBack();

            }
            else if(_zonename == "KeepZone")
            {
                _prevzone = "KeepZone";
                _unitstatus._battleReady = false;
                _unitstatus.AnimCheck = true;
                _unitstatus._posindex = _zonetomove._posindex;
                _zonetomove._starindex = _unitstatus._starindex;
                _zonetomove._jobindex = _unitstatus._jobindex;
                _zonetomove._nameindex = _unitstatus._nameindex;
                _zonetomove._d_dmg = _unitstatus._d_dmg;
                _zonetomove._d_speed = _unitstatus._d_speed;
                _zonetomove.CallBack();
            }
        }
        else
        {
            transform.position = dOffset;
        }
    }

    public void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    public void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 MousePoint = Input.mousePosition;

        MousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(MousePoint);
    }


    void ZoneDisableCheck()
    {
        if (_prevzone == "BattleZone")
        {
            _battlezone._enablezone[_unitstatus._posindex] = false;
            _battlezone.DisableCheck();

        }
        else if (_prevzone == "KeepZone" || _prevzone == "")
        {
            _keepzone._enablezone[_unitstatus._posindex] = false;
            _keepzone.DisableCheck();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BattleZone" || other.tag == "KeepZone")
        {
            if(other.GetComponent<ZoneToMove>()._zonehead._enablezone[other.GetComponent<ZoneToMove>()._posindex] != true)
            {
                zCheck = true;
            }
            else
            {
                SumCheck = true;
            }
            zOffset = other.transform.position;
            _zonename = other.tag;
            _zonetomove = other.gameObject.GetComponent<ZoneToMove>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BattleZone" || other.tag == "KeepZone")
        {
            zCheck = false;
            _zonetomove = null;
        }
    }
}
