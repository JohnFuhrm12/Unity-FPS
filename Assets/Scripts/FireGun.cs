using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireGun : MonoBehaviour
{
    public ParticleSystem MuzzleFlash;
    public ParticleSystem MuzzleFlashDefault;
    public AudioSource rifleSound; 

    public Vector3 recoilBeginPos = new Vector3(0.2069999f, -0.242f, 0.6549998f);   
    public Vector3 recoilEndPos = new Vector3(0.5069999f, -0.242f, 0.6549998f);   
    public float recoilSpeed;  
    public float fireDelay = 0.1f;

    public int ammo;
    public Text magCount;

    public bool fullAuto = false;
    public bool fireFullAuto = false;

    public bool canFire = true;

    void Update() {
        GameObject AKM = GameObject.Find("AKM");
        LowerGun lowerGunScript = AKM.GetComponent<LowerGun>();
        Aim aimScript = AKM.GetComponent<Aim>();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        magCount.text = ammo.ToString();

        // Single Fire
        if (Physics.Raycast(ray, out hit, 100)) {
            Debug.DrawLine(ray.origin, hit.point);
        }
        if (Input.GetMouseButtonDown(0) && lowerGunScript.shiftDown == false && ammo > 0 && canFire) {
            Fire();
            ammo --;
        }

        // FullAuto Fire
        if (Input.GetKeyDown(KeyCode.V) && fullAuto == false) {
            fullAuto = true;
        }
        else if (Input.GetKeyDown(KeyCode.V) && fullAuto == true) {
            fullAuto = false;
        }
        if (Input.GetMouseButtonDown(0) && fullAuto == true && ammo > 0 && aimScript.ADS == false) {
            StartCoroutine(FullAuto());
        }
        if (Input.GetMouseButtonDown(0) && fullAuto == true && ammo > 0 && aimScript.ADS == true) {
            StartCoroutine(FullAutoADS());
        }
        if (Input.GetMouseButton(0) && fullAuto == true && ammo > 0) {
            fireFullAuto = true;
        }
        if (Input.GetMouseButtonUp(0) && fullAuto == true) {
            fireFullAuto = false;
        }
    }

    // Creates a Ray to check for Hits and creates Muzzle Flash
    void Fire() {
        if (canFire == true) {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            GameObject AKM = GameObject.Find("AKM");
            Aim aimScript = AKM.GetComponent<Aim>();

            rifleSound.Play();

            if (Physics.Raycast(ray, out hit, 100)) {
                print("Hit something!");
                print(hit.transform.name);
                hit.transform.SendMessage ("HitByRay");
            }
            if (aimScript.ADS == true) {
                MuzzleFlash.Play();
            }
            if (aimScript.ADS == false) {
                MuzzleFlashDefault.Play();
            }   
        }
    }

    // Full Auto Fire Loop
    private IEnumerator FullAuto() {
        GameObject AKM = GameObject.Find("AKM");
        Aim aimScript = AKM.GetComponent<Aim>();
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStarted = true;
            ammo --;
        }
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    // Full Auto Fire Loop ADS
    private IEnumerator FullAutoADS() {
        GameObject AKM = GameObject.Find("AKM");
        Aim aimScript = AKM.GetComponent<Aim>();
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        yield return new WaitForSeconds(fireDelay);
        if (fireFullAuto == true && ammo > 0 && canFire) {
            Fire();
            aimScript.recoilStartedADS = true;
            ammo --;
        }
        Debug.Log("Finished Coroutine at timestamp : " + Time.time); 
    }
}