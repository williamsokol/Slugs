using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour
{

    
    private Vector3 touchStart;
    float Worldborder;


    // Start is called before the first frame update
    void Start()
    {
        Worldborder = Camera.main.orthographicSize/2;
        //print(Worldborder);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0)){
            Vector3 direction =  touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            transform.position += direction;   
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-Worldborder,Worldborder),Mathf.Clamp(transform.position.y,-Worldborder,Worldborder),transform.position.z);

    }

}
