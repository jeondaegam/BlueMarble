
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 
 * UITitle
 *  - Title Scened의 UI 관리  
 *  - UI와 관련된 오브젝트를 들고있음
 *  - 씬 이동 관리 
 */


public class UITitle : MonoBehaviour
{
    // 게임시작 버튼 
    public Button StartGameButton;

    // 캐릭터 선택 버튼
    //public Button[] Characters;

    void Start()
    {
        StartGameButton.onClick.AddListener(HandleStartGameBtnClicked);
        //Characters[].onClick.AddListener(On)
    }

    /**
     * PlayBoard Scene 호출
     */
    private void HandleStartGameBtnClicked()
    {
        GameManager.Instance.LoadScene("PlayBoard");
    }
}