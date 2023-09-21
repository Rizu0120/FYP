using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int damageToGive = 1; //damage to play = 1

    public GameObject pickupEffect;

    void Start()
    {

    }

    void OnTriggerEnter(Collider co)
    {
        //player then deal Damage, enemy destroy self
        if (co.tag == "Player")
        {
            //decrease player health bar
            co.GetComponentInChildren<Health>().decrease(); //health bar(Health), perform decrease
            Destroy(gameObject); //then destroy enemy

            //decrease health in game manager
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);

            //apply damage effect
            Instantiate(pickupEffect, transform.position, transform.rotation);
        }
    }
}