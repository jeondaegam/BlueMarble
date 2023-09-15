using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIDiceRoom : MonoBehaviour
{

    public Button RollingDiceButton;
    public DiceRoom DiceRoom;

    private void OnEnable()
    {
        // 주사위 굴리기 버튼 클릭 리스너 
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
        RollingDiceButton.onClick.AddListener(OnRollingDiceBtnClicked);
        
    }

    private void OnRollingDiceBtnClicked()
    {
        Debug.Log("Rolling Button Click");
        DiceRoom.RollDice();
        // Dice.Rolling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
