using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHmm : MonoBehaviour
{
    public Transform A;
    public float viewAngle = 60f;
    public float viewDistence = 10f;

    void Update()
    {
        Vector3 toPlayer = (A.position - transform.position).normalized; //´ç¤·¤Å¤¤È÷ º¤¤¼¤Ã¤¡¤¿ ³ª¿À°Ú¤¸¤Ë 
        Vector3 forward = transform.forward;    //Vector3 0,0,1

        float dot = Vector3.Dot(forward, toPlayer);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (angle < viewAngle / 2)
        {
            Vector3 sad = transform.position - A.position;
            float saad = sad.magnitude;
            if(saad < viewDistence)
            {
                Debug.Log("Àû Å½Áö");
                A.localScale += new Vector3(0.001f, 0.001f, 0.001f);
            }
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            A.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
