using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    private int initialPoolSize = 50;

    public event Action<PooledMonoBehaviour> onReturnToPool;

    public int InitialPoolSize { get { return initialPoolSize; } }

    private void OnDisable()
    {
        if (onReturnToPool != null)
            onReturnToPool(this);
    }
}
