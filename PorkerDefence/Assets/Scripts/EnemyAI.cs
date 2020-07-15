using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int _wayIndex;
    public Transform[] _wayPoint;
    public float _waydistance;

    public float _movementspeed;


    private void Awake()
    {
        _wayPoint[0] = GameObject.Find("EnemyZone/RellyPoint_ (1)").transform;
        _wayPoint[1] = GameObject.Find("EnemyZone/RellyPoint_ (2)").transform;
        _wayPoint[2] = GameObject.Find("EnemyZone/RellyPoint_ (3)").transform;
        _wayPoint[3] = GameObject.Find("EnemyZone/EnemySpawnPos").transform;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _waydistance = Vector2.Distance(transform.position, _wayPoint[_wayIndex].position);

        transform.Translate(Vector2.down * _movementspeed * Time.deltaTime);

        if(_waydistance < 0.1f)
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + 90);
            if (_wayIndex == 3)
            {
                _wayIndex = 0;
            }
            else
            {
                _wayIndex += 1;
            }
        }
        else if(_waydistance > 15)
        {
            Destroy(gameObject);
        }

        
    }
}
