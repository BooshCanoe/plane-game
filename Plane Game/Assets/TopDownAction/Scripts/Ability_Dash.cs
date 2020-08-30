using System.Collections;
using UnityEngine;

public class Ability_Dash : AbilityBase
{
    [SerializeField]
    private float dashForce = 3f;

    private new Rigidbody2D rigidbody2D;
    private Player player;

    private float originalForce;
    private float newForce;
    
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    protected override void onUse()
    {
        rigidbody2D.AddForce(player.Direction * dashForce, ForceMode2D.Impulse);
    }

}