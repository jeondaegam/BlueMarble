using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{
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
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Roll();
        //}

        //if (rb.IsSleeping() && !hasLanded && isThrown)
        //{
        //    Debug.Log("여기?");
        //    hasLanded = true;
        //    rb.useGravity = false;
        //    DiceNumberCheck();
        //    Invoke("DiceNumberCheck", 3);
        //    new WaitForSeconds(3f);

        //}
        //if (rb.IsSleeping() && hasLanded && isThrown)
        //{
        //    Debug.Log("Roll Again");
        //    RollAgain();
        //}

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
        return DiceNumber;
    }

    // 주사위를 던진다.
    internal void Roll()
    {
        isThrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
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


//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.PackageManager.Requests;
//using UnityEngine;

//public class Dice : MonoBehaviour
//{
//    Rigidbody rb;

//    bool hasLanded;
//    bool thrown;
//    Vector3 initPosition;
//    public int diceValue;

//    public DiceSide[] diceSides;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        initPosition = transform.position;
//        rb.useGravity = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            RollDice();
//        }

//        if (rb.IsSleeping() && !hasLanded && thrown)
//        {
//            hasLanded = true;
//            rb.useGravity = false;
//            SideValueCheck();

//        }
//        else if (rb.IsSleeping() && hasLanded && diceValue == 0)
//        {
//            //RollAgain();
//        }

//    }


//    private void RollDice()
//    {
//        // ������ ���°� �ƴϸ� ������ 
//        if (!thrown && !hasLanded)
//        {
//            thrown = true;
//            rb.useGravity = true;
//            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
//            //SideValueCheck();
//            //rb.isKinematic = true;
//        }
//        else
//        {
//            Reset();
//        }
//    }

//    private void Reset()
//    {
//        transform.position = initPosition;
//        thrown = false;
//        hasLanded = false;
//        rb.useGravity = false;
//        //rb.isKinematic = false;
//    }

//    void SideValueCheck()
//    {
//        Debug.Log("Call value check");
//        diceValue = 0;
//        foreach (DiceSide side in diceSides)
//        {
//            //Debug.Log("in foreach");
//            //Debug.Log($"side number : {side.sideValue}");
//            if (side.GetOnGround())
//            {
//                diceValue = side.sideValue;
//                Debug.Log($"{diceValue} has been rolled!");
//            }
//        }
//    }


