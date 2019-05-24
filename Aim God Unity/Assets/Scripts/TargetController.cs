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
        AudioManager.SharedInstance.PlayClip(Random.Range(4,8), "Target Hit", false);
        ArcadeMode.instance.AddTargetHit();
        GameObject bulletHoleGO = ObjectPooler.SharedInstance.GetPooledObject("Particle System");
        gameObject.SetActive(false);
        
    }
}
