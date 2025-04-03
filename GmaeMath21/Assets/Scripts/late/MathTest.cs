using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTest : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        Vector3 playerforward = transform.forward;
        Vector3 toTarget = (target.position - transform.position).normalized;

        if(IsLeft(playerforward, toTarget , Vector3.up))
        {
            Debug.Log("Ÿ�Ԥ����� �ä��Ĥ��Ӥ��� ���֤� �ޤ��Ǥ��� �֤��Ѥ� ");
        }
        else
        {
            Debug.Log("Ÿ�Ԥ����� �ä��Ĥ��Ӥ��� ���֤� ���������Ǥ��� �֤��Ѥ� ");
        }
    }

    bool IsLeft (Vector3 forward, Vector3 targetDirection, Vector3 up)
    {
        Vector3 cross = Vector3.Cross(forward, targetDirection);
        return Vector3.Dot(cross, up) < 0;
    }
}
