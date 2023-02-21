using System.Collections;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
   public int pourThreshold = 45;
   public Transform origin = null; 
   public GameObject streamPrefab = null;

   private bool isPouring = false;
   private Stream currentStream = null;

   private void Update()
   {
        bool pourCheck = CalculatePourAngle() > pourThreshold;

        if(isPouring != pourCheck)
        {
           isPouring = pourCheck;

           if(isPouring)
           {
           
             StartPour();
           }
           else
           {
                  EndPour();
           }
        }
   }

   private void StartPour()
   {
        print("StartPouring");
        currentStream = CreateStream();
        currentStream.Begin();
   }

   private void EndPour()
   {
       print("End");
        Destroy(currentStream.gameObject);
       // Empty
   }

   private float CalculatePourAngle()
   {
        //Debug.Log(transform.forward.y * Mathf.Rad2Deg);
        float angle = Vector3.Angle(Vector3.up, transform.up);
        Debug.Log(angle);
        return angle;
   }



   private Stream CreateStream()
   {
          GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, origin.transform);
          return streamObject.GetComponent<Stream>();
   }
}