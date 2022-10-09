using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public Animator animatorController;

    void Update()
    {
        GameObject barrel = GameObject.Find("frontBarrel");
        FireGun fireScript = barrel.GetComponent<FireGun>();

        GameObject AKM = GameObject.Find("AKM");
        Aim aimScript = AKM.GetComponent<Aim>();

        if (Input.GetKeyDown(KeyCode.R)) {
            fireScript.canFire = false;
            aimScript.ADS = false;
            aimScript.recoilStartedADS = false;
            GetComponent<Animator>().enabled = true;
            animatorController.SetTrigger("reloadWeapon");
            fireScript.ammo = 30;
        }
    }

    public void EndReload () {
        GameObject barrel = GameObject.Find("frontBarrel");
        FireGun fireScript = barrel.GetComponent<FireGun>();
        
        GetComponent<Animator>().enabled = false;
        fireScript.canFire = true;
    }
}
