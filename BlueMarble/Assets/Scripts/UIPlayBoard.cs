using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayBoard : MonoBehaviour
{

    public Button RollingDiceButton;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Dice.gameObject.SetActive(false);
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
