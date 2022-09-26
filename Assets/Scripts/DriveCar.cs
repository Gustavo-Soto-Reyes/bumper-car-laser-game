using UnityEngine;
using System;


public class DriveCar : MonoBehaviour
{
    public float Movespeed = 25f;
    public float Turnspeed = 0.8f;
    public Rigidbody rb = null;

    private Camera m_Camera;
    private Vector3 m_OriginalCameraPosition;

    public void Start()
    {
        m_Camera = Camera.main;
        m_OriginalCameraPosition = m_Camera.transform.localPosition;
    }


    private void FixedUpdate()
    {
        float vert = Input.GetAxis("Vertical");     // wasd, arrows, left-analog gamepad
        float horz = Input.GetAxis("Horizontal");   // -1..0..1

        

        rb.AddRelativeForce(Vector3.right * vert * Movespeed, ForceMode.Acceleration);
        //rb.AddRelativeTorque(Vector3.forward * horz * Turnspeed, ForceMode.VelocityChange);
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), horz * Turnspeed);
        //rb.AddRelativeTorque(Vector3.forward * horz * Turnspeed, ForceMode.Impulse);
        //UpdateCameraPosition();
    }

   
    /*
    private void OnCollisionEnter (Collision collision)
    {
        //Debug.Log("Points colliding: " + collision.contacts.Length);
        //Debug.Log("First point that collided: " + collision.contacts[0].point);

        if (collision.gameObject.tag == "car")
        {
            Debug.Log("CAR HITTT");
            autoDriver ad = collision.gameObject.GetComponent<autoDriver>();

            ad.Turnspeed = 0;
            ad.Movespeed = 0;
       
        }
        // if (collision.contacts[0].point[2] < -13) {
            // Debug.Log("There has been a fron collision");
        // } // for a from collision z is ~ 13
        //Debug.Log("TEST First point that collided: " + collision.GetContact(0));


    }
    */
}