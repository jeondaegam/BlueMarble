using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    public event Action OnGameClear;

    public float rotationSpeed = 1.0f;
    //private Rigidbody rb;

    // 현재 위치
    public Route CurrentRoute;

    // 다음 칸의 위치: 이동할 때 마다 1칸씩 증가
    private int RoutePosition;

    // 이동해야하는 칸 수
    public int Steps;

    private bool IsMoving;

    //float h, v;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (GameManager.Instance.IsTestMode)
        {
            RollDiceWithSpaceBar();
        }

        else if (Steps > 0 && !IsMoving)
        {
            // 주사위 굴리기
            Steps = GameManager.Instance.Dice.DiceNumber;
            Debug.Log("Dice Rolled ::" + Steps);

            StartCoroutine(Move());
        }
        //GameManager.Instance.Dice.OnNumberChanged += Move();
        //Vector3 movementDirection = rb.velocity.normalized;

        //if (movementDirection != Vector3.zero)
        //{
        //    Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //}

    }

    private void RollDiceWithSpaceBar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsMoving)
        {
            Steps = Random.Range(1, 7);
            Debug.Log("TestMode Dice Rolled ::" + Steps);
            StartCoroutine(Move());
        }
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
