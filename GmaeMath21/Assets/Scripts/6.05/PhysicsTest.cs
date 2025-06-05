using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class PhysicsTest : MonoBehaviour
{
    bool isEnd;     //false 일 경우 플레이어 1
    Rigidbody rbb;
    public Rigidbody p1;
    public Rigidbody p2;

    // Start is called before the first frame update
    void Start()
    {
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rbb != null)
        {
            if (rbb.velocity.magnitude <= 0.1 && isEnd == false)
            {
                isEnd = true;
                Debug.Log("Stop");
            }

        }

        if (Input.GetMouseButtonDown(0) && rbb.velocity.magnitude <= 0.1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Rigidbody rb = hit.collider.attachedRigidbody;
                rbb = rb;
                if ( rb != null && isEnd == false)
                {
                    Vector3 move =  hit.collider.transform.position - hit.point;
                    p1.AddForce(move * 40f, ForceMode.Impulse);
                }
                else if (rb != null && isEnd == true)
                {
                    Vector3 move = hit.collider.transform.position - hit.point;
                    p2.AddForce(move * 40f, ForceMode.Impulse);
                    isEnd = false;
                }
                
            }

        }
    }
}
