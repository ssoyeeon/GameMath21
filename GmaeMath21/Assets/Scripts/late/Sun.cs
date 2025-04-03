using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public Transform sunn;
    public float speed = 1f;
    public float angle = 0f;
    public float distance = 5f;
    void Update()
    {
        angle += Time.deltaTime * speed;
        float radians = angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(radians) * distance, 0, Mathf.Sin(radians) * distance);
        transform.position = sunn.position + direction;
    }
}
