using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoom : MonoBehaviour
{
    public Dice Dice;
    public void RollDice()
    {
        // 던져지지 않은 상태라면?
        if (!Dice.HasLanded() && !Dice.IsThrown())
        {
            Dice.Roll();
        }
        // 던져진 상태라면?
        else
        {
            Dice.Reset();
            Debug.Log("Why need to reset?");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
