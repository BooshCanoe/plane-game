using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 100;
    [SerializeField]
    private float rotationSpeed = 50;
    [SerializeField]
    private float maxSpeed;

    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ClampMaxSpeed();

        if (Input.GetKey(KeyCode.W))
        {
            Boost();
        }

        if (Input.GetKey(KeyCode.A))
            Rotate(rotationSpeed * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.D))
            Rotate(rotationSpeed * Time.fixedDeltaTime * -1);
    }

    private void Rotate(float rotationAmount)
    {
        transform.Rotate(0, 0, rotationAmount);
    }

    private void Boost()
    {
        var direction = transform.up;
        var accelerationSpeed = moveSpeed * Time.fixedDeltaTime;

        rigidbody2D.velocity = direction * accelerationSpeed;
    }

    private void ClampMaxSpeed()
    {
        float x = Mathf.Clamp(rigidbody2D.velocity.x, - maxSpeed, maxSpeed);
        float y = Mathf.Clamp(rigidbody2D.velocity.y, - maxSpeed, maxSpeed);
    }
}
