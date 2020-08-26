using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private float moveDistance;
    [SerializeField]
    private int uses;
    [SerializeField]
    private int useRecoverySpeed;

    private bool canActivate { get { return uses > 0; } }

    private new Rigidbody2D rigidbody2D;
    private TopDownPlayerController player;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GetComponent<TopDownPlayerController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && canActivate)
        {
            ActivateDash();
        }
    }

    private void ActivateDash()
    {
        StartCoroutine(consumeUse());
        rigidbody2D.MovePosition(rigidbody2D.position + player.PlayerDirection * moveDistance);
    }

    IEnumerator consumeUse()
    {
        uses--;
        yield return new WaitForSeconds(useRecoverySpeed);
        uses++;
    }
}