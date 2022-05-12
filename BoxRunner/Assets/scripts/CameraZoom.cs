using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public Camera cam;
    public GameObject player;

    public float speed = 0.5f;
    float cameraSize = 5f;

    public float MaxSize = 10f;
    public float MinSize = -5f;


    void Update()
    {
        cameraSize = 5f + player.transform.position.y;

        if (cameraSize >= MaxSize) { 
            cameraSize = MaxSize;}
        if (cameraSize <= MinSize){
            cameraSize = MinSize;}

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, cameraSize, Time.deltaTime / speed);


        
    }
}
