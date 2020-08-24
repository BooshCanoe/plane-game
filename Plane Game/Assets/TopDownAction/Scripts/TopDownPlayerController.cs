using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private new Rigidbody2D rigidbody2D;

    private float dirX;
    private float dirY;
    private Vector2 movement;
    

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Handle Inputs
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Debug.Log("DirX = " + dirX);
        Debug.Log("DirY = " + dirY);
    }

    private void FixedUpdate()
    {
        handleMovement();
    }

    private void handleRotation()
    {
               
    }

    private void handleMovement()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

