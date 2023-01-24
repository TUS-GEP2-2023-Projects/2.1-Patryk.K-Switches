using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    //be controlled by switch
    public GameObject lightSwitch;
    public Switch S;
    private void Start()
    {
        S = lightSwitch.GetComponent<Switch>();
    }

    public void Update()
    {
        
    }
}
