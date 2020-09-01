using System.Collections;
using UnityEngine;

public class Ability_Dash : AbilityBase
{
    [SerializeField]
    private float inStanceDashForcce = 3f;
    [SerializeField]
    private float outStanceDashForcce = 3f;

    private float dashForce;
    private bool inStance;

    private new Rigidbody2D rigidbody2D;
    private Player player;
    
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();

        Stance.onStanceChange += Stance_onStanceChange;
    }

    // Modify varibles when in Stance
    private void Stance_onStanceChange()
    {
        inStance = !inStance;

        if (inStance)
        {
            dashForce = inStanceDashForcce;
        }
        if (!inStance)
        {
            dashForce = outStanceDashForcce;
        }
    }

    protected override void onUse()
    {
        rigidbody2D.AddForce(player.Direction * dashForce, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        Stance.onStanceChange -= Stance_onStanceChange;
    }
}