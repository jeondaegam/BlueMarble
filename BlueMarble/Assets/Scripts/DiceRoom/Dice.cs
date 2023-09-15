using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public DiceSide[] DiseSides;

    // 주사위의 숫자 
    public int DiceNumber { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 주사위를 굴려서 나온 숫자를 가져온다
    // 바닥의 닿은 주사위 면을 통해서
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
