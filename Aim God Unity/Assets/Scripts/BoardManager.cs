using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject targetPrefab;
    BoxCollider2D spawnArea;
    public float timeInBetweenTargets;
    public float timeIncrement;
   

    private void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        
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
}
