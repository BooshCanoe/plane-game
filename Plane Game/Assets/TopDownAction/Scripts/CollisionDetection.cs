using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;
    [SerializeField]
    private float maxDistance = 5f;
    [SerializeField]
    private LayerMask layerMask;


    private void Update()
    {
        foreach (var position in positions)
        {
            checkForCollisions(position);
        }
    }

    private void checkForCollisions(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, foot.forward, maxDistance, layerMask);
        Debug.DrawRay(foot.position, foot.forward * maxDistance, Color.red);
    }
}
