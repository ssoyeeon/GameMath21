using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinCos : MonoBehaviour
{
    public float degrees = 0f;
    public float radianValue = 0f;
    // Start is called before the first frame update
    void Start()
    {
        float radians = degrees * Mathf.Deg2Rad;
        Debug.Log("45�� -> ���� : " + radians);

        //float radianV = Mathf.PI / radianValue;
        float degressValue = radianValue * Mathf.Rad2Deg;
        Debug.Log("����/3 -> ���� : " + degressValue);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
