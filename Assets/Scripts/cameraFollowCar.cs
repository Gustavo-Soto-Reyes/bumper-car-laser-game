using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowCar : MonoBehaviour
{
    public Transform playerPos;
    // private Vector3 adjust  =  new Vector3(0, 0.5f, 0);
    //private Vector3 adjust = new Vector3(0, 0, 0);
    Vector3 relativePos;

    // Update is called once per frame
    void FixedUpdate()
    {

        relativePos = playerPos.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.position = playerPos.position;
        transform.rotation = rotation;

        
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);


    }
}
