using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArcadeMode : GameMode
{
    public static ArcadeMode instance;
    public Text targetsHitText;
    bool gameStarted;
    public BoardManager bm;
    public float countdownTime = 3f;

    public enum GameState
    {
        Start,
        meditation
    }

    public GameState gameState;

    [Space(20f)]

    public float targetsToStart = 20f;
    //DELEGATES
    public delegate void StartMeditation();
    public static event StartMeditation startMeditationEvent;
    

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        if (bm == null)
        {
            bm = GameObject.FindObjectOfType<BoardManager>();
        }
    }

    private void OnEnable()
    {
        startMeditationEvent += DelayMusic;
    }

    private void OnDisable()
    {
        startMeditationEvent -= DelayMusic;
    }

    private void Update()
    {
        // Start meditation 
        if(this.targetsHit >= targetsToStart && gameState == GameState.Start)
        {
            startMeditationEvent();
            gameState = GameState.meditation;
        }
    }

    public void StartGame()
    {
        print("game started");
        StartCoroutine(Countdown(countdownTime));
        gameStarted = true;
    }

    public void AddTargetHit()
    {
        this.targetsHit += 1;
        targetsHitText.text = targetsHit.ToString();
        
    }

    IEnumerator Countdown(float t)
    {

        for (int i = 0; i < t; i++)
        {
            yield return new WaitForSeconds(t / t);
            //update counter text here
            print(i + 1);
        }
        print("starting to spawn targets");
        bm.StartSpawningTargets();
    }

    //MUUUUUUSIC
    void DelayMusic()
    {
        Invoke("PlayMusic", 14f);
    }
    
    void PlayMusic()
    {
        AudioManager.SharedInstance.PlayClip(2, "Music", false);
    }
}
