using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootCar : MonoBehaviour
{ 
    public string nameOfTheHitObject;
    //private Camera m_Camera;
    //private Vector3 m_OriginalCameraPosition;
    LineRenderer laser;
    public Transform gunEnd;
    private Camera fpsCam;
    Vector3 rayOrigin;
    RaycastHit previousHit;
    bool hitCar = false;

    // Start is called before the first frame update
    void Start()
    {
        //m_OriginalCameraPosition = m_Camera.transform.localPosition;
        laser = GetComponent<LineRenderer>();
        fpsCam = Camera.main;
    }

    
    void FixedUpdate()
    {


        

        rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.2f, 0.0f));


        RaycastHit hit;
        Debug.DrawRay(gameObject.transform.position, gamesObject.transform.TransformDirection(0.0f, 1.0f, 0.0f) * 8, Color.green);

        if (Physics.Raycast(this.gameObject.transform.position, transform.TransformDirection(0.0f, 1.0f, 0.0f), out hit, 8) && (hit.transform.gameObject.tag == "car"))
        {
            
            autoDriver ad = hit.transform.gameObject.GetComponent<autoDriver>();
            if(ad.running == true)
            {
                Color c = hit.transform.gameObject.GetComponent<Renderer>().material.color;
                hit.transform.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", c);
                // hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.grey;




                if (Input.GetKeyDown("space"))
                {
                    StartCoroutine(fire());
                    laser.SetPosition(0, gunEnd.position);
                    laser.SetPosition(1, rayOrigin + (fpsCam.transform.forward * 8)); // 20 is size of line make this a variable
                    ad.Turnspeed = 0;
                    ad.Movespeed = 0;
                    ad.running = false;
                    hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.white;
                    hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
                    hitCar = false;



                }
                else
                {
                    hitCar = true;
                    previousHit = hit;
                }

                



            }
            





        }
        else if(hitCar == true)
        {
            Debug.Log("HELOOOOOOOOOOOO");
             previousHit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
            // previousHit.transform.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            // hit.transform.gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            hitCar = false;
        }
    


            if (Input.GetKeyDown("space"))
        {
            StartCoroutine(fire());

            laser.SetPosition(0, gunEnd.position);
            laser.SetPosition(1, rayOrigin + (fpsCam.transform.forward * 8)); // 20 is size of line make this a variable


           
            //m_OriginalCameraPosition = m_Camera.transform.localPosition;


            /*
            Debug.DrawRay(this.gameObject.transform.position, transform.TransformDirection(0.0f, 1.0f, 0.0f) * 100, Color.red);
            if (Physics.Raycast(this.gameObject.transform.position, transform.TransformDirection(0.0f, 1.0f, 0.0f), out hit, 100))
            {
                print("GOOSE Found an object - distance and name: " + hit.distance + "," + hit.transform.gameObject.name);

                // Debug.DrawRay(this.gameObject.transform.position, transform.TransformDirection(0.0f, 0f, 0.0f) * hit.distance, Color.yellow);

                //Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 2, Color.green);

                hit.transform.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

                if (hit.transform.gameObject.GetComponent<Light>() != null)
                {
                    print("In Second If");
                    hit.transform.gameObject.GetComponent<Light>().enabled = true;
                    hit.transform.gameObject.GetComponent<Light>().color = Color.red;
                    hit.transform.gameObject.GetComponent<Light>().range = 50.0f;
                }
                else
                {
                    print("no light component present");
                }


                nameOfTheHitObject = hit.transform.gameObject.name;
                Debug.Log(nameOfTheHitObject);

                //UIText.text = nameOfTheHitObject;
            }
            */




        }




            


        }

    private IEnumerator fire()
    {

        laser.enabled = true;

        yield return new WaitForSeconds(0.06f);

        laser.enabled = false;
        
    }


}
