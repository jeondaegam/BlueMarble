using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public event Action OnGameClear;

    // 현재 위치
    public Route CurrentRoute;

    // 다음 칸의 위치: 이동할 때 마다 1칸씩 증가
    private int RoutePosition;

    // 이동해야하는 칸 수
    public int Steps;

    private bool IsMoving;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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

    public IEnumerator Move()
    {
        if (IsMoving)
        {
            yield break;
        }
        IsMoving = true;

        //Debug.Log($"Stone : Child Node Size: {CurrentRoute.ChildNodeList.Count}");

        while (Steps > 0) //1칸 이상이 남았을 때 
        {
            RoutePosition++;
            RoutePosition %= CurrentRoute.ChildNodeList.Count;

            Vector3 nextPosition = CurrentRoute.ChildNodeList[RoutePosition].position;

            //Debug.Log($"현재위치::{CurrentRoute.transform} , 목적지 : {RoutePosition}, 다음칸 : {NextNode}");
            //Debug.Log($"Steps: {Steps}");

            // 이동하기 전에 멈춰야함
            if (RoutePosition == 0)
            {
                Steps = 0;
                Debug.Log("게임 종료 Step:" + Steps);

                // 게임 클리어 이벤트 호출 
                if (OnGameClear != null)
                {
                    OnGameClear();
                }
                yield break;
            }

            while (MoveToNextNode(nextPosition))
            {
                yield return null;
            }

            yield return new WaitForSeconds(0.1f);
            Steps--;
        }
        IsMoving = false;
    }

    bool MoveToNextNode(Vector3 goal)
    {
        // goal에 도달하면 return true
        // 속도 : 3f * Time.deltaTime
        return goal != (transform.position = Vector3.MoveTowards
            (transform.position, goal, 2f * Time.deltaTime));
    }

}
