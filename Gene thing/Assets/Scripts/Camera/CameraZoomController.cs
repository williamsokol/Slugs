using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{

    private Camera cam;
    private float targetZoom;
    
    [SerializeField] private float zoomLerpSpeed = 10;
    [SerializeField]private float zoomFactor = 8f;

    void Start()
    {
        cam = Camera.main;
        targetZoom  = cam.orthographicSize;
    }

    void Update()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom,5,40);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,targetZoom,Time.deltaTime * zoomLerpSpeed);
    }
}
