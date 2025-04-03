using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tan : MonoBehaviour
{
    public float angle = 0f;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {
        float radians = angle * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians));
        transform.position += direction * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.D))
        {
            angle += 15;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            angle -= 15;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            speed += 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed -= 1;
        }
    }
}
