using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Stance : AbilityBase
{
    //Handle Character movement speed here - Rotation is handled by Player
    public bool inStance;

    //In Stancce Varibles
    internal float inStanceVelocity = 0;
    internal float inStanceAttackDamage = 0;
    internal float inStanceAttackRange = 0;
    internal float inStanceAttackUses = 0;
    internal float inStanceDashRange = 0;
    internal float inStanceDashUses = 0;

    //Out Stance Varibles
    internal float outStanceVelocity = 6;
    internal float outStanceAttackDamage = 0;
    internal float outStanceAttackRange = 0;
    internal float outStanceAttackUses = 0;
    internal float outStanceDashRange = 0;
    internal float outStanceDashUses = 0;
    
    //Active Stance Varibles
    internal float stanceVelocity;
    internal float stanceAttackDamage;
    internal float stanceAttackRange;
    internal float stanceAttackUses;
    internal float stanceDashRange;
    internal float stanceDashUses;

    private Ability_Dash dash;
    private Ability_Melee melee;

    private void Awake()
    {
        dash = GetComponent<Ability_Dash>();
        melee = GetComponent<Ability_Melee>();
    }

    private void onStart()
    {
        
    }

    protected override void onUse()
    {
        //Switch stance state and make modifications
        inStance = !inStance;
        StanceModifications();
    }

    internal void StanceModifications()
    {
        if (inStance)
        {
            stanceVelocity = inStanceVelocity;
            stanceAttackDamage = inStanceDashRange;
            stanceAttackRange = inStanceAttackRange;
            stanceAttackUses = inStanceAttackUses;
            stanceDashRange = inStanceDashRange;
            stanceDashUses = inStanceDashUses;
}

        if (!inStance)
        {
            stanceVelocity = outStanceVelocity;
            stanceAttackDamage = outStanceDashRange;
            stanceAttackRange = outStanceAttackRange;
            stanceAttackUses = outStanceAttackUses;
            stanceDashRange = outStanceDashRange;
            stanceDashUses = outStanceDashUses;
        }
    }

    //While in Stance - Modify Move Speed, Dash Speed, Attack Range, Attack Uses
    //While out Stance - Reset all of the above
}
