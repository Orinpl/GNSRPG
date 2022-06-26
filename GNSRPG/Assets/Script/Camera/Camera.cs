using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject LookAt;
    float Cam_Z;//摄像机深度 

    Vector2 target;

    public float Smooth;//平滑度


    public void Start()
    {
        Cam_Z = transform.position.z;

    }



    void LateUpdate()
    {
        target = LookAt.transform.position;
        transform.position = new Vector3(target.x, target.y, Cam_Z);



        
    }
}
