using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoom : MonoBehaviour
{
    private Dice Dice;
    private Rigidbody Rb;
    public int DiceNumber = 0;

    public void RollDice()
    {
        Dice.Roll();
        //StartCoroutine(DiceReset());

    }

    private void Start()
    {
        Dice = GameManager.Instance.Dice;
        Rb = GameManager.Instance.Dice.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!Dice.hasLanded && Rb.IsSleeping() && Dice.isThrown)
        {
            Dice.hasLanded = true;
            Rb.useGravity = false;
            DiceNumber = Dice.DiceNumberCheck();
            Debug.Log($"{DiceNumber} has been rolled!");

        }
        else if (Rb.IsSleeping() && Dice.isThrown)
        //else if (Rb.IsSleeping() && Dice.hasLanded && Dice.isThrown)
        {
            Debug.Log("Roll Again");
            Dice.RollAgain();
        }
    }

    //IEnumerator DiceReset()
    //{
    //    Debug.Log("Call coroutine");
    //    yield return new WaitForSeconds(2f);

    //    if (!Dice.hasLanded && Rb.IsSleeping() && Dice.isThrown)
    //    {
    //        Debug.Log("요기1");
    //        Dice.hasLanded = true;
    //        Rb.useGravity = false;
    //        DiceNumber = Dice.DiceNumberCheck();
    //        Debug.Log($"{DiceNumber} has been rolled!");

    //    }
    //    else if (Rb.IsSleeping() && Dice.isThrown)
    //    else if (Rb.IsSleeping() && Dice.hasLanded && Dice.isThrown)
    //            {
    //                Debug.Log("Roll Again");
    //                Dice.RollAgain();
    //            }
    //}

}
