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
     *  - 씬이 이동되더라도 계속 유지되어야하는 Player 정보 등을 저장
     *  - 실제 기능을 GameManager가 들고 있는다.      
     * */

    public static GameManager Instance;

    private AsyncOperation LoadingOp; // ?

    // 주사위
    public Dice Dice;

    // 플레이어
    public GameObject[] CharacterPrefabs;
    public Player[] Players;
    public int PlayerCount = 2;

    // 파티클
    public ParticleSystem Particle;

    public bool IsTestMode = false;

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
        SpawnPlayers();
        //Particle.Stop();
    }

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
        Players = new Player[CharacterPrefabs.Length];
        //Stones[0].GetComponent<Rigidbody>().useGravity = !enabled;

        for (int i = 0; i < CharacterPrefabs.Length; i++)
        {
            //Players[i] = Instantiate(Characters[i],
            //    Characters[i].transform.position, Characters[i].transform.rotation);
            // 캐릭터 리스트는 그냥 프리팹으로 받고
            // 캐릭터 오브젝트에 어떤 별도 기능(스크립트)가 필요없다면 그냥 오브젝트로 가져와 사용해도 되지만
            // 플레이어는 노드를 따라 칸을 이동하는 등의 별도 기능이 필요하므로 플레이어 스크립트가 적용된 Player type으로 받아야 한다 
            GameObject go = Instantiate(CharacterPrefabs[i],
                CharacterPrefabs[i].transform.position, CharacterPrefabs[i].transform.rotation);
            // 프리팹으로 가져온 캐릭터 오브젝트를 Plyaer 타입으로 만들어준다 
            Players[i] = go.GetComponent<Player>();
        }

    }

    public void LoadScene(string sceneName, bool activation = true)
    {
        LoadingOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        LoadingOp.allowSceneActivation = activation;
    }
}
