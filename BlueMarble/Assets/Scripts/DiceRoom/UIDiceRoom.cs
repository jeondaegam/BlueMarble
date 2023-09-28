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
    public TextMeshProUGUI DiceNumberText;
    //public GameObject ParticleObj;

    //public UIStatus DiceNumber;

    private void OnEnable()
    {
        // 나온 숫자를 화면에 띄운다 -> UI Update
        GameManager.Instance.Dice.OnNumberChanged += UpdateDiceNumberUI;
        // 주사위 숫자 변경 -> 플레이보드로 씬 이동
        //GameManager.Instance.Dice.OnNumberChanged += MoveToPlayBoard;

        // 주사위 리셋 후 화면 전환
        GameManager.Instance.Dice.OnDiceReset += MoveToPlayBoard;

        // Event Listener
        // 주사위 굴리기 버튼 클릭
        RollingDiceButton.onClick.AddListener(OnRollingDiceBtnClicked);

        SceneManager.activeSceneChanged += OnSceneChanged;

    }

    private void OnSceneChanged(Scene prevScene, Scene currentScene)
    {
        Debug.Log("Dice room 씬으로 왔어용 ~ ");
        //Particle = FindObjectOfType<ParticleSystem>();
        //if (Particle.isPlaying)
        //{
        //    Particle.Stop();
        //}
        // 에러때문에 사용 못함
        // MissingReferenceException: The object of type 'RectTransform'
        // has been destroyed but you are still trying to access it.
        //if (GameManager.Instance.Particle.isPlaying)
        //{
        //    Debug.Log("파티클 멈춰 ");
        //    GameManager.Instance.Particle.Stop();
        //}
        //Debug.Log("호출은 되는?");
        //GameManager.Instance.Particle.Stop();
        //GameManager.Instance.Particle.enableEmission = false;

        // 중력 사용 X
        //GameManager.Instance.Stones[0].GetComponent<Rigidbody>().useGravity = !enabled;
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
        //Particle.Stop();
        //Particle = FindObjectOfType<ParticleSystem>();
    }

    private void OnRollingDiceBtnClicked()
    {
        DiceRoom.RollDice();
        //Debug.Log($"Number is {GameManager.Instance.Dice.DiceNumber}");
    }


    private void UpdateDiceNumberUI()
    {
        DiceNumberText.text = GameManager.Instance.Dice.DiceNumber.ToString();
        //if (!Particle.isPlaying)
        //{
        //    Particle.Play();
        //}

        //if (GameManager.Instance.Particle.isStopped)
        //{
        //    Debug.Log("파티클 실행 해 ");
        //    GameManager.Instance.Particle.Play();
        //}
        //GameManager.Instance.Particle.enableEmission = true;
    }

    private void MoveToPlayBoard()
    {
        GameManager.Instance.LoadScene("PlayBoard");
    }

}
