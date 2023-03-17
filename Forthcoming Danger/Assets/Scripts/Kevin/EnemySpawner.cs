//Kevin Connell STrain 1/07/23 Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRadius = 1;

    public int numberOfWaves = 10;
    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 0.5f;
    public int currentWave = 0; //maybe should be priv
    public int activeEnemies = 0; //should be priv
    private bool wavesCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeEnemies == 0 && currentWave < numberOfWaves && !wavesCompleted)
        {
            SpawnWave();
        }
    }

    IEnumerator SpawnEnemy(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            print("Wave " + i.ToString());
            Vector2 spawnPosition = GameObject.FindWithTag("Player").transform.position;
            spawnPosition += Random.insideUnitCircle.normalized * spawnRadius;


            Instantiate (enemy, spawnPosition, Quaternion.identity);
            activeEnemies++;
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    void SpawnWave()
    {
        if (currentWave >= numberOfWaves)
        {
            // End spawning enemies
            return;
        }

        currentWave++;
        int numberOfEnemies = currentWave * 2; // Increase number of enemies per wave
        StartCoroutine(SpawnEnemy(numberOfEnemies));
    }

    public void OnEnemyDeath()
    {
        activeEnemies--;
    }

}
