using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public GameObject player;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.z + 80f < player.transform.position.z)
        {
            Destroy(gameObject);
        }
	}
}
