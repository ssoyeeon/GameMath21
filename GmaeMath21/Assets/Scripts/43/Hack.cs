using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hack : MonoBehaviour
{
    public int trials = 100;
    public float counts;          //��ü ����
    public float CriticalCounts = 0;  //ũ��Ƽ�� ȸ��
    public TMP_Text Oe;     //�ۼ�Ʈ �����ֱ�
    public TMP_Text Oi;     //ũ��Ƽ�� ������
    public TMP_Text Oq;     //�߻��� ũ��Ƽ�� ȸ��
    public TMP_Text Ow;     //��ü ���� ȸ��
    public TMP_Text Oy;     //��ü ���� ȸ��
    public void Rads()
    {
        if( CriticalCounts + 1 / counts + 1 < 0.1f  && counts !=0 )
        {
            Oi.text = "Critical";
            CriticalCounts += 1;
            Oq.text = CriticalCounts.ToString();
            Oe.text = "10";
        }
        else if(CriticalCounts / counts + 1 > 0.1)
        {
            Oi.text = "Fail";
        }
        else
        {
            float number = Random.Range(0f, 1f);
            Debug.Log(number);
            float percent = (float)number / trials * 100f;
            if (number < 0.1)
            {
                CriticalCounts += 1;
                Oq.text = CriticalCounts.ToString();
            }
            Oe.text = percent.ToString();
        }
        counts += 1;
        float asa = counts / CriticalCounts;
        Oy.text = asa.ToString();
        Ow.text = counts.ToString();
    }
}
