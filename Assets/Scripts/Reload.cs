using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public Animator animatorController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            GetComponent<Animator>().enabled = true;
            animatorController.SetTrigger("reloadWeapon");
        }
    }

    public void EndReload () {
        GetComponent<Animator>().enabled = false;
    }
}
