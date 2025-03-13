using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseFollow3D : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 targetPosition;
    public Vector3 move;
    public Vector3 cubePosition;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
            }
        }
        Vector3 direction = targetPosition.normalized;
        transform.Translate(direction * speed * Time.deltaTime);
        
    }
}
