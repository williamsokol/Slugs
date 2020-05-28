using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class critterEvo : MonoBehaviour
{
    [System.Serializable]
    public struct Direction {
        
        public float rotation;
        public float duration;
        
    } 

    public List<Direction> wanderPat = new List<Direction>();
    //test variables
    //float timer = 0;

    public GameObject crittersBoy;
    public PrefabHolder slug;

    public float[] critterChar;
    public bool isFirstGen = true;
    
    
    

    // Start is called before the first frame update
    void Awake()
    {
        if (isFirstGen)
        {     
            critterChar = new float[10];

            //float critterTraits = traitDecider();
        
            for(int a = 0; a <= critterChar.Length-1; a++){
                critterChar[a] = Random.Range(1.0f,10.0f);  
            }
            
            for(int i = 0; i <= critterChar[0]; i++)
            {    
                
                Direction dir = new Direction();

                dir.rotation = Random.Range(1.0f,10.0f);
                dir.duration = 2f;//Random.Range(1.0f,10.0f);
                print("char0 " + critterChar[0]);
                wanderPat.Add(dir);
            }
        }

        // Find The Slug Prefab 
        //(I Can't keep it on this file without it chaging to the instance)
        print("test");
        slug = GameObject.Find("GameManager").GetComponent<PrefabHolder>();
        
    }


    public void mate(GameObject otherCritter)
    {
        //creating the boy   
        crittersBoy = (GameObject)Instantiate(slug.Slugg,transform.position,transform.rotation);

        critterEvo other = otherCritter.GetComponent<critterEvo>();
        critterEvo boysEvo = crittersBoy.GetComponent<critterEvo>();
           
        //defining boys genes
        float[] crittersBoyGene = critterGeneDicider(critterChar,other.critterChar);
        List<Direction> boysWanderPat = critterPatDicider(wanderPat,other.wanderPat);

        //inserting boys genes
        boysEvo.critterChar = crittersBoyGene;
        boysEvo.wanderPat = boysWanderPat;
        boysEvo.isFirstGen = false;
        
    }



    float[] critterGeneDicider(float[] thisCritter, float[] otherCritter)
    {
        float[][] totalGenes = new float[2][];
        float[] ChildsGene = new float[thisCritter.Length];

        totalGenes[0] = thisCritter;
        totalGenes[1] = otherCritter;

        for(int i=0; i < thisCritter.Length;i++)
        {
            int parent = Random.Range(0,2);

            ChildsGene[i] = totalGenes[parent][i];
          //  print(thing);
        }   
        return ChildsGene;
    } 

    List<Direction> critterPatDicider(List<Direction> wanderPat,List<Direction> otherWanderPat)
    {
        List<Direction> boysWanderPat = new List<Direction>();
        List<Direction>[] TotalWanderPat = new List<Direction>[3];

        TotalWanderPat[0] = wanderPat;
        TotalWanderPat[1] = otherWanderPat;
        
        for(int i=0; i<Mathf.Min(wanderPat.Count,otherWanderPat.Count);i++)
        {    
            Direction dir = new Direction();
            int parent = Random.Range(0,2);

            dir.rotation = TotalWanderPat[parent][i].rotation + Random.Range(-1.0f,1.0f);
            dir.duration = 2f;
                
            boysWanderPat.Add(dir);
        }
        
        return(boysWanderPat);
    }
    
    
    
}
