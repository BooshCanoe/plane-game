using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    [SerializeField]
    private int attackDistance;
    [SerializeField]
    private int impactForce;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int uses;
    [SerializeField]
    private int useRecoverySpeed;
    [SerializeField]
    private LayerMask attackableLayer;

    private new Rigidbody2D rigidbody2D;
    private TopDownPlayerController player;
    

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GetComponent<TopDownPlayerController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    private void Attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, player.PlayerDirection, out hit, attackDistance))
        {
            Debug.Log(hit.transform.name);
        }
    }

    
}
