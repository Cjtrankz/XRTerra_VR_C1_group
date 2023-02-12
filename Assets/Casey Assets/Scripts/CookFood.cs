using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookFood : MonoBehaviour
{
    
    Color col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            col = other.GetComponent<Renderer>().material.color;
            Vector4 newCol = new Color(col.r - 0.001f,col.g - 0.001f,col.b - 0.001f);
            other.GetComponent<Renderer>().material.color = newCol;
            col = newCol;
        }
    }
}
