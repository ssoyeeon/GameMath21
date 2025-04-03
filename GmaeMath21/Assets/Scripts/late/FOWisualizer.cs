using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOWisualizer : MonoBehaviour
{
    public float viewAngle = 60f;
    public float viewDistance = 5f;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 forward = transform.forward * viewDistance;

        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2, 0) * forward;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2, 0) * forward;

        Gizmos.DrawRay(transform.position, leftBoundary);
        Gizmos.DrawRay(transform.position, rightBoundary);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, forward);
    }
}
