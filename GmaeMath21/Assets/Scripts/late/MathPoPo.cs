using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathPoPo : MonoBehaviour
{
    public float viewAngle = 60f;
    public float viewDistance = 5f;
    public float rotation = 45f;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotation * Time.deltaTime, 0);
        Vector3 toPlayer = (player.position - transform.position).normalized;
        Vector3 forward = transform.forward;
        float dot = Vector3.Dot(forward, toPlayer); 
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (angle < viewAngle / 2)
        {
            Debug.Log("플레이어가 시야 안에 있음!");
        }
    }
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
