using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private void OnMouseDown()
    {
        TargetHit();
    }

    

    void TargetHit()
    {
        AudioManager.SharedInstance.PlayClip(1, "Target Hit", false);
        ArcadeMode.instance.AddTargetHit();
        gameObject.SetActive(false);
    }
}
