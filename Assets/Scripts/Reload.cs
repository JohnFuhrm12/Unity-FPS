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

        if (Input.GetKeyDown(KeyCode.R)) {
            GetComponent<Animator>().enabled = true;
            animatorController.SetTrigger("reloadWeapon");
            fireScript.ammo = 30;
        }
    }

    public void EndReload () {
        GetComponent<Animator>().enabled = false;
    }
}
