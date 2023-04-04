using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<GameObject> spawnPositions = new List<GameObject>();
    [SerializeField] int enemiesToSpawn;
    [SerializeField] int startingEnemies;
    [SerializeField] int spawnDelay = 3;

    [SerializeField] GameTracker manager;
    [SerializeField] GameObject target;
    float subTimer = 0f;
    int spawnTimer;

    void Start(){
        spawnTimer = spawnDelay;
        for(int i = 0; i < startingEnemies; i++){
            SpawnEnemyRandom();
        }
    }

    void FixedUpdate(){
        if(manager.CheckGameActive() == true){
            subTimer += Time.fixedDeltaTime;
            if(subTimer >= 1){
                spawnTimer--;
                subTimer -= 1;
            }
            if(spawnTimer == 0 && enemiesToSpawn > 0){
                SpawnEnemyRandom();
                spawnTimer = spawnDelay;
            }
        }
    }

    void SpawnEnemyRandom(){
        int randomSpawnPoint = Random.Range(0,spawnPositions.Count);
        SpawnEnemy(randomSpawnPoint);
    }

    void SpawnEnemy(int spawnPointID){
        Vector3 spawnPointPos = new Vector3(spawnPositions[spawnPointID].transform.position.x,
            spawnPositions[spawnPointID].transform.position.y, spawnPositions[spawnPointID].transform.position.z);

        float randomX = Random.Range(-5,5);
        float randomZ = Random.Range(-5,5);

        var randomPos = new Vector3(spawnPointPos.x + randomX, spawnPointPos.y, spawnPointPos.z + randomZ);
        GameObject enemy = Instantiate(enemyPrefab, randomPos, this.transform.rotation);
        enemy.GetComponent<ZombieControl>().SetGameManager(manager);
        enemy.GetComponent<ZombieControl>().SetTarget(target);
    }
}