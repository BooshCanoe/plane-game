using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1000f;
    [SerializeField]
    private float inStanceVelocity = 0;
    [SerializeField]
    private float outStanceVelocity = 6;

    private float velocity;
    private bool inStance;

    private new Rigidbody2D rigidbody2D;
    private Controller controller;

    public Vector2 Direction { get { return controller.GetDirection(); } }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        controller = GetComponent<Controller>();

        velocity = outStanceVelocity;
        Stance.onStanceChange += Stance_onStanceChange;
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

    private void Stance_onStanceChange()
    {
        inStance = !inStance;

        if (inStance)
        {
            velocity = inStanceVelocity;
        }
        if (!inStance)
        {
            velocity = outStanceVelocity;
        }
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
        if (rigidbody2D.velocity.magnitude > velocity)
        {
            rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, velocity);
        }
    }

    private void onDestroy()
    {
        Stance.onStanceChange -= Stance_onStanceChange;
    }
}

