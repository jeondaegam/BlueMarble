﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    // 현재 위치
    public Route CurrentRoute;

    // 다음 칸의 위치: 이동할 때 마다 1칸씩 증가
    private int RoutePosition;
    private int NextNode;

    // 이동해야하는 칸 수
    public int Steps;

    private bool IsMoving;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        //Steps = GameManager.Instance.Dice.DiceNumber; durl dlfeks wntjr 이거 없어도 됨 안

    }

    private void Start()
    {
        //Steps = GameManager.Instance.Dice.DiceNumber;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && !IsMoving)
        //if (GameManager.Instance.Dice.DiceNumber > 0 && !IsMoving)
        if (Steps > 0 && !IsMoving)
        {
            // 주사위 굴리기
            //Steps = Random.Range(1, 4);
            Steps = GameManager.Instance.Dice.DiceNumber;
            Debug.Log("Dice Rolled ::" + Steps);

            StartCoroutine(Move());
            //MoveStep();

        }
        //GameManager.Instance.Dice.OnNumberChanged += Move();
    }

    //private void MoveStep()
    //{
    //    IsMoving = true;
    //    while (Steps > 0)
    //    {
    //        Debug.Log(1);
    //        RoutePosition++;
    //        RoutePosition %= CurrentRoute.ChildNodeList.Count;
    //        //Debug.Log($"CurrentRoute::{CurrentRoute} , RoutePosition: {RoutePosition}");
    //        Debug.Log(2);
    //        Vector3 nextPosition = CurrentRoute.ChildNodeList[RoutePosition].position;

    //        Debug.Log(3);
    //        //Debug.Log($"nextPosition: {nextPosition}");

    //        if (MoveToNextNode(nextPosition))
    //        {
    //            Debug.Log(4);
    //            Steps--;
    //        }
    //    }
    //}

    public IEnumerator Move()
    {
        if (IsMoving)
        {
            yield break;
        }
        IsMoving = true;

        Debug.Log($"Stone : Child Node Size: {CurrentRoute.ChildNodeList.Count}");

        while (Steps > 0) //1칸 이상이 남았을 때 
        {
            RoutePosition++;
            RoutePosition %= CurrentRoute.ChildNodeList.Count;
            NextNode = RoutePosition + 1;


            Vector3 nextPosition = CurrentRoute.ChildNodeList[RoutePosition].position;

            Debug.Log($"현재위치::{CurrentRoute.transform} , 목적지 : {RoutePosition}, 다음칸 : {NextNode}");

            //if (RoutePosition == 0 || (RoutePosition == CurrentRoute.ChildNodeList.Count - 1))
            //{
            //    Steps = 1;
            //    Debug.Log("움직임 종료");
            //}

            if (NextNode == CurrentRoute.ChildNodeList.Count-1)
            {
                Steps = 1;
            }


            while (MoveToNextNode(nextPosition))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            Steps--;
            //RoutePosition++;
        }
        IsMoving = false;

        if (CurrentRoute.transform.position == CurrentRoute.ChildNodeList[CurrentRoute.ChildNodeList.Count-1].position)
        {
            Debug.Log("종료 지점 도착");
        }

    }

    bool MoveToNextNode(Vector3 goal)
    {
        // goal에 도달하면 return true
        // 속도 : 3f * Time.deltaTime
        return goal != (transform.position = Vector3.MoveTowards
            (transform.position, goal, 3f * Time.deltaTime));
    }

}
