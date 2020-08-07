using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public SpawnEnemy _spawnEnemy;
    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            _spawnEnemy._enemyUnits.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }
}
