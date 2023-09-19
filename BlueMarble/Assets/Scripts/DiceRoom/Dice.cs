using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
    // 주사위의 숫자가 바뀌면 호출한다.
    public event Action OnNumberChanged;

    // 주사위 위치 리셋 시 호출한다.
    public event Action OnDiceReset;

    private Rigidbody rb;
    private Vector3 InitPosition;

    public bool hasLanded;
    public bool isThrown;


    // 주사위의 숫자 
    public int DiceNumber { get; private set; }
    public DiceSide[] DiseSides;


    private void Awake()
    {
        //게임 시작 후 씬이 변경되더라도 Instance 유지
        DontDestroyOnLoad(gameObject);
    }

    //public bool HasLanded()
    //{
    //    return hasLanded;
    //}

    //public bool IsThrown()
    //{
    //    return isThrown;
    //}

    //public void SwitchingHasLanded()
    //{
    //    hasLanded = !hasLanded;
    //}

    //public void SwitchingIsThrown()
    //{
    //    isThrown = !isThrown;
    //}


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        // 주사위의 초기 Position
        InitPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
    }


    // 주사위를 굴려서 나온 숫자를 가져온다
    // 바닥의 닿은 주사위 면을 통해서
    public int DiceNumberCheck()
    {
        DiceNumber = 0;

        foreach (DiceSide number in DiseSides)
        {
            if (number.GetOnGround())
            {
                DiceNumber = number.SideNumber;
            }
        }
        if (OnNumberChanged != null)
        {
            Debug.Log($"complete event call!! {DiceNumber}");
            OnNumberChanged();
        }
        return DiceNumber;
    }

    // 주사위를 던진다.
    internal void Roll()
    {
        isThrown = true;
        rb.AddForce(new Vector3(0,-1,0)*100, ForceMode.Impulse);
        rb.useGravity = true;
        // 회전력, 비틀림 
        rb.AddTorque(Random.Range(0, 700), Random.Range(0, 500), Random.Range(0, 1000));
        //DiceNumberCheck();
    }

    // 주사위의 위치를 리셋한다
    public void Reset()
    {
        hasLanded = false;
        isThrown = false;
        rb.useGravity = false;
        transform.position = InitPosition;
    }

    public void RollAgain()
    {
        Reset();
        // 씬 전환하라는 이벤트를 호출 
        if (OnDiceReset != null)
        {
            Invoke("CallOnDiceResetEvent", 2);
        }
    }

    private void CallOnDiceResetEvent()
    {
        OnDiceReset();
    }

}