using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 3f;
    void Update()
    { // 이동 입력 저장
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        transform.Translate(moveX * moveSpeed * Time.deltaTime, 0, moveZ * moveSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 45 * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -45 * Time.deltaTime, 0);
        }

        if(transform.position.z > 28)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
