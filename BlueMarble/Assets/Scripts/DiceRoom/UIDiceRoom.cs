using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDiceRoom : MonoBehaviour
{

    public Button RollingDiceButton;

    // Start is called before the first frame update
    void Start()
    {
        // 버튼 클릭말고 스페이스바로 구현하면 좋을듯 -> 오래 누를수록 +게이지 
        RollingDiceButton.onClick.AddListener(OnRollingDiceBtnClicked);
        
    }

    private void OnRollingDiceBtnClicked()
    {
        Debug.Log("Rolling Rollig");
        // 던전에서 공격버튼 클릭할 때와 같음 
        DiceRoom.RollingDice();
        // Dice.Rolling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
