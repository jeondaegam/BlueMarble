using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIDiceRoom : MonoBehaviour
{

    public Button RollingDiceButton;
    public DiceRoom DiceRoom;
    public TextMeshPro DiceNumberText;

    public UIStatus DiceNumber;

    private void OnEnable()
    {
        // 주사위 숫자 Update UI
        GameManager.Instance.Dice.OnNumberChanged += UpdateDiceNumberUI;
        // 주사위 숫자 변경 -> 플레이보드로 씬 이동
        GameManager.Instance.Dice.OnNumberChanged += MoveToPlayBoard;

        // Event Listener
        // 주사위 굴리기 버튼 클릭
        RollingDiceButton.onClick.AddListener(OnRollingDiceBtnClicked);

        SceneManager.activeSceneChanged += OnSceneChanged;

    }

    private void OnSceneChanged(Scene arg0, Scene arg1)
    {
        Debug.Log("Dice room 씬으로 왔어용 ~ ");
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
    }


    private void UpdateDiceNumberUI()
    {
        DiceNumberText.text =
            "Number :" + GameManager.Instance.Dice.DiceNumber.ToString();
    }

    private void MoveToPlayBoard()
    {
        GameManager.Instance.LoadScene("PlayBoard");
    }

}
