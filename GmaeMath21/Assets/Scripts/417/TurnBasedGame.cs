using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnBasedGame : MonoBehaviour
{
    [SerializeField] float critChance = 0.2f;
    [SerializeField] float meanDamage = 20f;
    [SerializeField] float stdDevDamage = 5f;
    [SerializeField] float enemyHP = 100f;
    [SerializeField] float poissonLambda = 2f;
    [SerializeField] float hitRate = 0.6f;
    [SerializeField] float critDamageRate = 2f;
    [SerializeField] int maxHitsPerTurn = 5;
    [SerializeField] float minReward = 0.2f;

    public TMP_Text turnText;
    public TMP_Text rareText;
    public TMP_Text critText;
    public TMP_Text WeaponText;
    public TMP_Text ArmorText;
    public TMP_Text rareItemText;

    private int WeaponItem;
    private int Armoritem;
    private int rareItem;

    int turn = 0;
    bool rareItemObtained = false;

    string[] rewards = { "Gold", "Weapon", "Armor", "Potion" };

    public void StartSimulation()
    {
        // ���Ϻ��� ���ø�: ���� �������� ���� ������ �ݺ��ϴ� ����
        rareItemObtained = false;
        turn = 0;
        while (!rareItemObtained)
        {
            SimulateTurn();
            turn++; 
            minReward += 0.1f;
            //��������� ȹ�� Ȯ���� 10�� �÷�����. 
        }

        Debug.Log($"Rare item {turn} turn get");
        rareText.text = $"Rare item {turn} turn get";
    }

    void SimulateTurn()
    {
        Debug.Log($"--- Turn {turn + 1} ---");
        turnText.text = $"Turn {turn + 1}";
        // Ǫ�Ƽ� ���ø�: �� ���� ��
        int enemyCount = SamplePoisson(poissonLambda);
        Debug.Log($"enemy!! : {enemyCount}");

        for (int i = 0; i < enemyCount; i++)
        {
            // ���� ���ø�: ���� Ƚ��
            int hits = SampleBinomial(maxHitsPerTurn, hitRate);
            float totalDamage = 0f;

            for (int j = 0; j < hits; j++)
            {
                float damage = SampleNormal(meanDamage, stdDevDamage);

                // �������� ���� ���ø�: Ȯ�� ��� ġ��Ÿ �߻�
                if (Random.value < critChance)
                {
                    damage *= critDamageRate;
                    Debug.Log($"Critical hit! {damage:F1}");
                    critText.text = $"Critical hit! {damage:F1}";
                }
                else
                {
                    Debug.Log($" hit! {damage:F1}");

                }

                totalDamage += damage;
            }

            if (totalDamage >= enemyHP)
            {
                Debug.Log($"enemy {i + 1} die! (damage : {totalDamage:F1})");

                // �յ� ���� ���ø�: ���� ����
                string reward = rewards[UnityEngine.Random.Range(0, rewards.Length)];
                Debug.Log($"reward : {reward}");

                if (reward == "Weapon" && Random.value < minReward)
                {
                    rareItemObtained = true;
                    WeaponItem += 1;
                    Debug.Log("���� ���� ȹ��!");
                    WeaponText.text = "Rare Weapon Get";
                    ArmorText.text = "";
                }
                else if (reward == "Armor" && Random.value < minReward)
                {
                    rareItemObtained = true;
                    Armoritem += 1;
                    Debug.Log("���� �� ȹ��!");
                    ArmorText.text = $"Rare Armor Get";
                    WeaponText.text = "";
                }
                rareItem = WeaponItem + Armoritem;
                rareItemText.text = $"rareItem int : {rareItem}";
            }
        }
    }

    // --- ���� ���� �Լ��� ---
    int SamplePoisson(float lambda)
    {
        int k = 0;
        float p = 1f;
        float L = Mathf.Exp(-lambda);
        while (p > L)
        {
            k++;
            p *= Random.value;
        }
        return k - 1;
    }

    int SampleBinomial(int n, float p)
    {
        int success = 0;
        for (int i = 0; i < n; i++)
            if (Random.value < p) success++;
        return success;
    }

    float SampleNormal(float mean, float stdDev)
    {
        float u1 = Random.value;
        float u2 = Random.value;
        float z = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos(2.0f * Mathf.PI * u2);
        return mean + stdDev * z;
    }
}