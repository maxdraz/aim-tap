using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject targetPrefab;
    BoxCollider2D spawnArea;
    public float timeInBetweenTargets;
    public float timeIncrement;
    Animator anim;
   

    private void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();
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

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInBetweenTargets);
            SpawnNewTarget();            
        }
    }
    
    void SpawnNewTarget()
    {
        float ranX = Random.Range(spawnArea.bounds.min.x,spawnArea.bounds.max.x);
        float ranY = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);

        GameObject targetObj = ObjectPooler.SharedInstance.GetPooledObject("Target");
        targetObj.transform.position = new Vector3(ranX, ranY,transform.position.z -1);
        targetObj.SetActive(true);
    }    

    public void StartSpawningTargets()
    {
        StartCoroutine(SpawnTargets());
    }

    #region EVENTS

    void OnStartMeditation()
    {
        anim.SetBool("fade", true);
    }

    #endregion
}
