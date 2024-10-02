using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] string beePrefab;
    [SerializeField] float minSpawnRate = 1f;
    [SerializeField] float maxDelay = 2f;
    private float timeSinceLastSpawn = 0f;

    [SerializeField] GameObject player;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > minSpawnRate)
        {
            float spawnRate = Random.Range(0, maxDelay);
            InstantiateBee();
            // Invoke(InstantiateBee(), spawnRate);
            timeSinceLastSpawn = 0f;
        }



    }

    void InstantiateBee()
    {
        if (!GameManager.gameOver)
        {

            Instantiate(Resources.Load(beePrefab), transform.position, transform.rotation);
        }
    }
}
