using System;

public class Stance : AbilityBase
{
    public static event Action onStanceChange = delegate { };

    protected override void onUse()
    {
        onStanceChange();
    }
}
