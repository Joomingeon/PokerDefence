using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{
    public bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if(_isActive)
        {
            GetComponent<Animator>().SetTrigger("CLOSE");
            _isActive = false;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("OPEN");
            _isActive = true;
        }
    }
}
