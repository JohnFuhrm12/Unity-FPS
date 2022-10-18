using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 3f;
    public float damageAmount = 1f;

    public float movementSpeed = 1;

    public bool seesPlayer = false;

    //int MaxDist = 20;
    int MinDist = 12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("PlayerCapsule");

        if (Vector3.Distance(transform.position, player.transform.position) >= MinDist) {
            seesPlayer = true;
        }

        if (seesPlayer == true) {
            transform.LookAt(player.transform.position);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= MinDist) {
            seesPlayer = false;
        }

    }

    public void TakeDamage() {
        health -= damageAmount;

        if (health == 0) {
            Destroy(gameObject);
        }
    }

    void HitByRay () {
         TakeDamage();
     }
}
