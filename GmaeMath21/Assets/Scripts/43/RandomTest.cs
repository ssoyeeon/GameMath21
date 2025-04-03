using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float chance = Random.value;
        int dice = Random.Range(1, 7);

        System.Random sysRand = new System.Random();
        int number = sysRand.Next(1, 7);
         
        System.Random rnd = new System.Random(1234);

        for(int i = 0; i < 5;  i++)
        {
            Debug.Log(rnd.Next(1, 7));
        }

        Debug.Log("Unity Random(Random.value)" + chance);
        Debug.Log("Unity Random(Random.Range)" + dice);
        Debug.Log("System Random(Next)" + number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
