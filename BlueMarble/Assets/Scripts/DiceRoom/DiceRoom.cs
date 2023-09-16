using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoom : MonoBehaviour
{
    public Dice Dice;
    private Rigidbody Rb;
    public int DiceNumber;

    public void RollDice()
    {

        //// 던져지지 않은 상태라면?
        //if (!GameManager.Instance.Dice.hasLanded
        //    && !GameManager.Instance.Dice.IsThrown())
        //{
        //    Debug.Log("Roll");
        //    GameManager.Instance.Dice.Roll();
        //    GameManager.Instance.Dice.SideNumberCheck();
        //}

        //// 던져진 상태라면?
        //else
        //{
        //    GameManager.Instance.Dice.Reset();
        //}

        //GameManager.Instance.Dice.Roll();
        Dice.Roll();
        //GameManager.Instance.Dice.SideNumberCheck();

    }

    private void Start()
    {
        Dice = GameManager.Instance.Dice;
        Rb = GameManager.Instance.Dice.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if (Rb.IsSleeping()
        //    && !GameManager.Instance.Dice.HasLanded()
        //    && GameManager.Instance.Dice.IsThrown())
        //{
        //    Debug.Log("Side number check");
        //    GameManager.Instance.Dice.SwitchingHasLanded();
        //    GameManager.Instance.Dice.SwitchingIsThrown();
        //    GameManager.Instance.Dice.SideNumberCheck();
        //}
        //if (Rb.IsSleeping()
        //    && !GameManager.Instance.Dice.hasLanded
        //    && GameManager.Instance.Dice.isThrown )
        //{
        //    Debug.Log("ok");
        //    GameManager.Instance.Dice.hasLanded = true;
        //    Rb.useGravity = false;
        //    DiceNumber = GameManager.Instance.Dice.DiceNumberCheck();
        //    Debug.Log($"{DiceNumber} has been rolled!");
        //} else if (Rb.IsSleeping()
        //    && GameManager.Instance.Dice.hasLanded
        //    && GameManager.Instance.Dice.isThrown)
        //{
        //    Debug.Log("Roll Again");
        //    GameManager.Instance.Dice.RollAgain();
        //}
        if (!Dice.hasLanded && Rb.IsSleeping() && Dice.isThrown)
        {
            Dice.hasLanded = true;
            Rb.useGravity = false;
            DiceNumber = Dice.DiceNumberCheck();
            Debug.Log($"{DiceNumber} has been rolled!");

        } else if (Rb.IsSleeping() && Dice.isThrown)
             //else if (Rb.IsSleeping() && Dice.hasLanded && Dice.isThrown)
                {
            Debug.Log("Roll Again");
            Dice.RollAgain();
        }
    }

}
