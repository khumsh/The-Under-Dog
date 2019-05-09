using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRun : MonoBehaviour {
    public float speed = 0.2f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position   + new Vector3(0, 0, speed);
        if (transform.position.z > 20)
        {
            transform.position = new Vector3(0, 0, -3.2f);
        }
	}
}
