using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : PooledMonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    public int Damage { get { return 1; } }

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hit = collision.collider.GetComponent<Rigidbody2D>();

        if (hit != null)
        {
            Impact(hit);
        }
    }

    private static void Impact(Rigidbody2D hit)
    {
        Impact(hit);
    }
}
