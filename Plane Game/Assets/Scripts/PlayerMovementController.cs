using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 100;
    [SerializeField]
    private float RotationSpeed = 50;
    [SerializeField]
    private float rotationSpeedReduction = 2;

    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var rotateSpeed = Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2D.velocity = (Vector2.up * moveSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Horiztonal") > 0)
        {
            //rigidbody2D.rotation
        }
    }
}
