using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRefresh : MonoBehaviour
{

    public HandRank _handrank;

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
        _handrank.RefreshHand();
    }
}
