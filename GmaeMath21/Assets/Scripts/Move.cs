using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        /*
        transform.position = new Vector3(0, 0, 0);
        transform.Translate(new Vector3 (0, 1, 0));
        transform.position = new Vector2(1,1);
        */
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(1, 1, 1));

        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");

        //Vector3 direction = new Vector3(movex, movey, 0).normalized;
        float di = Mathf.Sqrt(movex * movex + movey * movey + 0 * 0);
        
        //0일때 예외처리
        if (di != 0)
        {
            Vector3 no = new Vector3(movex / di, movey / di, 0);
            Vector3 move = no * speed * Time.deltaTime;
            transform.position += move;
        }
    }
}
