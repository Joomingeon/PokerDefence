using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public SpawnEnemy _spawnEnemy;

    public int HP;

    public float _movementspeed;

    public float DragPerSize;
    public float DefaultSize;

    private void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        DefaultSize = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        DragPerSize = (transform.position.y / 7) / 10;
        transform.localScale = new Vector2(DefaultSize - DragPerSize, DefaultSize - DragPerSize);


    }
}
