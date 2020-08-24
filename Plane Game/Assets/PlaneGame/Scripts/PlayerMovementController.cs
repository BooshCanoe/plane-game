using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float boostSpeed = 400f;
    [SerializeField]
    private float rotationSpeed = 250f;
    [SerializeField]
    private float boostingRotationSpeed = 150f;
    [SerializeField]
    private float maxVelocity = 6;

    private float defaultRotationSpeed;
    private float deadZone = 0.3f;
    private float horizontal;
    private float vertical;
    private float defaultGravityScale;

    private Rigidbody2D rigidBody2D;

    private bool isBoosting { get { return vertical > 0; } }
    private bool isTurning { get { return horizontal > deadZone || horizontal < -deadZone; } }

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        defaultGravityScale = rigidBody2D.gravityScale;
        defaultRotationSpeed = rotationSpeed;
    }

    //Handle Inputs
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        LimitVelocity();
    }

    // Handle Movement
    private void FixedUpdate()
    {
        if (isBoosting)
            StartBoosting();
        else
            StopBoosting();

        if (horizontal > deadZone)
            TurnRight();

        if (horizontal < -deadZone)
            TurnLeft();
    }

    private void StartBoosting()
    {
        //Modify physics
        rigidBody2D.gravityScale = 0f;
        rigidBody2D.AddForce(transform.up * boostSpeed, ForceMode2D.Impulse);

        //Modify other variables
        rotationSpeed = boostingRotationSpeed;
    }

    private void StopBoosting()
    {
        rigidBody2D.gravityScale = defaultGravityScale;
        rotationSpeed = defaultRotationSpeed;
    }

    private void TurnRight()
    {
        rigidBody2D.MoveRotation(rigidBody2D.rotation - rotationSpeed * Time.fixedDeltaTime);
    }

    private void TurnLeft()
    {
        rigidBody2D.MoveRotation(rigidBody2D.rotation + rotationSpeed * Time.fixedDeltaTime);
    }

    private void LimitVelocity()
    {
        if (rigidBody2D.velocity.magnitude > maxVelocity)
            rigidBody2D.velocity = Vector2.ClampMagnitude(rigidBody2D.velocity, maxVelocity);
    }
}
