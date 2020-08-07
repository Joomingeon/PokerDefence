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

    public float DefaultSize;
    public float DragPerSize;

    public UnitStatus _unitstatus;
    public ZoneStatus _battlezone;
    public ZoneStatus _keepzone;

    public string _prevzone;

    public string _zonename;
    ZoneToMove _zonetomove;

    public bool DeadZone;
    // Start is called before the first frame update
    void Start()
    {
        _unitstatus = GetComponent<UnitStatus>();
        _battlezone = GameObject.Find("BattleZone").GetComponent<ZoneStatus>();
        _keepzone = GameObject.Find("KeepZone").GetComponent<ZoneStatus>();
        dOffset = transform.position;
        DefaultSize = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        DragPerSize = (transform.position.y / 7) / 10;
        transform.localScale = new Vector2(DefaultSize - DragPerSize, DefaultSize - DragPerSize);

    }

    public void OnMouseUp()
    {
        if (zCheck)
        {
            transform.position = new Vector3(zOffset.x, zOffset.y, -2);
            dOffset = transform.position;

            if(_zonetomove._unit != null)
            {
                _zonetomove._unit = gameObject.GetComponent<UnitStatus>();
            }

            ZoneDisableCheck();
            
            if(_zonename == "BattleZone")
            {
                _prevzone = "BattleZone";
                _unitstatus._battleReady = true;
                _unitstatus.AnimCheck = true;
                _unitstatus._posindex = _zonetomove._posindex;
                _zonetomove.CallBack();

            }
            else if(_zonename == "KeepZone")
            {
                _prevzone = "KeepZone";
                _unitstatus._battleReady = false;
                _unitstatus.AnimCheck = true;
                _unitstatus._posindex = _zonetomove._posindex;
                _zonetomove.CallBack();
            }
            else if(_zonename == "DeadZone")
            {
                Destroy(gameObject);
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
        if(other.tag == "DeadZone")
        {
            zCheck = true;
            _zonename = other.tag;
            _zonetomove = other.gameObject.GetComponent<ZoneToMove>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BattleZone" || other.tag == "KeepZone" || other.tag == "DeadZone")
        {
            zCheck = false;
            _zonetomove = null;
        }
    }
}
