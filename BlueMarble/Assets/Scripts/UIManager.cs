using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
* 
* UIManager
*  - 어떤 시점에 씬을 이동 하도록 호출하는 기능 Controller / EventListener
*  - 씬 이동 관리 
*  - UI와 관련된 오브젝트를 들고있음 
*/
public class UIManager : MonoBehaviour
{
    // 주사위 굴리기 버튼
    public Button RollDiceButton;
    public Button StartGameButton;

    // Start is called before the first frame update
    void Start()
    {

        // 게임 시작 버튼 클릭
        StartGameButton.onClick.AddListener(StartGameBtnClicked);


        // [주사위 굴리기] 클릭 -> 씬 이동 -> DiceBoard
        RollDiceButton.onClick.AddListener(HandleRollDiceBtnClicked);


        // 주사위를 굴리고 숫자가 나오면 (DiceBoard) -> 씬 이동(PlayBoard)
        //
    }

    /**
     * Call a PlayBoard Scene
     */
    private void StartGameBtnClicked()
    {
        GameManager.Instance.LoadScene("PlayBoard");
    }


    /**
     * Call a DiceBoard Scene 
     */
    private void HandleRollDiceBtnClicked()
    {
        GameManager.Instance.LoadScene("DiceRoom");
    }

    // Update is called once per frame
    void Update()
    {

    }
}