using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastBasic : MonoBehaviour
{

    public string nameOfTheHitObject;
    //public TextMeshProUGUI UIText;

    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward *2 , Color.cyan);

        if (Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit, 100f))
        {
            print("Found an object - distance and name: " + hit.distance + "," + hit.transform.gameObject.name);

            Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward *2, Color.red);

            hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.blue;

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


    }


}