using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTDSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;

    public GameObject enemy;

    public int enemyCount = 20;

    public float waveCooldown = 0.5f;

    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = waveCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount > 0)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                countdown = waveCooldown;
                Spawn();
            }
        }
    }

    void Spawn()
    {
        Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Count)]);
    }
}
