using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float spawnRadius = 5f;

    [Header("References")]
    [SerializeField] private GameObject enemyPrefab;


    void Start()
    {
        transform.localScale = new Vector3(spawnRadius, spawnRadius, 1);

        StartCoroutine(StartSpawningEnemies());
    }

    IEnumerator StartSpawningEnemies(){
        var randomDuration = Random.Range(1f, 5f);
        yield return new WaitForSeconds(randomDuration);

        while (true){
            yield return new WaitForSeconds(4f);
            SpawnEnemy();
        }
    }

    void SpawnEnemy(){
        var randomPosition = Random.insideUnitCircle * (spawnRadius -1f);
        var enemy = Instantiate(enemyPrefab, transform.position + new Vector3(randomPosition.x, randomPosition.y, 0), Quaternion.identity);
        enemy.transform.parent = transform;
    }

    
}
