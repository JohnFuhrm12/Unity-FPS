using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public ParticleSystem MuzzleFlash;
    public ParticleSystem MuzzleFlashDefault;
    public AudioSource rifleSound; 

    public Vector3 recoilBeginPos = new Vector3(0.2069999f, -0.242f, 0.6549998f);   
    public Vector3 recoilEndPos = new Vector3(0.5069999f, -0.242f, 0.6549998f);   
    public float recoilSpeed;   

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
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        GameObject AKM = GameObject.Find("AKM");
        Aim aimScript = AKM.GetComponent<Aim>();

        rifleSound.Play();

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