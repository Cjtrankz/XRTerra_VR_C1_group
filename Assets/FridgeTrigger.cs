using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeTrigger : MonoBehaviour
{
    public AudioSource fridgeSound;
    

    // Start is called before the first frame update
    private void Start()
    {
        fridgeSound = GetComponent<AudioSource>();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("fridge Trigger"))
        {
            fridgeSound.enabled = true;
        }
    }
}
