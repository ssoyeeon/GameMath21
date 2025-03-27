using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRatation : MonoBehaviour
{
    public float rotationSpeed = 90f;

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(0, input * rotationSpeed * Time.deltaTime, 0);
        //transform.Rotate(0, 45 * Time.deltaTime, 0); 
    }
}
