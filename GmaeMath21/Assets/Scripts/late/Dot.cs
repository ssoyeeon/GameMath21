using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    public Transform player;
    public float viewAngle = 60f;

    // Update is called once per frame
    void Update()
    {
        //dot = a.x*b.x+a.y*b.y+a.z*b.z
        Vector3 toPlayer = (player.position - transform.position).normalized;
        Vector3 forward = transform.forward;
        float doot = player.position.x * transform.position.x + player.position.y * transform.position.y + player.position.z * transform.position.z;
        //float dot = Vector3.Dot(forward, toPlayer); 
        float angle = Mathf.Acos(doot) * Mathf.Rad2Deg;

        if(angle<viewAngle /2)
        {
            Debug.Log("플레이어가 시야 안에 있음!");
        }
        
    }
}
