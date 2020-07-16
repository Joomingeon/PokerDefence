using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSetting : MonoBehaviour
{

    public GameObject _Systems;
    public GameObject _instSystems;
    private void Awake()
    {
        _Systems =  GameObject.Find("Systems");
        if(_Systems == null)
        {
            GameObject InstObj = Instantiate(_instSystems, Vector3.zero, Quaternion.identity);
            InstObj.name = "Systems";
            _Systems = InstObj;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
