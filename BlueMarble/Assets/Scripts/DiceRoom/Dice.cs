using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    Rigidbody Rb;
    Vector3 InitPosition;

    private bool hasLanded;
    private bool isThrown;

    public DiceSide[] DiseSides;

    private void Awake()
    {
        //게임 시작 후 씬이 변경되더라도 Instance를 유지해야함
        DontDestroyOnLoad(gameObject);
    }

    public bool HasLanded()
    {
        return hasLanded;
    }

    public bool IsThrown()
    {
        return isThrown;
    }



    // 주사위의 숫자 
    public int DiceNumber { get; private set; }

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        // 주사위의 초기 위치를 들고온다
        InitPosition = transform.position;
        Rb.useGravity = false;
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

        foreach (DiceSide number in DiseSides)
        {
            if (number.GetOnGround())
            {
                DiceNumber = number.SideValue;
                Debug.Log($"{DiceNumber} has been rolled");
            }
        }

    }

    // 주사위를 던진다.
    internal void Roll()
    {
        Debug.Log("Call Dice.Roll");
        // 던져진 상태가 아니면?
        //if (!IsThrown && !HasLanded)
        //{
        isThrown = true;
        Rb.useGravity = true;
        Rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        //} 
        // 던져진 상태라면?
        //else
        //{
        //    Reset();
        //    Debug.Log("Why need to reset?");
        //}
    }

    // 주사위의 위치를 리셋한다
    public void Reset()
    {
        transform.position = InitPosition;
        isThrown = false;
        hasLanded = false;
        Rb.useGravity = false;
    }
}
