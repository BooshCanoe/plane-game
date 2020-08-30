using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1000f;
    [SerializeField]
    public float maxVelocity = 6;

    private new Rigidbody2D rigidbody2D;
    private Controller controller;

    public Vector2 Direction { get { return controller.GetDirection(); } }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        controller = GetComponent<Controller>();
    }

    private void Start()
    {
       controller.SetButtons();
    }

    private void Update()
    {
        handleMovement();
        limitVelocity();
    }

    private void handleMovement()
    {
        var direction = controller.GetDirection();
        transform.up = direction * 360f;

        var velocity = direction * moveSpeed * Time.deltaTime;
        rigidbody2D.velocity = velocity;
    }

    private void limitVelocity()
    {
        if (rigidbody2D.velocity.magnitude > maxVelocity)
        {
            rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxVelocity);
        }
    }

}

