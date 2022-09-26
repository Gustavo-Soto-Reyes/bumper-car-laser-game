using UnityEngine;
using System;

public class autoDriver : MonoBehaviour
{
    public float Movespeed = 15f;
    public float Turnspeed = 1f;
    public Rigidbody rb = null;
    public bool running = true;

    private void FixedUpdate()
    {
        float vert = 1f;
        float horz = 5.0f;
        float rayAngle = 1.0f;

        Console.WriteLine("value = {0} ", horz);


        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hitLeft, hitMiddle,  hitRight;
        float left = 0, right = 0, middle = 0;
        int raylen = 2;
        Physics.Raycast(transform.position, transform.TransformDirection(1.0f, 1.0f, 0.0f), out hitRight, raylen);
        Physics.Raycast(transform.position, transform.TransformDirection(1.0f, 0.0f, 0.0f), out hitMiddle, raylen + 1);
        Physics.Raycast(transform.position, transform.TransformDirection(1.0f, -1.0f, 0.0f), out hitLeft, raylen);

        left = hitLeft.distance;
        right = hitRight.distance;
        middle = hitMiddle.distance;

        if (middle > 0)
        {
            
            if(left> right)
            {
                rb.AddRelativeForce(-Vector3.right * vert * Movespeed, ForceMode.Force);
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), horz);
 
            }
            else
            {

                rb.AddRelativeForce(-Vector3.right * vert * Movespeed, ForceMode.Force);
                transform.RotateAround(transform.position, new Vector3(0, 1, 0), horz * -1);
            }
        }
        
        else if ((2*right)<left)
        {
            // rb.AddRelativeForce(Vector3.right * vert * Movespeed, ForceMode.Acceleration);
            transform.RotateAround(transform.position, new Vector3(0, 1, 0), horz);
            rb.AddRelativeForce(- Vector3.right * vert * Movespeed, ForceMode.Force);
            Debug.DrawRay(transform.position, transform.TransformDirection(1.0f, rayAngle, 0.0f) * hitRight.distance, Color.yellow);
            Debug.Log(hitLeft.transform.gameObject.tag);
        }
        else if ((left) < (2*right)) {
             // rb.AddRelativeForce(Vector3.right * vert * Movespeed, ForceMode.Acceleration);

             transform.RotateAround(transform.position, new Vector3(0, 1, 0), horz * -1);
            rb.AddRelativeForce(-Vector3.right * vert * Movespeed, ForceMode.Force);
            Debug.DrawRay(transform.position, transform.TransformDirection(1.0f, -rayAngle, 0.0f) * hitLeft.distance, Color.red);
        }
        
        else
        {
            // rb.AddRelativeForce(Vector3.right * vert * Movespeed, ForceMode.Acceleration);
            rb.AddRelativeForce(Vector3.right * vert * Movespeed, ForceMode.Force);
            // rb.AddForceAtPosition(rb.velocity * 0.1f, hit.point, ForceMode.Impulse);
            Debug.DrawRay(transform.position, transform.TransformDirection(1.0f, rayAngle, 0.0f) * raylen, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(1.0f, -rayAngle, 0.0f) * raylen, Color.blue);
            Debug.DrawRay(transform.position, transform.TransformDirection(1.0f, 0.0f, 0.0f) * (raylen+1), Color.cyan);
            //transform.RotateAround(transform.position, new Vector3(0, 1, 0), horz);
        }

    }
    
}