using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asd : MonoBehaviour
{
    public float viewAngle = 60f;
    public float viewDistance = 5f;
    public float rotation = 45f;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotation * Time.deltaTime, 0);
        Vector3 toPlayer = (player.position - transform.position).normalized; //´ç¤·¤Å¤¤È÷ º¤¤¼¤Ã¤¡¤¿ ³ª¿À°Ú¤¸¤Ë 
        Vector3 forward = transform.forward;    //Vector3 0,0,1

        float dot = Vector3.Dot(forward, toPlayer);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (angle < viewAngle / 2)
        {
            Vector3 sad = transform.position - player.position;
            float saad = sad.magnitude;
            if (saad < viewDistance)
            {
                Debug.Log("Àû Å½Áö");
                player.position = new Vector3(0, 0, -20);
            }
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
