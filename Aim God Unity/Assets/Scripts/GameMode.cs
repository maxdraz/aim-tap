using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode : MonoBehaviour
{
    public float time;
    public int targetsHit =0;
    public event OnGameStart onGameStart;
    public event OnGameEnd onGameEnd;

    public delegate void OnGameStart();
    public delegate void OnGameEnd();
}
