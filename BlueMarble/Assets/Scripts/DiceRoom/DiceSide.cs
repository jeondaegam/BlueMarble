using UnityEngine;

public class DiceSide : MonoBehaviour
{
    // 반대쪽 면의 숫자 
    public int SideNumber;

    // 바닥과 맞닿은 면을 체크하는 변수
    private bool OnGround;

    private string GROUND = "Ground";


    /**
     * 
     * Object가 바닥과 맞닿아있는지 체크한다. 
     * - OnTriggerStay를 사용하려면 Object:Inspector > Check IsTrigger
     */

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(GROUND))
        {
            OnGround = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(GROUND))
        {
            OnGround = false;
        }
    }



    public bool GetOnGround()
    {
        return OnGround;
    }

}
