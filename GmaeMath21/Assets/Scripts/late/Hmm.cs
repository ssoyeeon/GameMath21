using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hmm : MonoBehaviour
{
    public Transform player;
    public float viewAngle = 60f;

    void Update()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized; //�礷�Ť��� �����ä��� �����ڤ��� 
        Vector3 forward = transform.forward;    //Vector3 0,0,1

        float dot = Vector3.Dot(forward, toPlayer);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if(angle < viewAngle/2)
        {
            Debug.Log("�ä��Ĥ��Ӥ��� Ž����");
        }
    }
}
