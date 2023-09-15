using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public DiceSide[] DiseSides;

    // �ֻ����� ���� 
    public int DiceNumber { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // �ֻ����� ������ ���� ���ڸ� �����´�
    // �ٴ��� ���� �ֻ��� ���� ���ؼ�
    void SideNumberCheck()
    {
        Debug.Log("Call Number Check");
        DiceNumber = 0;

        foreach(DiceSide number in DiseSides)
        {
            if (number.GetOnGround())
            {
                DiceNumber = number.SideValue;
                Debug.Log($"{DiceNumber} has been rolled");
            }
        }

    }

}
