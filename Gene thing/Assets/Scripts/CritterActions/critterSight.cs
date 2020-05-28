using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class critterSight : MonoBehaviour
{
    public List<GameObject> entities = new List<GameObject>();
    public critterPriority critterPriority;
    public Collider parentCollider;
    public bool objectDeleted= false;
    
    // Start is called before the first frame update
    void Update()
    {
        if(objectDeleted){
            
            for(int i = 0; i < entities.Count; i++){
                print("test");
                if( entities[i] == null){
                    entities.Remove(entities[i]);
                }
            }
            objectDeleted = false;
        }
    }

   void OnTriggerEnter(Collider other)
   {
        
        if(other != parentCollider && other.tag != "Eye")
        {
            print("seen"); 
            entities.Add(other.gameObject);
            critterPriority.Searching();
        }
   }
        
   
   void OnTriggerExit(Collider other){
       //print("left");
       entities.Remove(other.gameObject);
   }
}