using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPlayBoard : MonoBehaviour
{

    public Button RollingDiceButton;

    private void OnEnable()
    {
        // 씬이 로드되었을 때 step이 0 보다 크면 플레이어를 이동

        //GameManager.Instance.Dice.OnNumberChanged += MoveToPlayBoard;
        //SceneMASceneManager.activeSceneChanged += OnSceneChanged;

        SceneManager.activeSceneChanged += OnSceneChanged; // 얘만 설정하니까 씬이 로드될 때 & 다른씬으로 넘어갈때 2번 호출됨 
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged; // 그래서 얘를 추가함 
    }


    private void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        Debug.Log("Play Board로 왔어요 ~ ");
        GameManager.Instance.Stones[0].Steps = GameManager.Instance.Dice.DiceNumber;
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
        GameManager.Instance.LoadScene("DiceRoom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
