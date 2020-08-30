using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Melee : AbilityBase
{
    protected override void onUse()
    {
        Debug.Log("Used Melee");
    }
}

/*
[SerializeField]
private int attackRange;
[SerializeField]
private int attackForce;
[SerializeField]
private int damage;
[SerializeField]
private LayerMask layerMask;

private void Update()
{
    Debug.DrawRay(transform.position, player.Direction * attackRange, Color.red);

    if (Input.GetButtonDown("Fire1"))
    {
        Attack();
    }
}

private void Attack()
{
    var raycastHit = Physics2D.Raycast(transform.position, player.Direction, attackRange, layerMask);

    if (raycastHit.collider != null)
    {
        Debug.Log(raycastHit.transform.name);
    }
}

*/
