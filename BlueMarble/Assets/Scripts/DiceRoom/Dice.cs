using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{

    public event Action OnNumberChanged;

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
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 700), Random.Range(0, 500), Random.Range(0, 1000));
        //DiceNumberCheck();
    }

    // 주사위의 위치를 리셋한다
    public void Reset()
    {
        transform.position = InitPosition;
        isThrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }

    public void RollAgain()
    {
        Reset();
    }
}