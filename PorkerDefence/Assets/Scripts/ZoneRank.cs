using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneRank : MonoBehaviour
{
    public enum Deck
    {
        None,
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }

    public Deck _rank;

    public bool _straight;
    public bool _royal;
    public bool _flush;
    public bool _fok;
    public bool _tok;
    public int _pair;

    public List<int> _jobcheck;
    public List<int> _namecheck;
    public List<bool> _nameuncheck;

    public ZoneToMove[] _unit;

    public int[] numRanks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeckRankUp()
    {
        _namecheck.Clear();
        _jobcheck.Clear();

        for (int i = 0; i < _unit.Length; i++)
        {
            _namecheck.Add(_unit[i]._nameindex);
            _jobcheck.Add(_unit[i]._jobindex);
        }

        _namecheck.Sort();

        RankOfDeck();
    }

    public void RankOfDeck()
    {
        RankReset();

        int straightcounter = 0;

        if(_namecheck.Count >= 5)
        {
            for (int i = 0; i < _namecheck.Count - 1; i++)
            {
                if (_namecheck[i] + 1 == _namecheck[i + 1])
                {
                    straightcounter += 1;
                    if (straightcounter == 4)
                    {
                        _straight = true;
                        if(_namecheck[4] == 13)
                        {
                            _royal = true;
                        }
                    }
                }
            }

            for(int i = 0; i < _namecheck.Count - 1; i++)
            {
                if(_jobcheck[i] != _jobcheck[i+1] || _jobcheck[i] == 99)
                {
                    _flush = false;
                    break;
                }
                if(i == 3)
                {
                    _flush = true;
                }
            }

            numRanks = new int[_namecheck.Count];

            for(int i = 0; i < _namecheck.Count; i++)
            {
                for(int ii = i+1; ii < _namecheck.Count; ii++)
                {
                    if(_namecheck[i] == _namecheck[ii])
                    {
                        if(_namecheck[i] != 99)
                        {
                            numRanks[i] += 1;
                        }
                    }
                }
            }
            for(int i = 0; i < _namecheck.Count; i++)
            {
                switch(numRanks[i])
                {
                    case 1: _pair+= 1;
                        break;
                    case 2:
                        _tok = true;
                        break;
                    case 3:
                        _fok = true;
                        break;
                }
            }
        }
        ResultRank();
        UnitStatusSetting();
    }

    void RankReset()
    {
        _pair = 0;
        _straight = false;
        _royal = false;
        _flush = false;
        _fok = false;
        _tok = false;
    }

    void ResultRank()
    {
        if(_royal && _flush)
        {
            _rank = Deck.RoyalFlush;
        }
        else if(_straight && _flush)
        {
            _rank = Deck.StraightFlush;
        }
        else if(_fok)
        {
            _rank = Deck.FourOfAKind;
        }
        else if(_tok && _pair == 2)
        {
            _rank = Deck.FullHouse;
        }
        else if(_flush)
        {
            _rank = Deck.Flush;
        }
        else if(_straight)
        {
            _rank = Deck.Straight;
        }
        else if(_tok)
        {
            _rank = Deck.ThreeOfAKind;
        }
        else if(_pair == 2)
        {
            _rank = Deck.TwoPair;
        }
        else if(_pair == 1)
        {
            _rank = Deck.Pair;
        }
        else
        {
            _rank = Deck.HighCard;
        }
    }

    void UnitStatusSetting()
    {
        if(_rank == Deck.Pair)
        {
            print("Pair");
            for(int i = 0; i < _unit.Length; i++)
            {
                if(_unit[i]._unit != null)
                {
                    _unit[i]._unit._r_dmg = _unit[i]._unit._d_dmg * 2;
                    _unit[i]._unit._r_speed = _unit[i]._unit._d_speed * 2;
                }
            }
        }
        else if(_rank == Deck.TwoPair)
        {
            print("TP");
            for (int i = 0; i < _unit.Length; i++)
            {
                if (_unit[i]._unit != null)
                {
                    _unit[i]._unit._r_dmg = _unit[i]._unit._d_dmg * 2;
                    _unit[i]._unit._r_speed = _unit[i]._unit._d_speed * 2;
                }
            }
        }
        else if(_rank == Deck.FullHouse)
        {
            print("FH");
            for (int i = 0; i < _unit.Length; i++)
            {
                if (_unit[i]._unit != null)
                {
                    _unit[i]._unit._r_dmg = _unit[i]._unit._d_dmg * 2;
                    _unit[i]._unit._r_speed = _unit[i]._unit._d_speed * 2;
                }
            }
        }
        else if(_rank == Deck.FourOfAKind)
        {
            print("FC");
            for (int i = 0; i < _unit.Length; i++)
            {
                if (_unit[i]._unit != null)
                {
                    _unit[i]._unit._r_dmg = _unit[i]._unit._d_dmg * 2;
                    _unit[i]._unit._r_speed = _unit[i]._unit._d_speed * 2;
                }
            }
        }
        else if(_rank == Deck.Flush)
        {
            print("F");
            for (int i = 0; i < _unit.Length; i++)
            {
                if (_unit[i]._unit != null)
                {
                    _unit[i]._unit._r_dmg = _unit[i]._unit._d_dmg * 2;
                    _unit[i]._unit._r_speed = _unit[i]._unit._d_speed * 2;
                }
            }
        }
        else if(_rank == Deck.RoyalFlush)
        {
            print("RF");
            for (int i = 0; i < _unit.Length; i++)
            {
                if (_unit[i]._unit != null)
                {
                    _unit[i]._unit._r_dmg = _unit[i]._unit._d_dmg * 2;
                    _unit[i]._unit._r_speed = _unit[i]._unit._d_speed * 2;
                }
            }
        }
        else if(_rank == Deck.Straight)
        {
            print("ST");
            for (int i = 0; i < _unit.Length; i++)
            {
                if (_unit[i]._unit != null)
                {
                    _unit[i]._unit._r_dmg = _unit[i]._unit._d_dmg * 2;
                    _unit[i]._unit._r_speed = _unit[i]._unit._d_speed * 2;
                }
            }
        }
        else if(_rank == Deck.StraightFlush)
        {
            print("SF");
            for (int i = 0; i < _unit.Length; i++)
            {
                if (_unit[i]._unit != null)
                {
                    _unit[i]._unit._r_dmg = _unit[i]._unit._d_dmg * 2;
                    _unit[i]._unit._r_speed = _unit[i]._unit._d_speed * 2;
                }
            }
        }
    }
}
