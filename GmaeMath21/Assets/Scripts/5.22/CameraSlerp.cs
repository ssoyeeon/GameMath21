using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraSlerp : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject gameObjectTarget;
    public Vector3 offset = new Vector3(0f, 1f, -10f);
    [SerializeField] float smoothTime = 0.3f;       //�����ӵ� (ª�� ���� ����)
    [SerializeField] float maxSpeed = 100f;     //���� �� �ְ� �ӵ�
    Vector3 velocity = Vector3.zero;
     public LayerMask enemyLayer;
    float speed = 2f;
    bool isTarget;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isTarget = true;
            if(isTarget == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 100f, enemyLayer))
                {
                    target = hit.transform;
                    gameObjectTarget = hit.collider.gameObject;
                    Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);

                    float t = 1f - Mathf.Exp(-speed * Time.deltaTime);
                    transform.rotation = ManualSlerp(transform.rotation, lookRot, t);
                    gameObjectTarget.gameObject.GetComponent<Renderer>().material.color = Color.red;

                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            gameObjectTarget.gameObject.GetComponent<Renderer>().material.color = Color.white;
            isTarget = false;
            //transform.position = new Vector3(0f,-1f,-10f);
        }
    }

    //ī�޶� Ư�� ��ġ���� �̵��ϴ� ����
    private void LateUpdate()
    {
        if (!target) return;
        if(isTarget == true)
        {
            Vector3 desired = target.position + target.TransformDirection(offset);
            transform.position = Vector3.SmoothDamp(
                transform.position,
                desired,
                ref velocity,
                smoothTime,
                maxSpeed,
                Time.deltaTime);
        }
    }
    Quaternion ManualSlerp(Quaternion from, Quaternion to, float t)
    {
        float dot = Quaternion.Dot(from, to);
        if (dot < 0f)
        {
            to = new Quaternion(-to.x, -to.y, -to.z, -to.w);
            dot = -dot;
        }
        float theta = Mathf.Acos(dot);
        float sinTheta = Mathf.Sin(theta);

        float ratioA = Mathf.Sin((1f - t) * theta) / sinTheta;
        float ratioB = Mathf.Sin(t * theta) / sinTheta;

        Quaternion result = new Quaternion(
            ratioA * from.x + ratioB * to.x,
            ratioA * from.y + ratioB * to.y,
            ratioA * from.z + ratioB * to.z,
            ratioA * from.w + ratioB * to.w
        );
        return result.normalized;
    }
}
