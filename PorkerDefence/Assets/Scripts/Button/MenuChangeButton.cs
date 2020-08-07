using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChangeButton : MonoBehaviour
{
    public enum Status
    {
        Left,
        Center,
        Right
    }

    public Status _status;

    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightClick()
    {
        if(_status == Status.Center)
        {
            Anim.SetTrigger("Right");
            _status = Status.Right;
        }
        else if (_status == Status.Left)
        {
            Anim.SetTrigger("LeftToCenter");
            _status = Status.Center;
        }
    }

    public void LeftClick()
    {
        if (_status == Status.Center)
        {
            Anim.SetTrigger("Left");
            _status = Status.Left;
        }
        else if (_status == Status.Right)
        {
            Anim.SetTrigger("RightToCenter");
            _status = Status.Center;
        }
    }
}
