using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> _enemyUnits;

    public Transform _instpos;

    public int _instIndex;
    public int _maxinstIndex;

    public float _instTime;
    public float _delayTime;

    public GameObject _enemyUnit;


    public bool _isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isActive)
        {
            if(_maxinstIndex >= _instIndex)
            {
                if (Time.time > _instTime)
                {
                    GameObject Unit = Instantiate(_enemyUnit, _instpos.position, Quaternion.identity);
                    _enemyUnits.Add(Unit);
                    _instTime = Time.time + _delayTime;
                    _instIndex += 1;
                }
            }
            else
            {
                _isActive = false;
                _instIndex = 0;
            }
        }
    }
}
