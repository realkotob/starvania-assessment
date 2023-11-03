using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starvania
{
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

        IEnumerator StartSpawningEnemies()
        {
            var randomDuration = Random.Range(1f, 5f);
            yield return new WaitForSeconds(randomDuration);

            while (true)
            {
                yield return new WaitForSeconds(4f);
                SpawnEnemy();
            }
        }

        void SpawnEnemy()
        {
            var randomPosition = Random.insideUnitCircle * (spawnRadius - 1f);
            var newPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);
            var positionIsInsideScreen = true;
            while (positionIsInsideScreen)
            {
                positionIsInsideScreen = false;
                if (newPosition.x > 8.5f || newPosition.x < -8.5f)
                {
                    positionIsInsideScreen = true;
                }

                if (newPosition.y > 4.5f || newPosition.y < -4.5f)
                {
                    positionIsInsideScreen = true;
                }
                randomPosition = Random.insideUnitCircle * (spawnRadius - 1f);
                newPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);
            }


            var enemy = Instantiate(enemyPrefab, newPosition, Quaternion.identity);
            enemy.transform.parent = transform;

          
      
        }


    }
}