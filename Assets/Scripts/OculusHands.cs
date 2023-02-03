using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OculusHands : MonoBehaviour
    
{
    public InputActionReference gripReference, triggerReference;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gripReference.action.started += GripPressed;
        gripReference.action.canceled += GripCanceled;
        triggerReference.action.started += TriggerPressed;
        triggerReference.action.canceled += TriggerCanceled;
    }

    private void OnDestroy()
    {
        gripReference.action.started -= GripPressed;
        gripReference.action.canceled -= GripCanceled;
        triggerReference.action.started -= TriggerPressed;
        triggerReference.action.canceled -= TriggerCanceled;
    }

    void GripPressed(InputAction.CallbackContext junk)
    {
        Debug.Log("GripPressed");
        anim.SetBool("Grippress", true);
    }
    void GripCanceled(InputAction.CallbackContext junk)
    {
        Debug.Log("GripPressed");
        anim.SetBool("Grippress", false);
    }
    void TriggerPressed(InputAction.CallbackContext junk)
    {
        Debug.Log("TriggerPress");
        anim.SetBool("TriggerPress", true);
    }
    void TriggerCanceled(InputAction.CallbackContext junk)
    {
        Debug.Log("TriggerPress");
        anim.SetBool("TriggerPress", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
