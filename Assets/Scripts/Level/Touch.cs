using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{

    public Image myMeter;
    public float multiplier = 0.05f;

    //ACCESS TO LAUNCH SCRIPT
    public Launch launchObject;

    //VARIABLES TO LAYERS
    public LayerMask layerMask;

    public bool touchable;

    void Update()
    {
        RaycastHit hit;
        Ray ray;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
        {

            print("Hit something");

            if (Input.GetButton("Fire1"))
            {
                myMeter.fillAmount += 1f * multiplier * Time.deltaTime;
                touchable = true;
            }

            if (Input.GetButtonUp("Fire1"))
            {
                launchObject.power = myMeter.fillAmount;
                launchObject.Shoot();
                touchable = false;
            }

            if(!touchable)
            {
                myMeter.fillAmount -= 1f * multiplier * Time.deltaTime;
            }
        }

        else
        {
            myMeter.fillAmount -= 1f * multiplier*Time.deltaTime;
        }
    }
}