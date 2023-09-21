using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    Transform[] ChildObjects;
    public List<Transform> ChildNodeList = new List<Transform>();

    // 기즈모로 필드를 연결한다.
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        FillNodes();

        for (int i = 0; i < ChildNodeList.Count; i++)
        {
            // i번째 자식노드 A의 position을 들고온다
            Vector3 currentNode = ChildNodeList[i].position;
            if (i > 0)
            {
                // A의 이전노드 position을 들고온다
                Vector3 prevNode = ChildNodeList[i - 1].position;

                // 이전 노드에서 현재 노드 위치까지 선을 긋는다
                Gizmos.DrawLine(prevNode, currentNode);
            }
        }
    }

    void FillNodes()
    {
        ChildNodeList.Clear();
        // 모든 Child Node의 위치정보를 가져온다.
        ChildObjects = GetComponentsInChildren<Transform>();

        foreach(Transform child in ChildObjects)
        {
            if (child != this.transform)
            {
                ChildNodeList.Add(child);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FillNodes();
        Debug.Log("Route : ChildeList size" + ChildNodeList.Count);
    }
}
