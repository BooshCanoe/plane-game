using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 100;
    [SerializeField]
    private float movingRotationSpeed = 50;
    [SerializeField]
    private float stillRotatingSpeedReduction = 2;

    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Rotate or Accelerate the ship.

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2D.velocity = (Vector2.up * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Rotate
        }
    }
}
