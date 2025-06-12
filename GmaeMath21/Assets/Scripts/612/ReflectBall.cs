using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectBall : MonoBehaviour
{
    float damping = 0.9f;
    public Vector3 gravity = new Vector3(0, -9.81f, 0);
    public Vector3 velocity = new Vector3(0f, -3f, 4f);
    int e = 0;

    void Update()
    {
        velocity += gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal.normalized;

        float Dot = Vector3.Dot(velocity, normal);
        Vector3 reflect = velocity - 2f * Dot * normal;

        velocity = reflect * damping;

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        e += 1;
        if (e == 3)
        {
            Destroy(this.gameObject);
            e = 0;
        }
        
    }
}
