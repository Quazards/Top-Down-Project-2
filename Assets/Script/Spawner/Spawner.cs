using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay;
    private float nextSpawnTime;

    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] spawnPoint;

    private void FixedUpdate()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnDelay;
            Transform randomSpawnPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
            Instantiate(enemy, randomSpawnPoint.position, Quaternion.identity);
        }
    }

}
