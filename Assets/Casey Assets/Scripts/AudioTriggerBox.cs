using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerBox : MonoBehaviour
{
    public AudioSource clip;
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {   
        if(!hasPlayed)
        {
            clip.Play();
            hasPlayed = true;
        }
    }
}
