using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDiceRoom : MonoBehaviour
{

    public Button RollingDiceButton;
    public DiceRoom DiceRoom;
    public TextMeshPro DiceNumberText;

    public UIStatus DiceNumber;

    private void OnEnable()
    {
        //DiceRoom = GetComponent<DiceRoom>();
        // Update UI
        //DiceNumber.UpdateUI(GameManager.Instance.Dice.DiceNumber.ToString());
        //UpdateNumber();

        GameManager.Instance.Dice.OnNumberChanged += UpdateDiceNumberUI;

        // Listener
        // 주사위 굴리기 버튼 클릭 ㅇ
        RollingDiceButton.onClick.AddListener(OnRollingDiceBtnClicked);

    }

    private void OnDisable()
    {
        RollingDiceButton.onClick.RemoveListener(OnRollingDiceBtnClicked);

    }



    // Start is called before the first frame update
    void Start()
    {
        
        // Dice Renderer enable
        GameManager.Instance.Dice.gameObject.GetComponent<MeshRenderer>()
            .enabled = enabled;
        // 버튼 클릭말고 스페이스바로 구현하면 좋을듯 -> 오래 누를수록 +게이지 
        //RollingDiceButton.onClick.AddListener(OnRollingDiceBtnClicked);
        //StartCoroutine(UIUpdate());
    }

    private void OnRollingDiceBtnClicked()
    {
        DiceRoom.RollDice();
        Debug.Log($"Number is {GameManager.Instance.Dice.DiceNumber}");
        //UpdateNumber();
    }


    private void UpdateDiceNumberUI()
    {
        DiceNumberText.text =
            "Number :" + GameManager.Instance.Dice.DiceNumber.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
