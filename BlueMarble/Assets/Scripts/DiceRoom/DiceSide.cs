using UnityEngine;

public class DiceSide : MonoBehaviour
{
    // 반대쪽 면의 숫자 
    public int SideValue;

    // 바닥과 맞닿은 면을 체크하는 변수
    private bool OnGround;


    /**
     * 
     * Object가 바닥과 맞닿아있는지 체크한다. 
     * - OnTriggerStay를 사용하려면 Object:Inspector > Check IsTrigger
     */

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Call OnTriggerStay");
        Debug.Log($"-- side: {SideValue}");
        if(other.CompareTag(TagNames.Ground.ToString()))
        {
            OnGround = true;
        }
    }


    public bool GetOnGround()
    {
        return OnGround;
    }


    private enum TagNames
    {
        Ground,
    }

}

