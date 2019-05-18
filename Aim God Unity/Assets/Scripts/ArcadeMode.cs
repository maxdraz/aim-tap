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

    private void Update()
    {

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
}
