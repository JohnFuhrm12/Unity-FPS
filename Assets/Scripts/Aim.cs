using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public bool ADS = false;
    public bool aimStarted = false;
    public bool returnToDefault = false;

    public bool recoilStarted = false;
    public bool recoilBack = false;

    public bool recoilStartedADS = false;
    public bool recoilBackADS = false;

    public float speed = 3f;
    public float speed2 = 1.5f;
    public Vector3 target = new Vector3(0.0034f, -0.235f, -0.045f);
    public Vector3 targetDefault = new Vector3(0.2069999f, -0.242f, 0.6549998f);

    public Vector3 recoilDefault = new Vector3(0.2069999f, -0.242f, 0.4549998f);
    public Vector3 recoilADS = new Vector3(0.0034f, -0.235f, 0.04f);

    public GameObject obj;

    float boolHoldDuration = 1; // seconds
    Stopwatch stopWatch = new Stopwatch();

    // Update is called once per frame
    void Update() {
        GameObject AKM = GameObject.Find("AKM");
        LowerGun lowerGunScript = AKM.GetComponent<LowerGun>();

        GameObject barrel = GameObject.Find("frontBarrel");
        FireGun fireScript = barrel.GetComponent<FireGun>();

        if (Input.GetMouseButtonDown(1) && ADS == false) {
           lowerGunScript.shiftDown = false;
           lowerGunScript.returnAgain = false;
           returnToDefault = false;
           aimStarted = true;
           ADS = true;
           obj.SetActive(false);
        }
        else if (Input.GetMouseButtonDown(1)) {
           lowerGunScript.shiftDown = false;
           aimStarted = false;
           returnToDefault = true;
           ADS = false;
           obj.SetActive(true);
        }
        if (aimStarted == true) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
        }
        if (returnToDefault == true) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetDefault, speed * Time.deltaTime);
        }

        // Handles Recoil When Not Aimed
        if (Input.GetMouseButtonDown(0) && ADS == false && lowerGunScript.shiftDown == false && fireScript.ammo > 0 && fireScript.canFire) {
            recoilStarted = true;
        }
        if (recoilStarted == true && ADS == false) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, recoilDefault, speed * Time.deltaTime);
        }
        if (transform.localPosition == recoilDefault) {
            recoilBack = true;
        }
        if (recoilBack == true && ADS == false) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetDefault, speed * Time.deltaTime);
        }
        if (transform.localPosition == targetDefault) {
            lowerGunScript.returnAgain = true;
            returnToDefault = false;
            recoilStarted = false;
            recoilBack = false;
        }

        // Handles Recoil When Aiming Down Sights
        if (Input.GetMouseButtonDown(0) && ADS == true && lowerGunScript.shiftDown == false && fireScript.ammo > 0 && fireScript.canFire) {
            recoilStartedADS = true;
        }
        if (recoilStartedADS == true && ADS == true) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, recoilADS, speed2 * Time.deltaTime);
        }
        if (transform.localPosition == recoilADS) {
            recoilBackADS = true;
            recoilStartedADS = false;
        }
        if (recoilBackADS == true && ADS == true) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed2 * Time.deltaTime);
        }
        if (transform.localPosition == target) {
            aimStarted = false;
            recoilBackADS = false;
            recoilStartedADS = false;
        }
    }

    void BugFix() {
        if (recoilStartedADS) {
            if (!stopWatch.IsRunning) {
                stopWatch.Start();
            }
            else {
                if (stopWatch.Elapsed.Seconds >= boolHoldDuration) {
                    recoilStartedADS = false;
                }
            }
        }
        else {
            stopWatch.Reset();
        }
    }
}
