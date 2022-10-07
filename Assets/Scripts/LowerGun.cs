using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerGun : MonoBehaviour
{
    public bool shiftDown = false;
    public bool returnAgain = false;

    public float speedLower = 1;
    public Vector3 lowerTarget = new Vector3(0.135f, -0.379f, 0.522f);
    public Vector3 targetRotation = new Vector3(-22.138f, 128.79f, -2.419f);

    public Vector3 targetDefaultReturn = new Vector3(0.2069999f, -0.242f, 0.6549998f);

    // Update is called once per frame
    void Update()
    {
        GameObject AKM = GameObject.Find("AKM");
        Aim aimScript = AKM.GetComponent<Aim>();

        if (Input.GetKeyDown(KeyCode.LeftShift) && aimScript.ADS == false)
        {
            returnAgain = false;
            aimScript.returnToDefault = false;
            shiftDown = true;
        }

        if (shiftDown == true) {
            returnAgain = false;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, lowerTarget, speedLower * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && aimScript.ADS == false)
        {
            shiftDown = false;
            returnAgain = true;
        }

        if (returnAgain == true) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetDefaultReturn, speedLower * Time.deltaTime);
        }
    }
}
