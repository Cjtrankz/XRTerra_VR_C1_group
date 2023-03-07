using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTriggerBox : MonoBehaviour
{
    //public AudioSource clip;
    private bool hasPlayed = false;
    private bool startTimer = false;
    private int talkTimer;

    public UnityEvent triggerEntered;
    public UnityEvent timerSet;
    public int clipLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer == true)
        {
            talkTimer++;
        }
        if(talkTimer>clipLength)
        {
            timerSet.Invoke();
        }
    }

    void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.tag == "Player")
        {
            if(!hasPlayed)
            {
                //clip.Play();
                triggerEntered.Invoke();
                hasPlayed = true;
                startTimer = true;
            }
        }
    }
}
