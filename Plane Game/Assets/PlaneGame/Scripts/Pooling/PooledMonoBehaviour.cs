using System;
using UnityEngine;

public class PooledMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    private int initialPoolSize = 50;

    public event Action<PooledMonoBehaviour> onReturnToPool;

    public int InitialPoolSize { get { return initialPoolSize; } }

    public T Get<T>(bool enable = true) where T : PooledMonoBehaviour
    {
        var pool = Pool.GetPool(this);
        var pooledObject = pool.Get<T>();

        if (enable)
        {
            pooledObject.gameObject.SetActive(true);
        }

        return pooledObject;
    }

    public T Get<T>(Vector3 position, Quaternion rotation) where T : PooledMonoBehaviour
    {
        var pooledObject = Get<T>();
        pooledObject.transform.position = position;
        pooledObject.transform.rotation = rotation;
        return pooledObject;
    }

    public T Get<T>() where T : PooledMonoBehaviour
    {
        Debug.Log("Got it");
        return null;
    }

    private void OnDisable()
    {
        if (onReturnToPool != null)
            onReturnToPool(this);
    }
}
