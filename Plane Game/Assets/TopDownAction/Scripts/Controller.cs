using UnityEngine;

public class Controller : MonoBehaviour
{
    private string attackButton;
    private string dashButton;
    private string stanceButton;
    private string horizontalAxis;
    private string verticalAxis;

    public bool attackPressed;
    public bool dashPressed;
    public bool stancePressed;

    public float horizontal;
    public float vertical;

    internal void SetButtons()
    {
        attackButton = "Attack";
        dashButton = "Dash";
        stanceButton = "Stance";
        horizontalAxis = "Horizontal";
        verticalAxis = "Vertical";
    }

    private void Update()
    {
        attackPressed = Input.GetButton(attackButton);
        dashPressed = Input.GetButton(dashButton);
        stancePressed = Input.GetButton(stanceButton);

        horizontal = Input.GetAxisRaw(horizontalAxis);
        vertical = Input.GetAxisRaw(verticalAxis);
    }

    internal bool ButtonDown(Enum_PlayerButton button)
    {
        switch (button)
        {
            case Enum_PlayerButton.Attack:
                return attackPressed;
            case Enum_PlayerButton.Dash:
                return dashPressed;
            case Enum_PlayerButton.Stance:
                return stancePressed;
            default:
                return false;
        }
    }

    internal bool AnyButtonDown()
    {
        return attackPressed;
    }

    internal Vector2 GetDirection()
    {
        return new Vector2(horizontal, vertical);
    }
}
