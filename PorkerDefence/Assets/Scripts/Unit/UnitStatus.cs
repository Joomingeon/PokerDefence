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

    public string[] _name;
    public string[] _job;

    public int _starindex;
    public Sprite[] _colors;
    public int _nameindex;
    public int _jobindex;
    public int _posindex;

    public bool _battleReady;

    public Text _nameText;

    public SpawnEnemy _spawnenemy;

    public List<float> _EnemyDistance;

    private void Awake()
    {
        _spawnenemy = GameObject.Find("GameManager").GetComponent<SpawnEnemy>();
        _starindex = 1;
    }

    public void UnitSetting()
    {
        //_nameindex = Random.Range(0, _name.Length);
        //_jobindex = Random.Range(0, _job.Length);
        //_nameText.text = "" + _nameindex;

        GetComponent<SpriteRenderer>().sprite = _colors[_jobindex];

        _d_dmg = _nameindex;
        _d_speed = _nameindex;
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
        if(AnimCheck)
        {
            if(_battleReady)
            {
                if(_spawnenemy._enemyUnits.Count != 0)
                {
                    _animstate = Animstate.Attack;
                    AnimChange();
                
                }
            }
            else
            {
                _animstate = Animstate.Idle;
                AnimChange();
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
        //거리계산 후 데미지계
        print("Attack!");
    }
}
