using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bezier : MonoBehaviour
{
    public Transform p0;

    public Transform p3;

    [Header("Random Ranges")]
    public float p1Radius = 2f;
    public float p1Height = 2f;
    public float p2Radius = 2f;
    public float p2Height = 2f;

    public Vector3 p1;
    public Vector3 p2;

    List<Vector3> points;
    float time = 0f;
    public BezierSpehee Sphere;

    [SerializeField] Transform target;
    [SerializeField] GameObject gameObjectTarget;
    public Vector3 offset = new Vector3(0f, 1f, -10f);
    [SerializeField] float smoothTime = 0.3f;       //반응속도 (짧을 수록 빠름)
    [SerializeField] float maxSpeed = 100f;     //시작 시 최고 속도
    Vector3 velocity = Vector3.zero;
    public LayerMask enemyLayer;
    float speed = 2f;
    bool isTarget;
    bool isClick;
    
    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime / 2f;

        if (Input.GetMouseButtonDown(0))
        {
            isTarget = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, enemyLayer))
            {
                target = hit.transform;
                gameObjectTarget = hit.collider.gameObject;
                Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);

                float t = 1f - Mathf.Exp(-speed * Time.deltaTime);
                transform.rotation = ManualSlerp(transform.rotation, lookRot, t);
                gameObjectTarget.gameObject.GetComponent<Renderer>().material.color = Color.red;
                for (int i = 0; i < 10; i++)
                {
                    BezierSpehee Sp = Instantiate(Sphere, this.transform.position, Quaternion.identity);
                    Sp.p0 = p0;
                    Sp.p3 = p3;
                    Sp.asd();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            gameObjectTarget.gameObject.GetComponent<Renderer>().material.color = Color.white;
            isTarget = false;
            //transform.position = new Vector3(0f,-1f,-10f);
            Destroy(Sphere);
            isClick = false;    
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
