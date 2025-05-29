using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bezier : MonoBehaviour
{
    public Transform point0;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public GameObject sphere;

    float timeValue = 0f;

    [SerializeField] Transform target;
    [SerializeField] GameObject gameObjectTarget;
    public LayerMask enemyLayer;
    float speed = 2f;
    bool isTarget;

    // Update is called once per frame
    void Update()
    {
        timeValue += Time.deltaTime / 2f;
        sphere.transform.position = GetPointOnBezierCurve(point0.position, point1.position, point2.position, point3.position, timeValue);

        if (Input.GetMouseButtonDown(0))
        {
            isTarget = true;
            if (isTarget == true)
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
        if (Input.GetMouseButtonDown(1))
        {
            gameObjectTarget.gameObject.GetComponent<Renderer>().material.color = Color.white;
            isTarget = false;
            //transform.position = new Vector3(0f,-1f,-10f);
        }
    }
    Vector3 GetPointOnBezierCurve(Vector3 p0 , Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        Vector3 c = Vector3.Lerp(p2, p3, t);
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        Vector3 abc = Vector3.Lerp(ab, bc, t);

        return abc;

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
