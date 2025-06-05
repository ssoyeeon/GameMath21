using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PhysicsTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Rigidbody rb = hit.collider.attachedRigidbody;

                if ( rb != null)
                {
                    Vector3 move =  hit.collider.transform.position - hit.point;
                    rb.AddForce(move * 35f, ForceMode.Impulse);
                }
                
            }
        }
    }
}
