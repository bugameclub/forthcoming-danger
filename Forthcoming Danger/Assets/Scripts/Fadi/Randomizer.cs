using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    // Start is called before the first frame update
	public Transform[] enemySpawn;
	public float spawnrate = 10;
	public GameObject[] enemyTypes;
	float targetTime = 10;
	
	public int moneyrate = 10;
	
    void Start()
    {
        
    }
	void spawnEnemy(){
		int enemyType = Random.Range(0,enemyTypes.Length - 1);
		int spawnLoc = Random.Range(0,enemySpawn.Length - 1);
		Instantiate(enemyTypes[enemyType],enemySpawn[spawnLoc]);
	}
	
	int getEnemyScrap(int enemyWeight = 1){
		return Random.Range(moneyrate - 2, moneyrate + 2) * enemyWeight;
	}
    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            spawnEnemy();
            targetTime = Random.Range(spawnrate - 4, spawnrate+4);
            //Debug.Log(targetTime);
        }
    }
}
