using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Route CurrentRoute;

    // 이동해야하는 칸 수
    public int Steps;

    private int RoutePosition;

    private bool IsMoving;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsMoving)
        {
            //주사위 굴리기
            Steps = Random.Range(1, 4);
            Debug.Log("Dice Rolled ::" + Steps);

            StartCoroutine(Move());

            //if (RoutePosition + Steps < CurrentRoute.ChildNodeList.Count)
            //{
            //    StartCoroutine(Move());
            //}
            //else
            //{
            //    Debug.Log("Rolled Number is to high");
            //}

        }
    }


    IEnumerator Move()
    {
        if (IsMoving)
        {
            yield break;
        }
        IsMoving = true;

        while (Steps > 0)
        {
            RoutePosition++;
            RoutePosition %= CurrentRoute.ChildNodeList.Count;

            Debug.Log($"CurrentRoute::{CurrentRoute} , RoutePosition: {RoutePosition}");

            Vector3 nextPosition = CurrentRoute.ChildNodeList[RoutePosition].position;

            Debug.Log($"nextPosition: {nextPosition}");

            while(MoveToNextNode(nextPosition))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            Steps--;
            //RoutePosition++;
        }
        IsMoving = false;
    }

    bool MoveToNextNode(Vector3 goal)
    {
        // goal에 도달하면 return true
        // 속도 : 3f * Time.deltaTime
        return goal != (transform.position = Vector3.MoveTowards
            (transform.position, goal, 3f * Time.deltaTime));
    }

}
