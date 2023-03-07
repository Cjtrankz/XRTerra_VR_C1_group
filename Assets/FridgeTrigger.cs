using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeTrigger : MonoBehaviour
{
    public AudioSource fridgeSound;
    HingeJoint hinge;

    // Start is called before the first frame update
    private void Start()
    {
        //fridgeSound = GetComponent<AudioSource>();
        hinge = GetComponent<HingeJoint>();
       
    }

    private void Update()
    {
        if (hinge.angle > 10)
        {
            fridgeSound.Play();
        }

        else
        {
            fridgeSound.Stop();
        }
    }
}
