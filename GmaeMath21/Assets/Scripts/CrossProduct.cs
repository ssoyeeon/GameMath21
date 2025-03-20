using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProduct : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerForward = transform.forward;
        Vector3 toTarget = (target.position - transform.position).normalized;

        if(IsLeft(playerForward, toTarget,Vector3.up))
        {
            Debug.Log("���ʿ� �ֳ׿�");
        }
        else
        {
            Debug.Log("�����ʿ� �ֳ׿�");
        }
    }
    
    bool IsLeft(Vector3 forward, Vector3 targetDirection, Vector3 up)
    {
        Vector3 cross = Vector3.Cross(forward, targetDirection);
        return Vector3.Dot(cross, up) > 0;
    }
}
