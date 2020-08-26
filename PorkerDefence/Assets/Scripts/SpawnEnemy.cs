using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public StageSetting _stagesetting;

    public List<GameObject> _enemyUnits;

    public Transform[] _instpos;

    public int _instIndex;
    public int _maxinstIndex;

    public Text _timeText;
    public float _stageTime;

    public float _instTime;
    public float _delayTime;

    public GameObject _enemyUnit;

    public ZoneStatus _Bzonestatus;
    public ZoneStatus _Kzonestatus;

    public bool _isActive;

    public bool GameStart;
    // Start is called before the first frame update
    void Start()
    {
        _stageTime = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStart)
        {
            if (_stageTime > 0)
            {
                _stageTime = _stageTime - 1 * Time.deltaTime;
                _timeText.text = "" + (int)_stageTime;
            }
            else
            {
                _isActive = true;
                _stageTime = 120;
            }
        }

        

        if(_isActive)
        {
            if (_stagesetting._GM.GetComponent<LobbyManager>()._hostcheck == LobbyManager.HOSTCHECK.HOST)
            {
                CreateEnemy(0);
            }
            else
            {
                CreateEnemy(1);
            }
        }

        
    }

    void CreateEnemy(int Index)
    {
        if (_maxinstIndex >= _instIndex)
        {
            if (Time.time > _instTime)
            {

                GameObject Unit = Instantiate(_enemyUnit, _instpos[Index].position, Quaternion.identity);
                Unit.transform.parent = _instpos[Index];
                Unit.GetComponent<EnemyStatus>()._spawnEnemy = this;
                Unit.GetComponent<EnemyStatus>().HP = Random.Range(1, 1);
                _enemyUnits.Add(Unit);
                _instTime = Time.time + _delayTime;
                _instIndex += 1;
                for (int i = 0; i < _Bzonestatus._units.Length; i++)
                {
                    if (_Bzonestatus._units[i].GetComponent<ZoneToMove>()._unit != null)
                    {
                        _Bzonestatus._units[i].GetComponent<ZoneToMove>()._unit.EnemyCheck();
                    }
                }
            }
        }
        else
        {
            _isActive = false;
            _instIndex = 0;
        }
    }
}
