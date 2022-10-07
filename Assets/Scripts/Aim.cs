using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public bool ADS = false;
    public bool aimStarted = false;
    public bool returnToDefault = false;

    public float speed = 1;
    public Vector3 target = new Vector3(0.0034f, -0.235f, -0.045f);
    public Vector3 targetDefault = new Vector3(0.2069999f, -0.242f, 0.6549998f);

    // Update is called once per frame
    void Update() {
        GameObject AKM = GameObject.Find("AKM");
        LowerGun lowerGunScript = AKM.GetComponent<LowerGun>();

        if (Input.GetMouseButtonDown(1) && ADS == false) {
           lowerGunScript.shiftDown = false;
           lowerGunScript.returnAgain = false;
           returnToDefault = false;
           aimStarted = true;
           ADS = true;
        }
        else if (Input.GetMouseButtonDown(1)) {
           lowerGunScript.shiftDown = false;
           aimStarted = false;
           returnToDefault = true;
           ADS = false;
        }
        if (aimStarted == true) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
        }
        if (returnToDefault == true) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetDefault, speed * Time.deltaTime);
        }
    }
}
