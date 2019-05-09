using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
    public GameObject player;
    public GameObject monPrefab1, monPrefab2, monPrefab3, monPrefab4, monPrefab5;

    private int whatToSpawn;
    private float spawnRate = 17f;
    private float nextSpawn = 45f;
    private Vector3 range;
    private float xRange;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 6);
            xRange = Random.Range(-9.0f, 7.0f);
            Vector3 range = new Vector3(xRange, 0.5f, player.transform.position.z + 100f);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(monPrefab1, range, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(monPrefab2, range, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(monPrefab3, range, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(monPrefab4, range, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(monPrefab5, range, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}
