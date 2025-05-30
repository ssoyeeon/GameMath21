using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceSimulator : MonoBehaviour
{
    public int[] counts = new int[12];
    public int trials = 100;
    public TMP_Text[] One = new TMP_Text[12];
    public int max;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < trials; i++)
        {
            int result = Random.Range(1, max);
            counts[result - 1]++;
        }

        for (int i = 0; i < counts.Length; i++)
        {
            float percent = (float)counts[i] / trials * 100f;
            One[i].text = ($"{i + 1} : {counts[i]}회 ({percent:F2}%)");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
