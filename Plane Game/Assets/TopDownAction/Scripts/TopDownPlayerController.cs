using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float dirX;
    private float dirY;
    public Vector2 movement;

    private new Rigidbody2D rigidbody2D;

    public bool Dash;
    public bool Attack;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Handle Inputs
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Attack = Input.GetButtonDown("Fire1");
        Dash = Input.GetButtonDown("Fire2");
    }

    private void FixedUpdate()
    {
        handleRotation();
    }

    private void handleRotation()
    {
        //Look Up
        if(movement.x == 0 && movement.y == 1)
            rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, 0);
        //Look Up / Right
        if (movement.x == 1 && movement.y == 1)
            rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, -45);
        //Look Right
        if (movement.x == 1 && movement.y == 0)
            rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, -90);
        //Look Down / Right
        if (movement.x == 1 && movement.y == -1)
            rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, -135);
        //Look Down
        if (movement.x == 0 && movement.y == -1)
            rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, -180);
        //Look Down / Left
        if (movement.x == -1 && movement.y == -1)
            rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, 135);
        //Look Left
        if (movement.x == -1 && movement.y == 0)
            rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, 90);
        //Look Left / Up
        if (movement.x == -1 && movement.y == 1)
            rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, 45);

    }

    private void handleMovement()
    {
        //rigidbody2D.MovePosition(rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

