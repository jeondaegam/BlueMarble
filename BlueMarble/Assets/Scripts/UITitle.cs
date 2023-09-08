
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

    void Start()
    {
        StartGameButton.onClick.AddListener(StartGameBtnClicked);
    }

    /**
     * PlayBoard Scene 호출
     */
    private void StartGameBtnClicked()
    {
        GameManager.Instance.LoadScene("PlayBoard");
    }
}