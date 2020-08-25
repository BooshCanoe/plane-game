using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float lungeDistance;

    private new Rigidbody2D rigidbody2D;
    private TopDownPlayerController player;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GetComponent<TopDownPlayerController>();
    }

    private void Attack()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + player.movement * lungeDistance * Time.fixedDeltaTime);
    }

}
