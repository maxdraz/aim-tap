using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ArcadeMode.startMeditationEvent += OnStartMeditation;
    }

    private void OnDisable()
    {
        ArcadeMode.startMeditationEvent -= OnStartMeditation;
    }

    void OnStartMeditation()
    {
        anim.SetBool("fade", true);
    }


}
