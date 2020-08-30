using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : MonoBehaviour
{
    [SerializeField]
    private Enum_PlayerButton button;
    [SerializeField]
    private int abilityRefreshSpeed = 0;

    private float abilityTimer;
    private Controller controller;

    private bool canUse { get { return abilityTimer >= abilityRefreshSpeed; } }
    private bool active { get { return controller != null; } }
    protected abstract void onUse();

    private void Start()
    {
        controller = GetComponent<Controller>();
    }

    //Check when we've pressed the button
    private bool shouldTryUse()
    {
        return controller != null && canUse && controller.ButtonDown(button);
    }

    //Refresh cooldown and Activate the Ability
    private void Update()
    {
        abilityTimer += Time.deltaTime;

        if (shouldTryUse())
        {
            Debug.Log(button);
            onUse();
        }
    }
}
