using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {
    public GameObject player;
    public GameObject obsPrefab1, obsPrefab2, obsPrefab3;

    private int whatToSpawn;
    private float spawnRate = 2f;
    private float nextSpawn = 0f;
    private Vector3 range;
    private float xRange;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 4);
            xRange = Random.Range( -10.0f, 8.0f);
            Vector3 range = new Vector3(xRange, 0, player.transform.position.z + 150f);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(obsPrefab1, range, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(obsPrefab2, range, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(obsPrefab3, range, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
	}
}
