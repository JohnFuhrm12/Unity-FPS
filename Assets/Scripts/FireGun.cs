using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public ParticleSystem MuzzleFlash;
    public ParticleSystem MuzzleFlashDefault;

    void Update() {
        GameObject AKM = GameObject.Find("AKM");
        LowerGun lowerGunScript = AKM.GetComponent<LowerGun>();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            Debug.DrawLine(ray.origin, hit.point);
        }
        if (Input.GetMouseButtonDown(0) && lowerGunScript.shiftDown == false) {
            Fire();
        }
    }

    void Fire() {
        GameObject AKM = GameObject.Find("AKM");
        Aim aimScript = AKM.GetComponent<Aim>();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            print("Hit something!");
        }
        if (aimScript.ADS == true) {
            MuzzleFlash.Play();
        }
        if (aimScript.ADS == false) {
            MuzzleFlashDefault.Play();
        }
    }
}