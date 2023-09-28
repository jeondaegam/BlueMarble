using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
     * GameManager
     *  - Static한 정보들을 들고있는다. 
     *  - 씬이 이동되더라도 계속 유지되어야하는 Player 정보 등이 들어있다 . 
     *  - 실제 기능을 GameManager가 들고 있는다.      
     * */

    public static GameManager Instance;

    private AsyncOperation LoadingOp; // ?

    // 주사위
    public Dice Dice;

    // 플레이어
    public GameObject[] PlayerPrefabs;
    public Stone[] Stones;

    // 파티클
    public ParticleSystem Particle;

    // 경로
    //public GameObject Map;


    // 항상 메모리에 떠있고 다른 씬에서도 사용할 수 있도록 설정 
    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadDice();
        //LoadMap();
        SpawnPlayers();
        Particle.Stop();
    }

    //private void LoadMap()
    //{
    //    GameObject map = Instantiate(Map, Map.transform.position, Map.transform.rotation);
    //}

    //private void OnEnable()
    //{
    //    GameManager.Instance.Dice.OnNumberChanged += PlayParticle;
    //}

    //private void PlayParticle()
    //{
    //    if(Particle.isStopped)
    //    {
    //        Particle.Play();
    //    }
    //}

    private void LoadDice()
    {
        Dice = Instantiate(Dice, Dice.transform.position, Dice.transform.rotation);
    }


    private void SpawnPlayers()
    {
       for (int i=0; i <PlayerPrefabs.Length; i++)
        {
            GameObject go = Instantiate(PlayerPrefabs[i],
                PlayerPrefabs[i].transform.position, PlayerPrefabs[i].transform.rotation);
            Stones[i] = go.GetComponent<Stone>();
        }
        //Stones[0].GetComponent<Rigidbody>().useGravity = !enabled;
    }

    public void LoadScene(string sceneName, bool activation = true)
    {
        LoadingOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        LoadingOp.allowSceneActivation = activation;
    }
}
