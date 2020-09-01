using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Melee : AbilityBase
{
    [SerializeField]
    private float inStanceAttackRange;
    [SerializeField]
    private float outStanceAttackRange;
    [SerializeField]
    private float inStanceAttackDamage;
    [SerializeField]
    private float outStanceAttackDamage;
    [SerializeField]
    private LayerMask attackableLayerMask;

    private bool inStance;
    private float attackRange;
    private float attackDamage;

    private void onStart()
    {
        Stance.onStanceChange += Stance_onStanceChange;
    }

    // Modify varibles when in Stance
    private void Stance_onStanceChange()
    {
        inStance = !inStance;

        if (inStance)
        {
            attackRange = inStanceAttackRange;
            attackDamage = inStanceAttackDamage;
        }
        if (!inStance)
        {
            attackRange = outStanceAttackRange;
            attackDamage = outStanceAttackDamage;
        }
    }

    protected override void onUse()
    {
        Debug.Log("Used Melee");
    }

    private void OnDestroy()
    {
        Stance.onStanceChange -= Stance_onStanceChange;
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
