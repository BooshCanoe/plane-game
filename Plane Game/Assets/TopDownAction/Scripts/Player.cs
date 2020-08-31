using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1000f;

    private new Rigidbody2D rigidbody2D;
    private Controller controller;

    private Ability_Stance stance;

    public Vector2 Direction { get { return controller.GetDirection(); } }
    public float Velocity { get { return stance.stanceVelocity; } }

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
        //Rotation
        transform.up = Direction * 360f;

        //Movement
        var velocity = Direction * moveSpeed * Time.deltaTime;
        rigidbody2D.velocity = velocity;
    }

    private void limitVelocity()
    {
        if (rigidbody2D.velocity.magnitude > Velocity)
        {
            rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, Velocity);
        }
    }

}

