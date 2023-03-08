using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveDial : MonoBehaviour
{

    public GameObject StoveFlame;
    public GameObject StoveSmoke;
    HingeJoint hinge;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(hinge.angle > 90)
        {
            StoveFlame.SetActive(true);
            StoveSmoke.SetActive(true);
        }
        else
        {
            StoveFlame.SetActive(false);
            StoveSmoke.SetActive(false);
        }
        //Debug.Log("hinge angle is :" + hinge.angle);
    }
}
