using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class critterPriority : MonoBehaviour
{
  
  public CritterStatus status;
  public critterMove move;
  public critterSight seen;
  public string goal;

  public int huntThreshold;
  float entityUpdate;
  public bool hunting;
  public int mateThreshold;

  
  //this entire Class is to pick an object once it sees one

  GameObject Target;

    void Start(){
        move = gameObject.GetComponent<critterMove>();
        status = transform.GetChild(0).GetComponent<CritterStatus>();
        seen = transform.GetChild(0).GetComponentInChildren<critterSight>();
        hunting = false;

        //Delete
        goal = "Critter";

        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //diecide what the type of object to look for 
        if (status.growing || status.food < 50)
        {
            Searching();
            goal = "Food";
            //print("growing");
           
        }else if(status.food >= 50){
            Searching();
            goal = "Critter";
        }

        
    }
    public void Searching(){

        //print(seen.entities.Count +" and "+ entityUpdate);
        if( hunting == false && seen.entities.Count != entityUpdate){
            
            
            entityUpdate = seen.entities.Count;

            Target = pickEntity(goal);
            move.startSeek(Target);    
        }
    }
    
    GameObject pickEntity(string goal)
    {    
        if (seen.entities.Count != 0)
        {  
            
            float minDist = Mathf.Infinity;
            GameObject closeObj = null;

            foreach(GameObject thing in seen.entities)
            {    
                //print(goal);
                if (goal == thing.tag )
                {
                    hunting = true;
                    float dist = Vector3.Distance(transform.position,thing.transform.position);
                    if (dist < minDist)
                    {     
                        minDist = dist;
                        closeObj = thing;
                    }      
                    //print("picked goal");    
                }
                
            }  
            return closeObj;
        }
        //print("no goal");
        hunting = false;
        return null;
    }
}


