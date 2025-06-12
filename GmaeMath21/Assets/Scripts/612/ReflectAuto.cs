using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectAuto : MonoBehaviour
{
    public GameObject Pref;
    int e = 0;
    float cooltime = 0;

    Vector3 Power = new Vector3 (0f,0f,1f);
    Vector3 Direct = new Vector3 (1f,0f,0f);
    public Vector3 veloci = new Vector3(0f,-3f,4f);

    ReflectBall ball;

    private void Start()
    {
        e = 0;
    }

    void Update()
    {
        cooltime -= Time.deltaTime;

        if (cooltime <= 0)
        {
            cooltime = 0;
        }

        if (Input.GetKeyDown(KeyCode.Q) && cooltime <= 0)
        {
            ball = Instantiate(Pref, this.transform.position, Quaternion.identity).GetComponent<ReflectBall>();
            ball.velocity = veloci;
            cooltime = 2;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            veloci += Direct;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            veloci -= Direct;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            veloci += Power;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            veloci -= Power;
        }
    }
}
