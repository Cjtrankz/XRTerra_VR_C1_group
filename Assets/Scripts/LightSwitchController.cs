using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.Events;

public class LightSwitchController : MonoBehaviour
{
    [SerializeField] private bool isLightOn;

    [SerializeField] private UnityEvent lightOnEvent;
    [SerializeField] private UnityEvent lightOffEvent;
    private void Start()
    {
        lightOffEvent.Invoke();
    }
    public void InteractSwitch()
    {
        if (isLightOn)
        {
            isLightOn = false;
            lightOnEvent.Invoke();
        }
        else
        {
            isLightOn = true;
            lightOffEvent.Invoke(); 
        }
    }
}
