using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject LookAt;
    float Cam_Z;//�������� 

    Vector2 target;

    public float Smooth;//ƽ����


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
