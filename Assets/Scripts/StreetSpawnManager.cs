using System;
using System.Collections.Generic;
using UnityEngine;

public class StreetSpawnManager : MonoBehaviour
{
    public List<StreetSpawnPoint> spawnPoints;
    public GameObject prefabToSpawn;

    public void Awake()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (spawnPoints == null || spawnPoints.Count == 0)
            return;

        int randIndex = UnityEngine.Random.Range(0,spawnPoints.Count);
        Vector2 randomSpawnPosition = spawnPoints[randIndex].spawnTransform.position;

        GameObject enemyGameObject = GameObject.Instantiate(prefabToSpawn);
        enemyGameObject.transform.position = randomSpawnPosition;

        RunningEnemy enemy = enemyGameObject.GetComponent<RunningEnemy>();
        if(enemy == null)
        {
            Debug.Log("ERRORE: Stai provando a spawnare un nemico non valido");
            Destroy(enemyGameObject);
            return;
        }

        enemy.Init(spawnPoints[randIndex].targetTransform.position);

    }

}


[Serializable]
public class StreetSpawnPoint
{
    public Transform spawnTransform;
    public Transform targetTransform;
}