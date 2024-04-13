using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject[] Enemies;
	public Transform[] SpawnPoints;
	public int maxSpawned = 5;
	public float spawnInterval = 2f;
    void Start()
    {
        StartCoroutine(spawn());
    }
	IEnumerator spawn(){
		while(true){
			if(transform.childCount < maxSpawned){
				var newSpawn = Instantiate(Enemies[Random.Range(0,Enemies.Length - 1)],SpawnPoints[Random.Range(0,SpawnPoints.Length - 1)].position,Quaternion.identity);
				newSpawn.transform.parent = gameObject.transform;
			}
			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
