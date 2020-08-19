using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private static Dictionary<PooledMonoBehaviour, Pool> pools = new Dictionary<PooledMonoBehaviour, Pool>();

    private Queue<PooledMonoBehaviour> objects = new Queue<PooledMonoBehaviour>();
    private PooledMonoBehaviour prefab;

    public static Pool GetPool(PooledMonoBehaviour prefabForPool)
    {
        if (pools.ContainsKey(prefabForPool)) // If a dictionary "pools" already contains this prefab. Skip everything else.
            return pools[prefabForPool];

        var poolGameObject = new GameObject("Pool-" + prefabForPool.name); // Create a new Empty Game Object (Name it Pools-"prefabname")
        var pool = poolGameObject.AddComponent<Pool>(); //Add .this script to the Prefab.
        pool.prefab = prefabForPool; //Get the prefab this script it attached to and set it to be the one we passed in.

        pools.Add(prefabForPool, pool); // Create the dictionary 
        return pool;
    }

    public T Get<T>() where T : PooledMonoBehaviour
    {
        if (objects.Count == 0)
        {
            GrowPool(); 
        }
        var pooledObject = objects.Dequeue();
        return pooledObject as T;
    }

    private void GrowPool()
    {
        for (int i = 0; i < prefab.InitialPoolSize; i++) 
        {
            var pooledObject = Instantiate(prefab) as PooledMonoBehaviour;
            pooledObject.gameObject.name += " " + i; 
            pooledObject.onReturnToPool += AddObjectToAvailableQueue;
            pooledObject.transform.SetParent(this.transform);
            pooledObject.gameObject.SetActive(false);
        }
    }

    private void AddObjectToAvailableQueue(PooledMonoBehaviour pooledObject)
    {
        pooledObject.transform.SetParent(this.transform);
        objects.Enqueue(pooledObject);
    }
}
