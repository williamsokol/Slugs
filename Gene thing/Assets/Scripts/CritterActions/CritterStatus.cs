using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterStatus : MonoBehaviour
{
   public float food= 10;
   public float timer = 0;


   public critterPriority critterPriority;
   public critterSight critterSight;
   public critterEvo critterEvo;

   public bool growing = true;
   
   void Start(){
        
   }

    // Update is called once per frame
    
    void OnTriggerEnter(Collider collision){
        
        if(collision.tag != "Untagged")
        { 
        

        //see if in contact with food
            if(collision.tag == "Food")
            {
                food = food + 10;
                Destroy(collision.gameObject);
                critterSight.objectDeleted = true;

                critterPriority.hunting = false;
                print("you ate food");
            
        //see if in contact with mate
            }else if(collision.tag == "Critter" && food >= 110 && critterPriority.goal == "Critter" )
            {
                critterEvo.mate(collision.gameObject.transform.parent.gameObject);

                critterPriority.hunting = false;
                food = food - 100;
                print ("you hit critter");
            }

            
        }
        
    }
    void FixedUpdate()
    {
        food = food -1f *Time.fixedDeltaTime;
        timer = timer + 1f *Time.fixedDeltaTime;
        
        
        if (food <= 0 )
        {
            Destroy(this.gameObject.transform.root.gameObject);
        }
        if (timer >= 5)
        {
            //print(growing);
            growing = false;
        }
    }
}
