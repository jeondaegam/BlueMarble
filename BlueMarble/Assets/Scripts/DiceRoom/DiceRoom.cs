using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoom : MonoBehaviour
{
    public Dice Dice;
    public void RollDice()
    {
        Debug.Log("Call Dice Room");
        // 던져지지 않은 상태라면?
        if (!GameManager.Instance.Dice.HasLanded() 
            && !GameManager.Instance.Dice.IsThrown())
        {
            //Dice.Roll();
            GameManager.Instance.Dice.Roll();
        }
        // 던져진 상태라면?
        else
        {
            GameManager.Instance.Dice.Reset();
            Debug.Log("Why need to reset?");
        }
    }
}
