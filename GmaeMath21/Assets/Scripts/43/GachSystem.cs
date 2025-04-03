using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaSystem : MonoBehaviour
{
    public TMP_Text re;
    public Button one;
    public Button ten;

    private void Start()
    {
        one.onClick.AddListener(SinglePull);
        ten.onClick.AddListener(TenPull);
    }

    void SinglePull()
    {
        string result = GetGachaResult();
        re.text = "»Ì±â °á°ú: " + result;
    }

    void TenPull()
    {
        List<string> results = new List<string>();

        for (int i = 0; i < 9; i++)
        {
            results.Add(GetGachaResult());
        }

        results.Add(GetGuaranteedAorHigher());

        re.text = "10:\n" + string.Join(", ", results);
    }

    string GetGachaResult()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue < 40f) return "C";
        else if (randomValue < 70f) return "B";
        else if (randomValue < 90f) return "A";
        else return "S";
    }

    string GetGuaranteedAorHigher()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue < 80f) return "A";
        else return "S";
    }
}