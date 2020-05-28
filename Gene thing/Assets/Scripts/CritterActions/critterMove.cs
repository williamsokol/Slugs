using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class critterMove : MonoBehaviour
{
   public critterEvo thisCritter;
   public float WorldBorder;
   
   //Critter variables
   public float moveSpeed;
   public float turnSpeed;
   

   
   int patStep;
   float duration,positionZ = 0;
   Vector3 rotationA,rotationB;
   public GameObject target;

   void Start(){
        thisCritter = gameObject.GetComponent<critterEvo>();
        
        
        moveSpeed  = thisCritter.critterChar[1];
        turnSpeed  = thisCritter.critterChar[2];


   }

    void Update(){
         //transform.position = transform.position + new Vector3(0,.4f,0) * 0.1f;
        //transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.Self);

        //Border for the game
        if (transform.position.x > WorldBorder){

            transform.position = new Vector3(WorldBorder,transform.position.y,transform.position.z);        
        }else if(transform.position.x < -WorldBorder){

            transform.position = new Vector3(-WorldBorder,transform.position.y,transform.position.z);
        }
        if (transform.position.y > WorldBorder){

            transform.position = new Vector3(transform.position.x,WorldBorder,transform.position.z);
        }else if(transform.position.y < -WorldBorder){

            transform.position = new Vector3(transform.position.x,-WorldBorder,transform.position.z);
        }
        
        //The Most Advanced of AI:
        if (target != null){
            seek(target); 
        }else{
            wander();
        }
       
    }






    public void seek(GameObject target)
    {   
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turnSpeed);
                                   
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.Self);  
        print("seeking");     
    }

    public void startSeek(GameObject thing)
    {
        target = thing;
    }

    public void wander(){
         
        
        
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.Self);
        Quaternion q = Quaternion.AngleAxis(positionZ+thisCritter.wanderPat[patStep].rotation*36,Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation,q,Time.deltaTime * turnSpeed);


        duration = duration - Time.deltaTime;
        
        if (duration <= 0){ 
           

            patStep++;
            if (patStep == thisCritter.wanderPat.Count){
                patStep = 0;
             //   print("loop");
            }
            positionZ = transform.eulerAngles.z;
            duration = thisCritter.wanderPat[patStep].duration;
        }


    }

    
    

    
}
