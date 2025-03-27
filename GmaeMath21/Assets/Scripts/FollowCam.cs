using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    //Eular 사용해서 회전 방향에 맞게 offset 적용
    //LookAt 으로 캐릭터 향하게
    //LateUpdate 로 Update에서 캐릭터 움직인 후에 오기

    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -4);
    public float smoothSpeed = 5f;
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + Quaternion.Euler(0, target.eulerAngles.y, 0) * offset;
        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
