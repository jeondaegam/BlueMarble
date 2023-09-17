using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayBoard : MonoBehaviour
{

    public Button RollingDiceButton;

    private void OnEnable()
    {
        //GameManager.Instance.Dice.OnNumberChanged += MoveToPlayBoard;
    }

    private void MoveToPlayBoard()
    {
        //Stone.Move
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.Dice.gameObject.SetActive(false); -> 주사위룸에서 active되어 방으로 다시 나오면 상태유지되나?
        RollingDiceButton.onClick.AddListener(HandleRollingDiceBtnClicked);
    }

    private void HandleRollingDiceBtnClicked()
    {
        Debug.Log("go to dice room");
        GameManager.Instance.LoadScene("DiceRoom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
