using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatus : MonoBehaviour
{
    public enum Animstate
    {
        Idle,
        Attack
    }

    public Deck _rank;

    public Animstate _animstate;

    public int _d_dmg;
    public int _d_speed;//not speed per second; //AnimSpeed
    public int _r_dmg;
    public int _r_speed;

    public bool AnimCheck;

    public int _posindex;

    public bool _battleReady;

    public Text _nameText;

    public SpawnEnemy _spawnenemy;

    public List<EnemyStatus> _EnemyUnits;

    private void Awake()
    {
        _spawnenemy = GameObject.Find("GameManager").GetComponent<SpawnEnemy>();
    }


    public void UnitStatusSet()
    {
        GetComponent<Animator>().speed = _r_speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimCheck)
        {
            if(_battleReady)
            {
                if(_spawnenemy._enemyUnits.Count != 0)
                {
                    if(_animstate != Animstate.Attack)
                    {
                        _animstate = Animstate.Attack;
                        AnimChange();
                    }
                }
                else
                {
                    if(_animstate != Animstate.Idle)
                    {
                        _animstate = Animstate.Idle;
                        AnimChange();
                    }
                }
            }
            else
            {
                if(_animstate != Animstate.Idle)
                {
                    _animstate = Animstate.Idle;
                    AnimChange();
                }
            }
        }

        for(int i = 0; i < _EnemyUnits.Count; i++)
        {
            if(_EnemyUnits[i] == null)
            {
                _EnemyUnits.Remove(_EnemyUnits[i]);
            }
        }
    }

    public void AnimChange()
    {
        if(_animstate == Animstate.Idle)
        {
            GetComponent<Animator>().SetTrigger("Idle");
        }
        else if(_animstate == Animstate.Attack)
        {
            GetComponent<Animator>().SetTrigger("Attack");
        }
        AnimCheck = false;
    }

    public void Attack()
    {
        //거리계산 후 데미지계산
        _EnemyUnits[0].HP -= 1;
        print("Attack!");

        
    }

    public void EnemyCheck()
    {
        if (_spawnenemy._enemyUnits.Count == 0)
        {
            AnimCheck = true;
        }
    }
}
